using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopoDroidTranslationHelper
{
    public partial class LanguageSelectorForm : Form
    {
        TDLanguage selectedLanguage;
        
        public LanguageSelectorForm()
        {
            InitializeComponent();
        }

        public TDLanguage SelectedLanguage { get => selectedLanguage; set => selectedLanguage = value; }

        private void LanguageSelectorForm_Load(object sender, EventArgs e)
        {
            GlobalContext.TopodroidLanguageManager.UpdateLanguageStats();

            languagesListBox.DataSource = GlobalContext.TopodroidLanguageManager.TDLanguages;            

            if (selectedLanguage != null)
                languagesListBox.SelectedItem = selectedLanguage;
        }

        private void languagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLanguageInformation();
        }

        void ShowLanguageInformation()
        {
            this.selectedLanguage = (TDLanguage)languagesListBox.SelectedItem;

            if (selectedLanguage != null)
            {
                infoLabel.Text =
                    selectedLanguage.ToString() + System.Environment.NewLine +
                    selectedLanguage.LanguageStrings.Count + " strings" + System.Environment.NewLine +
                    selectedLanguage.LanguageStringsDictionary.Count + " unique strings (no duplicates in comments)" + System.Environment.NewLine +
                    selectedLanguage.CompletedTranslationCount + " / " + selectedLanguage.LanguageStrings.Count + "  " + Math.Round(((double)selectedLanguage.CompletedTranslationCount / (double)selectedLanguage.LanguageStrings.Count) * 100, 2) + "%" + System.Environment.NewLine;

            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.selectedLanguage = (TDLanguage)languagesListBox.SelectedItem;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void languagesListBox_DoubleClick(object sender, EventArgs e)
        {
            okButton.PerformClick();
        }
    }
}
