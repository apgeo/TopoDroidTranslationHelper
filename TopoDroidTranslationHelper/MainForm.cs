using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopoDroidTranslationHelper
{
    public partial class MainForm : Form
    {
        string topodroidDirectoryPath;
        string confLanguageCode;

        TDLanguage selectedTDLanguage;
        // string selectedLangCode = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GlobalContext.MainWindow = this;
            this.Text = GlobalContext.ApplicationTitle;

            LoadSettings();


            // stringsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // stringsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            // stringsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            stringsDataGridView.AllowUserToOrderColumns = true;
            stringsDataGridView.AllowUserToResizeColumns = true;

            // List<TDLanguageString> langStrings = StringsFileReader.ReadFile(@"D:\projects\topodroid\int18\values-ro\strings.xml");

            stringsDataGridView.Columns["isModifiedDataGridViewCheckBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            stringsDataGridView.Columns["isTranslatableDataGridViewCheckBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            stringsDataGridView.Columns["isCommentedDataGridViewCheckBoxColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            if (!string.IsNullOrWhiteSpace(topodroidDirectoryPath))
            {
                ProcessTopoDroidDirectory(topodroidDirectoryPath);

                if (!string.IsNullOrWhiteSpace(confLanguageCode))
                    try
                    {
                        SelectLanguage(GlobalContext.TopodroidLanguageManager.TDLanguages.First(t => t.LanguageIdName == confLanguageCode));
                    }
                    catch (Exception ex)
                    {
                        GlobalContext.MainWindow.Output("error selecting language '{0}': {1}", confLanguageCode, ex.Message);
                    }
            }
            else
                SelectTopoDroidDirectory();
        }

        void LoadSettings()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.AppSettings.Settings["TopoDroidDirectory"] != null)
                    topodroidDirectoryPath = config.AppSettings.Settings["TopoDroidDirectory"].Value;

                if (config.AppSettings.Settings["LanguageCode"] != null)
                    confLanguageCode = config.AppSettings.Settings["LanguageCode"].Value;

                if (config.AppSettings.Settings["UseEnterKeyForLoadingNextString"] != null)
                    GlobalContext.UseEnterKeyForLoadingNextString = bool.Parse(config.AppSettings.Settings["UseEnterKeyForLoadingNextString"].Value);

                if (config.AppSettings.Settings["SelectFullStringWhenLoadingNextString"] != null)
                    GlobalContext.SelectFullStringWhenLoadingNextString = bool.Parse(config.AppSettings.Settings["SelectFullStringWhenLoadingNextString"].Value);

                if (config.AppSettings.Settings["MaxLogLevel"] != null)
                    maxLogLevelToShow = int.Parse(config.AppSettings.Settings["MaxLogLevel"].Value);

                GlobalContext.MainWindow.Output("Settings read from '{0}'", config.FilePath);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error reading from configuration file: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }
        }

        void SaveSettings(/*string selectedLanguageCode*/)
        {
            try
            {
                string selectedLangCode = selectedTDLanguage != null ? selectedTDLanguage.LanguageIdName : "";

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings.Remove("TopoDroidDirectory");
                config.AppSettings.Settings.Add("TopoDroidDirectory", topodroidDirectoryPath);

                if (selectedTDLanguage != null)
                {
                    config.AppSettings.Settings.Remove("LanguageCode");
                    config.AppSettings.Settings.Add("LanguageCode", selectedTDLanguage.LanguageIdName);
                }

                config.AppSettings.Settings.Remove("UseEnterKeyForLoadingNextString");
                config.AppSettings.Settings.Add("UseEnterKeyForLoadingNextString", GlobalContext.UseEnterKeyForLoadingNextString.ToString());

                config.AppSettings.Settings.Remove("SelectFullStringWhenLoadingNextString");
                config.AppSettings.Settings.Add("SelectFullStringWhenLoadingNextString", GlobalContext.SelectFullStringWhenLoadingNextString.ToString());

                config.AppSettings.Settings.Remove("MaxLogLevel");
                config.AppSettings.Settings.Add("MaxLogLevel", maxLogLevelToShow.ToString());

                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                Output(string.Format("Error writing to configuration file: {0} {1} {2}", ex.Message, ex.StackTrace, ex.TargetSite));
            }
        }


        int logCounter = 0;

        private bool logToScreen = true;

        // Constants for extern calls to various scrollbar functions
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        private const int SB_BOTTOM = 7;
        private const int SB_OFFSET = 13;

        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll")]
        private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);


        int maxLogLevelToShow = 1;

        private delegate void SetTextCallback(string text, int level);

        public void Output(string text, params object[] args)
        {
            string msg = string.Format(text, args);
            Output(msg);
        }

        public void Output(string text, int level = 1)
        {
            if (level > maxLogLevelToShow)
                return;

            if (this.logTextBox != null)
                if (this.logTextBox.InvokeRequired)
                {
                    SetTextCallback stc = new SetTextCallback(Output);
                    this.Invoke(stc, new object[] { text });
                }
                else
                {
                    try
                    {
                        if (true /*autoScrollCheckBox.Checked*/)
                        {
                            bool bottomFlag = false;
                            int VSmin;
                            int VSmax;
                            int sbOffset;
                            int savedVpos;

                            // Win32 magic to keep the textbox scrolling to the newest append to the textbox unless
                            // the user has moved the scrollbox up
                            sbOffset = (int)((this.logTextBox.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight) / (this.logTextBox.Font.Height));
                            savedVpos = GetScrollPos(this.logTextBox.Handle, SB_VERT);
                            GetScrollRange(this.logTextBox.Handle, SB_VERT, out VSmin, out VSmax);
                            if (savedVpos >= (VSmax - sbOffset - 1))
                                bottomFlag = true;

                            this.logTextBox.AppendText("[" + DateTime.Now.ToString("dd HH:mm:ss.fff") + "] " + text + "\r\n");

                            if (bottomFlag)
                            {
                                GetScrollRange(this.logTextBox.Handle, SB_VERT, out VSmin, out VSmax);
                                savedVpos = VSmax - sbOffset;
                                bottomFlag = false;
                            }

                            SetScrollPos(this.logTextBox.Handle, SB_VERT, savedVpos, true);
                            PostMessageA(this.logTextBox.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * savedVpos, 0);
                        }
                        else
                        {
                            logTextBox.AppendText("[" + DateTime.Now.ToString("hh:mm:ss") + "] " + text + "\r\n");
                        }
                    }
                    catch (ObjectDisposedException ex)
                    {

                    }
                }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.carto.net/neumann/caving/cave-symbols/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.uisic.uis-speleo.org/lexuni.html");
        }

        void OpenStringEditor(TDLanguageString tdls)
        {
            if (selectedTDLanguage == null)
                return;

            EditLanguageStringForm elsForm = new EditLanguageStringForm();

            elsForm.CurrentLang = selectedTDLanguage;

            elsForm.ShowDialog(tdls);

            // elsForm.CurrentTDLS
            tDLanguageStringBindingSource.ResetBindings(false);
        }

        public void RefreshStringsDataGrid()
        {
            tDLanguageStringBindingSource.ResetBindings(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            OpenStringEditor((TDLanguageString)stringsDataGridView.Rows[e.RowIndex].DataBoundItem);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stringsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OpenStringEditor((TDLanguageString)stringsDataGridView.SelectedCells[0].OwningRow.DataBoundItem);
        }

        private void selectLanguageButton_Click(object sender, EventArgs e)
        {
            if (GlobalContext.TopodroidLanguageManager == null)
            {
                GlobalContext.MainWindow.Output("TopoDroid directory is not defined");
                return;
            }

            if ((selectedTDLanguage != null) && selectedTDLanguage.IsModified && MessageBox.Show("The current language is not saved. Are you sure you want to change language? Changes will be lost.", GlobalContext.ApplicationTitle, MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            LanguageSelectorForm lsForm = new LanguageSelectorForm();

            if (lsForm.ShowDialog() == DialogResult.OK)
            {
                SelectLanguage(lsForm.SelectedLanguage);
                lsForm.Dispose();
            }
        }

        void SelectLanguage(TDLanguage tdl)
        {
            selectedTDLanguage = tdl;
            tDLanguageStringBindingSource.DataSource = selectedTDLanguage.LanguageStrings; // GlobalContext.TopodroidLanguageManager.TDLanguages[0].LanguageStrings;
            //tDLanguageStringBindingSource.ResetBindings(false);

            this.Text = GlobalContext.ApplicationTitle + " - " + tdl;
            selectedLanguageLabel.Text = tdl.ToString();
        }

        private void saveTDLanguageFileButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This tool is experimental and may lead to information loss. Please backup your repository files before going forward. Continue modifying the file?", GlobalContext.ApplicationTitle, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            SaveTranslationFile();
        }

        void SaveTranslationFile()
        {
            if (GlobalContext.TopodroidLanguageManager == null)
            {
                GlobalContext.MainWindow.Output("TopoDroid directory is not defined");
                return;
            }

            if (selectedTDLanguage == null)
            {
                GlobalContext.MainWindow.Output("No language selected");
                return;
            }

            GlobalContext.TopodroidLanguageManager.SaveLanguageFile(selectedTDLanguage);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void openTopoDroidDirectoryButton_Click(object sender, EventArgs e)
        {
            SelectTopoDroidDirectory();
        }

        void SelectTopoDroidDirectory()
        {
            if (tdDirBrowserDialog.ShowDialog() == DialogResult.OK)
                ProcessTopoDroidDirectory(tdDirBrowserDialog.SelectedPath);
        }

        void ProcessTopoDroidDirectory(string tdDirectoryPath)
        {
            try
            {
                GlobalContext.TopodroidLanguageManager = new TopoDroidLanguageManager(tdDirectoryPath);
                topodroidDirectoryPath = tdDirectoryPath;
            }
            catch (Exception ex)
            {
                GlobalContext.MainWindow.Output("Error reading TopoDroid language files: '{0}'", ex.Message);
                GlobalContext.MainWindow.Output("Check if you selected the correct root directory of the TopoDroid source repository '\\topodroid'. Your selection: '{0}'", tdDirectoryPath);
            }

            SaveSettings();
        }

        private void openStringEditorButton_Click(object sender, EventArgs e)
        {
            if (selectedTDLanguage == null)
                return;

            OpenStringEditor(selectedTDLanguage.LanguageStrings.First());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selectedTDLanguage == null)
                return;

            if (selectedTDLanguage.IsModified && MessageBox.Show("The current language is not saved. Are you sure you want to exit? Changes will be lost.", GlobalContext.ApplicationTitle, MessageBoxButtons.OKCancel) != DialogResult.OK)
                e.Cancel = true;
        }

        private void stringsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (stringsDataGridView.Rows[e.RowIndex].DataBoundItem == null)
                return;

            TDLanguageString tdls = (TDLanguageString)stringsDataGridView.Rows[e.RowIndex].DataBoundItem;

            e.CellStyle.BackColor = Color.PaleGreen; //  Color.LightGreen;

            if (tdls.IsCommented)
                e.CellStyle.BackColor = Color.LightGray;
            //else
            if (!tdls.IsTranslatable)
                e.CellStyle.BackColor = Color.LightGray;

            if (tdls.IsForTranslation())                
                e.CellStyle.BackColor = Color.LightPink;
                //e.CellStyle.BackColor = Color.LightGreen;

            //else
            if (tdls.IsModified || tdls.MarkedAsTranslatedEarlier)
                e.CellStyle.BackColor = Color.LightGreen; // Color.Green;
        }

        public void ScrollToString(TDLanguageString tdls)
        {
            // dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;

            foreach (DataGridViewRow row in stringsDataGridView.Rows)
                if (row.DataBoundItem == tdls)
                {
                    stringsDataGridView.CurrentCell = row.Cells[0];
                    // stringsDataGridView.CurrentCell = stringsDataGridView.Rows[index].Cells[0];
                    return;
                }
        }
    }
}
