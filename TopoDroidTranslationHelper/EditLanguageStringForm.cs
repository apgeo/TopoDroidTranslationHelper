using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopoDroidTranslationHelper
{
    public partial class EditLanguageStringForm : Form
    {
        readonly string nl = System.Environment.NewLine;

        TDLanguageString currentTDLS;

        TDLanguage currentLang;

        int initialFormWidth;

        public TDLanguageString CurrentTDLS { get => currentTDLS; set => currentTDLS = value; }
        public TDLanguage CurrentLang { get => currentLang; set => currentLang = value; }

        public EditLanguageStringForm()
        {
            InitializeComponent();

            label3.Text = "Shortcuts:  Page Up  /  Page Down   to navigate between strings (next/previous)" + nl +
                          "            Alt + ←  /  Alt + →     to go to next/prev. untranslated string (or F10/F11)" + nl +
                          "            Alt + ↓  /  Alt + ↑     to go to next/previous modified string (or F7/F8)";

            useEnterKeyCheckBox.Checked = GlobalContext.UseEnterKeyForLoadingNextString;
            selectFullTextCheckBox.Checked = GlobalContext.SelectFullStringWhenLoadingNextString;

            useEnterKeyCheckBox.Text = "Enter for loading next string " + System.Environment.NewLine + "(Ctrl+Enter for new line in string text)";
        }

        public DialogResult ShowDialog(TDLanguageString tdls)
        {
            this.currentTDLS = tdls;

            return base.ShowDialog();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            GotoPrevious();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            GotoNext();
        }

        void GotoPrevious()
        {
            SaveData();

            int index = currentLang.LanguageStrings.IndexOf(currentTDLS);

            if (index - 1 >= 0)
            {
                currentTDLS = currentLang.LanguageStrings[index - 1];
                RefreshStringInformation();
            }
        }

        private void GotoNext()
        {
            SaveData();

            int index = currentLang.LanguageStrings.IndexOf(currentTDLS);

            if (index + 1 < currentLang.LanguageStrings.Count)
            {
                currentTDLS = currentLang.LanguageStrings[index + 1];
                RefreshStringInformation();
            }
        }

        private void EditLanguageStringForm_Load(object sender, EventArgs e)
        {
            RefreshStringInformation();

            stringTextValueTextBox.Focus();

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.copyIdToClipboardButton, "Copy to clipboard");

            sourceRichTextBox.Text = currentLang.RawSourceText;
        }

        void RefreshStringInformation()
        {
            this.SuspendLayout();

            stringIdNameTextBox.Text = currentTDLS.StringId;
            stringTextValueTextBox.Text = currentTDLS.TextValue;

            currentIndexLabel.Text = string.Format("Current index: {0}/{1}", currentLang.LanguageStrings.IndexOf(currentTDLS) + 1, currentLang.LanguageStrings.Count);

            ShowLanguageTranslations();

            commentLabel.Text = ""; // currentTDLS.IsCommented ? "Comment"

            stringTextValueTextBox.Enabled = !currentTDLS.IsNotTranslatable;
            isNotTranslatableLabel.Text = currentTDLS.IsNotTranslatable ? "not translatable" : "";

            originalTextValueTextBox.Text = currentTDLS.OriginalTextValue; // originalTextValueLabel
            originalXMLLineTextBox.Text = currentTDLS.OriginalNode.ToString(); // currentTDLS.OriginalLineText; // originalXMLLineLabel

            lineNumberLabel.Text = "File line number: " + currentTDLS.LineNumber.ToString();
            commentLabel.Text = currentTDLS.CommentType;

            stringTextValueTextBox.Focus();

            if (selectFullTextCheckBox.Checked)
                stringTextValueTextBox.SelectAll();

            modifiedLabel.Text = currentTDLS.IsModified ? "modified" : "";

            Parallel.Invoke(() =>
            {
                currentLang.UpdateLanguageStats();
                statsLabel.Text = "Translated: " + currentLang.CompletedTranslationCount + " / " + currentLang.LanguageStrings.Count + "  " + Math.Round(((double)currentLang.CompletedTranslationCount / (double)currentLang.LanguageStrings.Count) * 100, 2) + "% complete";

                GlobalContext.MainWindow.ScrollToString(currentTDLS);

                if (sourceVisible)
                    HighlightLine(sourceRichTextBox, currentTDLS.LineNumber, Color.Yellow);
            });

            stringTextValueTextBox.Font = new Font(stringTextValueTextBox.Font.FontFamily, (float)(stringTextValueTextBox.Text.Length > 50 || stringTextValueTextBox.Text.Contains("\\n") ? 8 : 14));

            // SelectSourceLine(currentTDLS.LineNumber);

            this.ResumeLayout();
        }

        void SaveData()
        {
            currentTDLS.IsModified |= currentTDLS.TextValue != stringTextValueTextBox.Text;
            currentTDLS.MarkedAsTranslatedEarlier |= currentTDLS.IsModified;

            currentLang.IsModified |= currentTDLS.IsModified;

            currentTDLS.TextValue = stringTextValueTextBox.Text;
            GlobalContext.MainWindow.RefreshStringsDataGrid();
        }

        private void EditLanguageStringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        void ShowLanguageTranslations()
        {
            string text = "";

            foreach (TDLanguage tdl in GlobalContext.TopodroidLanguageManager.TDLanguages)
                text += string.Format("  {0}: {1}{2}", tdl.LanguageIdName, tdl.LanguageStringsDictionary.ContainsKey(currentTDLS.StringId) ? tdl.LanguageStringsDictionary[currentTDLS.StringId].TextValue : "-", System.Environment.NewLine);

            otherTranslationsTextBox.Text = text;
        }

        private void EditLanguageStringForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.PageUp)
            //    GotoPrevious();
            //if (e.KeyCode == Keys.PageDown)
            //    GotoNext();
        }

        private void EditLanguageStringForm_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    GotoPrevious();
                    break;
                case Keys.PageDown:
                    GotoNext();
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    e.Handled = false;
                    break;
            }

            if (/*e.KeyCode == Keys.NumPad1 || */e.KeyCode == Keys.F10 || ((e.KeyCode == Keys.Left) && e.Alt))
            {
                e.SuppressKeyPress = true;
                GotoPreviousUntranslated();
            }

            if (/*e.KeyCode == Keys.NumPad0 || */e.KeyCode == Keys.F11 || ((e.KeyCode == Keys.Right) && e.Alt))
            {
                e.SuppressKeyPress = true;
                GotoNextUntranslated();
            }

            if (e.KeyCode == Keys.F7 || ((e.KeyCode == Keys.Down) && e.Alt))
            {
                e.SuppressKeyPress = true;
                GotoPreviousModified();
            }

            if (e.KeyCode == Keys.F8 || ((e.KeyCode == Keys.Up) && e.Alt))
            {
                e.SuppressKeyPress = true;
                GotoNextModified();
            }

            //e.Handled = true;
        }

        private void EditLanguageStringForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void commentLabel_Click(object sender, EventArgs e)
        {

        }

        private void restoreOriginalButton_Click(object sender, EventArgs e)
        {
            currentTDLS.TextValue = currentTDLS.OriginalTextValue;
            RefreshStringInformation();
        }

        private void useEnterKeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GlobalContext.UseEnterKeyForLoadingNextString = useEnterKeyCheckBox.Checked;
        }

        private void stringTextValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // e.Handled = true | false;

            if (e.KeyCode == Keys.Enter)
            {
                if (useEnterKeyCheckBox.Checked && !(e.Shift || e.Control))
                {
                    e.SuppressKeyPress = true;
                    //e.Handled = true;
                    GotoNext();
                }
            }
        }

        private void stringTextValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true | false;

            // if (e.KeyChar == '\r')
            //    e.Handled = true;
        }

        private void stringTextValueTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //e.Handled = false;

            // if (e.KeyCode == Keys.Enter)
            //    e.Handled = true;
            //e.Handled = false;

            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (useEnterKeyCheckBox.Checked && !(e.Shift || e.Control))
            //    {
            //        e.SuppressKeyPress = true;
            //        //e.Handled = true;
            //        GotoNext();
            //    }
            //}
        }

        private void stringTextValueTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void selectFullTextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GlobalContext.SelectFullStringWhenLoadingNextString = selectFullTextCheckBox.Checked;
        }

        private void EditLanguageStringForm_Shown(object sender, EventArgs e)
        {
            stringTextValueTextBox.Focus();
            initialFormWidth = this.Width;
        }

        private void gotoFirstuntranslatedButton_Click(object sender, EventArgs e)
        {
            GotoNextUntranslated();
        }

        void GotoNextUntranslated()
        {
            int indexOfCurrent = currentLang.LanguageStrings.IndexOf(currentTDLS);

            for (int index = indexOfCurrent + 1; index < currentLang.LanguageStrings.Count; index++)
            {
                TDLanguageString tdls = currentLang.LanguageStrings[index];

                if (!tdls.IsModified && tdls.IsTranslatable && tdls.IsCommented && tdls.IsForTranslation() && !tdls.MarkedAsTranslatedEarlier)
                {
                    GotoStringByIndex(index);
                    break;
                }
            }
        }

        void GotoStringByIndex(int index)
        {
            SaveData();

            currentTDLS = currentLang.LanguageStrings[index];
            RefreshStringInformation();
        }

        private void gotoPreviousUntranslatedButton_Click(object sender, EventArgs e)
        {
            GotoPreviousUntranslated();
        }

        void GotoPreviousUntranslated()
        {
            int indexOfCurrent = currentLang.LanguageStrings.IndexOf(currentTDLS);

            for (int index = indexOfCurrent - 1; index >= 0; index--)
            {
                TDLanguageString tdls = currentLang.LanguageStrings[index];

                if (!tdls.IsModified && tdls.IsTranslatable && tdls.IsCommented && tdls.IsForTranslation() && !tdls.MarkedAsTranslatedEarlier)
                {
                    GotoStringByIndex(index);
                    break;
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void copyIdToClipboardButton_Click(object sender, EventArgs e)
        {
            CopyIdToClipboard();
        }

        void CopyIdToClipboard()
        {
            try
            {
                Clipboard.SetDataObject(currentTDLS.StringId, true, 3, 1500);
            }
            catch (Exception ex)
            {
                GlobalContext.MainWindow.Output("Can't copy text to clipboard: {0}", ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchTDString(searchTextBox.Text);
        }

        int previousSearchFoundIndex = 0;

        void SearchTDString(string text)
        {
            for (int index = previousSearchFoundIndex + 1; index < currentLang.LanguageStrings.Count; index++)
            {
                TDLanguageString tdls = currentLang.LanguageStrings[index];

                if (Regex.IsMatch(tdls.StringId, WildCardToRegular("*" + text + "*")) ||
                    Regex.IsMatch(tdls.TextValue, WildCardToRegular("*" + text + "*")) ||
                    Regex.IsMatch(tdls.OriginalNode.ToString(), WildCardToRegular("*" + text + "*"))) // include original comments in XML tags
                {
                    previousSearchFoundIndex = index;
                    GotoStringByIndex(index);

                    return;
                }
            }

            previousSearchFoundIndex = 0;
            MessageBox.Show(string.Format("'{0}' not found", text), GlobalContext.ApplicationTitle);
        }

        // from https://stackoverflow.com/a/30300521

        // If you want to implement both "*" and "?"
        private static String WildCardToRegular(String value)
        {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
        }

        private void showHideSourceButton_Click(object sender, EventArgs e)
        {
            ToggleSource();
        }

        bool sourceVisible;

        void ToggleSource()
        {
            sourceVisible = !sourceVisible;
            
            this.Width = sourceVisible ? 1462 : initialFormWidth;
            showHideSourceButton.Text = sourceVisible ? "Source <<" : "Source >>";

            if (sourceVisible)
                HighlightLine(sourceRichTextBox, currentTDLS.LineNumber, Color.Yellow);
        }

        // from https://stackoverflow.com/a/15122571
        void SelectSourceLine(int lineNumber)
        {
            try
            {
                int position = sourceRichTextBox.GetFirstCharIndexFromLine(lineNumber);
                if (position < 0)
                {
                    // lineNumber is too big
                    sourceRichTextBox.Select(sourceRichTextBox.Text.Length, 0);
                }
                else
                {
                    int lineEnd = sourceRichTextBox.Text.IndexOf(Environment.NewLine, position);
                    if (lineEnd < 0)
                    {
                        lineEnd = sourceRichTextBox.Text.Length;
                    }

                    sourceRichTextBox.Select(position, lineEnd - position);
                }
            }
            catch (Exception ex)
            {
                GlobalContext.MainWindow.Output("Error selecting line #{0}: {1}", lineNumber, ex.Message);
            }
        }

        // from https://stackoverflow.com/a/27241858/
        public static void HighlightLine(RichTextBox richTextBox, int index, Color color)
        {
            if (index/* - 20*/ > 0)
            // index + 20 < richTextBox.Lines.Length
            {
                // if (lineNumber > sourceRichTextBox.Lines.Count()) return;

                try
                {
                    richTextBox.SelectionStart = richTextBox.Find(richTextBox.Lines[index /*- 1*/ /*- 20*/]);
                    //richTextBox.ScrollToCaret();
                }
                catch (Exception)
                {
                }
            }

            //richTextBox.SelectAll();
            //richTextBox.SelectionBackColor = richTextBox.BackColor;
            //var lines = richTextBox.Lines;
            //if (index < 0 || index >= lines.Length)
            //    return;
            //var start = richTextBox.GetFirstCharIndexFromLine(index);  // Get the 1st char index of the appended text
            //var length = lines[index].Length;
            //richTextBox.Select(start, length);                 // Select from there to the end
            //richTextBox.SelectionBackColor = color;
        }

        void GotoPreviousModified()
        {
            int indexOfCurrent = currentLang.LanguageStrings.IndexOf(currentTDLS);

            for (int index = indexOfCurrent - 1; index >= 0; index--)
            {
                TDLanguageString tdls = currentLang.LanguageStrings[index];

                // if (!tdls.IsModified && tdls.IsTranslatable && tdls.IsCommented && tdls.IsForTranslation() /*&& !tdls.MarkedAsTranslatedEarlier*/)
                if (tdls.IsModified)
                {
                    GotoStringByIndex(index);
                    break;
                }
            }
        }

        // from https://stackoverflow.com/a/4323299
        void ScrollToLine(int lineNumber)
        {
            if (lineNumber > sourceRichTextBox.Lines.Count()) return;

            sourceRichTextBox.SelectionStart = sourceRichTextBox.Find(sourceRichTextBox.Lines[lineNumber]);
            sourceRichTextBox.ScrollToCaret();
        }
        void GotoNextModified()
        {
            int indexOfCurrent = currentLang.LanguageStrings.IndexOf(currentTDLS);

            for (int index = indexOfCurrent + 1; index < currentLang.LanguageStrings.Count; index++)
            {
                TDLanguageString tdls = currentLang.LanguageStrings[index];

                // if (!tdls.IsModified && tdls.IsTranslatable && tdls.IsCommented && tdls.IsForTranslation() /*&& !tdls.MarkedAsTranslatedEarlier*/)
                if (tdls.IsModified)
                {
                    GotoStringByIndex(index);
                    break;
                }
            }
        }

        private void nextModifiedButton_Click(object sender, EventArgs e)
        {
            GotoNextModified();
        }

        private void previousModifiedButton_Click(object sender, EventArgs e)
        {
            GotoPreviousModified();
        }
    }
}
