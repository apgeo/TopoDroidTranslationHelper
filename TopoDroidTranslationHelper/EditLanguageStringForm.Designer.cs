namespace TopoDroidTranslationHelper
{
    partial class EditLanguageStringForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stringTextValueTextBox = new System.Windows.Forms.TextBox();
            this.otherTranslationsTextBox = new System.Windows.Forms.TextBox();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.currentIndexLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.commentLabel = new System.Windows.Forms.Label();
            this.isNotTranslatableLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.restoreOriginalButton = new System.Windows.Forms.Button();
            this.useEnterKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.lineNumberLabel = new System.Windows.Forms.Label();
            this.editLanguageStringFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.selectFullTextCheckBox = new System.Windows.Forms.CheckBox();
            this.modifiedLabel = new System.Windows.Forms.Label();
            this.gotoNextUntranslatedButton = new System.Windows.Forms.Button();
            this.gotoPreviousUntranslatedButton = new System.Windows.Forms.Button();
            this.statsLabel = new System.Windows.Forms.Label();
            this.stringIdNameTextBox = new System.Windows.Forms.TextBox();
            this.copyIdToClipboardButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.originalTextValueTextBox = new System.Windows.Forms.TextBox();
            this.originalXMLLineTextBox = new System.Windows.Forms.TextBox();
            this.showHideSourceButton = new System.Windows.Forms.Button();
            this.sourceRichTextBox = new System.Windows.Forms.RichTextBox();
            this.previousModifiedButton = new System.Windows.Forms.Button();
            this.nextModifiedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editLanguageStringFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(800, 654);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "String ID/name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "String text value:";
            // 
            // stringTextValueTextBox
            // 
            this.stringTextValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stringTextValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringTextValueTextBox.Location = new System.Drawing.Point(112, 49);
            this.stringTextValueTextBox.Multiline = true;
            this.stringTextValueTextBox.Name = "stringTextValueTextBox";
            this.stringTextValueTextBox.Size = new System.Drawing.Size(381, 112);
            this.stringTextValueTextBox.TabIndex = 4;
            this.stringTextValueTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stringTextValueTextBox_KeyDown);
            this.stringTextValueTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.stringTextValueTextBox_KeyPress);
            this.stringTextValueTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.stringTextValueTextBox_KeyUp);
            this.stringTextValueTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.stringTextValueTextBox_PreviewKeyDown);
            // 
            // otherTranslationsTextBox
            // 
            this.otherTranslationsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.otherTranslationsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otherTranslationsTextBox.Location = new System.Drawing.Point(112, 311);
            this.otherTranslationsTextBox.Multiline = true;
            this.otherTranslationsTextBox.Name = "otherTranslationsTextBox";
            this.otherTranslationsTextBox.ReadOnly = true;
            this.otherTranslationsTextBox.Size = new System.Drawing.Size(763, 286);
            this.otherTranslationsTextBox.TabIndex = 5;
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousButton.Location = new System.Drawing.Point(293, 654);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 23);
            this.previousButton.TabIndex = 6;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Location = new System.Drawing.Point(374, 654);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // currentIndexLabel
            // 
            this.currentIndexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.currentIndexLabel.AutoSize = true;
            this.currentIndexLabel.Location = new System.Drawing.Point(21, 631);
            this.currentIndexLabel.Name = "currentIndexLabel";
            this.currentIndexLabel.Size = new System.Drawing.Size(61, 13);
            this.currentIndexLabel.TabIndex = 8;
            this.currentIndexLabel.Text = "_________";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(154, 600);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(399, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Use: Page Up / PageDown keys to navigate between strings";
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(656, 43);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(76, 13);
            this.commentLabel.TabIndex = 10;
            this.commentLabel.Text = "commentLabel";
            this.commentLabel.Click += new System.EventHandler(this.commentLabel_Click);
            // 
            // isNotTranslatableLabel
            // 
            this.isNotTranslatableLabel.AutoSize = true;
            this.isNotTranslatableLabel.Location = new System.Drawing.Point(656, 24);
            this.isNotTranslatableLabel.Name = "isNotTranslatableLabel";
            this.isNotTranslatableLabel.Size = new System.Drawing.Size(115, 13);
            this.isNotTranslatableLabel.TabIndex = 11;
            this.isNotTranslatableLabel.Text = "isNotTranslatableLabel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Original XML line:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Original text value:";
            // 
            // restoreOriginalButton
            // 
            this.restoreOriginalButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreOriginalButton.Location = new System.Drawing.Point(740, 197);
            this.restoreOriginalButton.Name = "restoreOriginalButton";
            this.restoreOriginalButton.Size = new System.Drawing.Size(136, 23);
            this.restoreOriginalButton.TabIndex = 16;
            this.restoreOriginalButton.Text = "↺ Restore original";
            this.restoreOriginalButton.UseVisualStyleBackColor = true;
            this.restoreOriginalButton.Click += new System.EventHandler(this.restoreOriginalButton_Click);
            // 
            // useEnterKeyCheckBox
            // 
            this.useEnterKeyCheckBox.AutoSize = true;
            this.useEnterKeyCheckBox.Location = new System.Drawing.Point(666, 115);
            this.useEnterKeyCheckBox.Name = "useEnterKeyCheckBox";
            this.useEnterKeyCheckBox.Size = new System.Drawing.Size(325, 17);
            this.useEnterKeyCheckBox.TabIndex = 17;
            this.useEnterKeyCheckBox.Text = "Enter for loading next string (Ctrl+Enter for new line in string text)";
            this.useEnterKeyCheckBox.UseVisualStyleBackColor = true;
            this.useEnterKeyCheckBox.CheckedChanged += new System.EventHandler(this.useEnterKeyCheckBox_CheckedChanged);
            // 
            // lineNumberLabel
            // 
            this.lineNumberLabel.AutoSize = true;
            this.lineNumberLabel.Location = new System.Drawing.Point(656, 62);
            this.lineNumberLabel.Name = "lineNumberLabel";
            this.lineNumberLabel.Size = new System.Drawing.Size(86, 13);
            this.lineNumberLabel.TabIndex = 18;
            this.lineNumberLabel.Text = "lineNumberLabel";
            // 
            // editLanguageStringFormBindingSource
            // 
            this.editLanguageStringFormBindingSource.DataSource = typeof(TopoDroidTranslationHelper.EditLanguageStringForm);
            // 
            // selectFullTextCheckBox
            // 
            this.selectFullTextCheckBox.AutoSize = true;
            this.selectFullTextCheckBox.Location = new System.Drawing.Point(666, 161);
            this.selectFullTextCheckBox.Name = "selectFullTextCheckBox";
            this.selectFullTextCheckBox.Size = new System.Drawing.Size(209, 17);
            this.selectFullTextCheckBox.TabIndex = 19;
            this.selectFullTextCheckBox.Text = "Select full text when loading new string";
            this.selectFullTextCheckBox.UseVisualStyleBackColor = true;
            this.selectFullTextCheckBox.CheckedChanged += new System.EventHandler(this.selectFullTextCheckBox_CheckedChanged);
            // 
            // modifiedLabel
            // 
            this.modifiedLabel.AutoSize = true;
            this.modifiedLabel.Location = new System.Drawing.Point(656, 81);
            this.modifiedLabel.Name = "modifiedLabel";
            this.modifiedLabel.Size = new System.Drawing.Size(72, 13);
            this.modifiedLabel.TabIndex = 20;
            this.modifiedLabel.Text = "modifiedLabel";
            // 
            // gotoNextUntranslatedButton
            // 
            this.gotoNextUntranslatedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoNextUntranslatedButton.Location = new System.Drawing.Point(740, 226);
            this.gotoNextUntranslatedButton.Name = "gotoNextUntranslatedButton";
            this.gotoNextUntranslatedButton.Size = new System.Drawing.Size(136, 23);
            this.gotoNextUntranslatedButton.TabIndex = 21;
            this.gotoNextUntranslatedButton.Text = "Goto next untranslated";
            this.gotoNextUntranslatedButton.UseVisualStyleBackColor = true;
            this.gotoNextUntranslatedButton.Click += new System.EventHandler(this.gotoFirstuntranslatedButton_Click);
            // 
            // gotoPreviousUntranslatedButton
            // 
            this.gotoPreviousUntranslatedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoPreviousUntranslatedButton.Location = new System.Drawing.Point(740, 255);
            this.gotoPreviousUntranslatedButton.Name = "gotoPreviousUntranslatedButton";
            this.gotoPreviousUntranslatedButton.Size = new System.Drawing.Size(136, 23);
            this.gotoPreviousUntranslatedButton.TabIndex = 22;
            this.gotoPreviousUntranslatedButton.Text = "Previous untranslated";
            this.gotoPreviousUntranslatedButton.UseVisualStyleBackColor = true;
            this.gotoPreviousUntranslatedButton.Click += new System.EventHandler(this.gotoPreviousUntranslatedButton_Click);
            // 
            // statsLabel
            // 
            this.statsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statsLabel.AutoSize = true;
            this.statsLabel.Location = new System.Drawing.Point(21, 659);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(55, 13);
            this.statsLabel.TabIndex = 23;
            this.statsLabel.Text = "statsLabel";
            // 
            // stringIdNameTextBox
            // 
            this.stringIdNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stringIdNameTextBox.Location = new System.Drawing.Point(113, 24);
            this.stringIdNameTextBox.Name = "stringIdNameTextBox";
            this.stringIdNameTextBox.ReadOnly = true;
            this.stringIdNameTextBox.Size = new System.Drawing.Size(355, 13);
            this.stringIdNameTextBox.TabIndex = 24;
            // 
            // copyIdToClipboardButton
            // 
            this.copyIdToClipboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyIdToClipboardButton.Location = new System.Drawing.Point(474, 21);
            this.copyIdToClipboardButton.Name = "copyIdToClipboardButton";
            this.copyIdToClipboardButton.Size = new System.Drawing.Size(21, 22);
            this.copyIdToClipboardButton.TabIndex = 25;
            this.copyIdToClipboardButton.Text = "C";
            this.copyIdToClipboardButton.UseVisualStyleBackColor = true;
            this.copyIdToClipboardButton.Click += new System.EventHandler(this.copyIdToClipboardButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Location = new System.Drawing.Point(634, 285);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(161, 20);
            this.searchTextBox.TabIndex = 26;
            // 
            // searchButton
            // 
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(800, 284);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 21);
            this.searchButton.TabIndex = 27;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // originalTextValueTextBox
            // 
            this.originalTextValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.originalTextValueTextBox.Location = new System.Drawing.Point(113, 175);
            this.originalTextValueTextBox.Name = "originalTextValueTextBox";
            this.originalTextValueTextBox.ReadOnly = true;
            this.originalTextValueTextBox.Size = new System.Drawing.Size(380, 13);
            this.originalTextValueTextBox.TabIndex = 28;
            // 
            // originalXMLLineTextBox
            // 
            this.originalXMLLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.originalXMLLineTextBox.Location = new System.Drawing.Point(113, 199);
            this.originalXMLLineTextBox.Multiline = true;
            this.originalXMLLineTextBox.Name = "originalXMLLineTextBox";
            this.originalXMLLineTextBox.ReadOnly = true;
            this.originalXMLLineTextBox.Size = new System.Drawing.Size(421, 106);
            this.originalXMLLineTextBox.TabIndex = 29;
            // 
            // showHideSourceButton
            // 
            this.showHideSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showHideSourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showHideSourceButton.Location = new System.Drawing.Point(800, 603);
            this.showHideSourceButton.Name = "showHideSourceButton";
            this.showHideSourceButton.Size = new System.Drawing.Size(75, 23);
            this.showHideSourceButton.TabIndex = 30;
            this.showHideSourceButton.Text = "Source >>";
            this.showHideSourceButton.UseVisualStyleBackColor = true;
            this.showHideSourceButton.Click += new System.EventHandler(this.showHideSourceButton_Click);
            // 
            // sourceRichTextBox
            // 
            this.sourceRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourceRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sourceRichTextBox.HideSelection = false;
            this.sourceRichTextBox.Location = new System.Drawing.Point(881, 12);
            this.sourceRichTextBox.Name = "sourceRichTextBox";
            this.sourceRichTextBox.ReadOnly = true;
            this.sourceRichTextBox.Size = new System.Drawing.Size(0, 665);
            this.sourceRichTextBox.TabIndex = 32;
            this.sourceRichTextBox.Text = "";
            this.sourceRichTextBox.WordWrap = false;
            // 
            // previousModifiedButton
            // 
            this.previousModifiedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousModifiedButton.Location = new System.Drawing.Point(634, 255);
            this.previousModifiedButton.Name = "previousModifiedButton";
            this.previousModifiedButton.Size = new System.Drawing.Size(100, 23);
            this.previousModifiedButton.TabIndex = 34;
            this.previousModifiedButton.Text = "Previous modified";
            this.previousModifiedButton.UseVisualStyleBackColor = true;
            this.previousModifiedButton.Click += new System.EventHandler(this.previousModifiedButton_Click);
            // 
            // nextModifiedButton
            // 
            this.nextModifiedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextModifiedButton.Location = new System.Drawing.Point(634, 227);
            this.nextModifiedButton.Name = "nextModifiedButton";
            this.nextModifiedButton.Size = new System.Drawing.Size(99, 23);
            this.nextModifiedButton.TabIndex = 33;
            this.nextModifiedButton.Text = "Next modified";
            this.nextModifiedButton.UseVisualStyleBackColor = true;
            this.nextModifiedButton.Click += new System.EventHandler(this.nextModifiedButton_Click);
            // 
            // EditLanguageStringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 689);
            this.Controls.Add(this.previousModifiedButton);
            this.Controls.Add(this.nextModifiedButton);
            this.Controls.Add(this.sourceRichTextBox);
            this.Controls.Add(this.showHideSourceButton);
            this.Controls.Add(this.originalXMLLineTextBox);
            this.Controls.Add(this.originalTextValueTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.copyIdToClipboardButton);
            this.Controls.Add(this.stringIdNameTextBox);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.gotoPreviousUntranslatedButton);
            this.Controls.Add(this.gotoNextUntranslatedButton);
            this.Controls.Add(this.modifiedLabel);
            this.Controls.Add(this.selectFullTextCheckBox);
            this.Controls.Add(this.lineNumberLabel);
            this.Controls.Add(this.useEnterKeyCheckBox);
            this.Controls.Add(this.restoreOriginalButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isNotTranslatableLabel);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentIndexLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.otherTranslationsTextBox);
            this.Controls.Add(this.stringTextValueTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "EditLanguageStringForm";
            this.Text = "String ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditLanguageStringForm_FormClosing);
            this.Load += new System.EventHandler(this.EditLanguageStringForm_Load);
            this.Shown += new System.EventHandler(this.EditLanguageStringForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditLanguageStringForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditLanguageStringForm_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EditLanguageStringForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.editLanguageStringFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stringTextValueTextBox;
        private System.Windows.Forms.TextBox otherTranslationsTextBox;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.BindingSource editLanguageStringFormBindingSource;
        private System.Windows.Forms.Label currentIndexLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Label isNotTranslatableLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button restoreOriginalButton;
        private System.Windows.Forms.CheckBox useEnterKeyCheckBox;
        private System.Windows.Forms.Label lineNumberLabel;
        private System.Windows.Forms.CheckBox selectFullTextCheckBox;
        private System.Windows.Forms.Label modifiedLabel;
        private System.Windows.Forms.Button gotoNextUntranslatedButton;
        private System.Windows.Forms.Button gotoPreviousUntranslatedButton;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.TextBox stringIdNameTextBox;
        private System.Windows.Forms.Button copyIdToClipboardButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox originalTextValueTextBox;
        private System.Windows.Forms.TextBox originalXMLLineTextBox;
        private System.Windows.Forms.Button showHideSourceButton;
        private System.Windows.Forms.RichTextBox sourceRichTextBox;
        private System.Windows.Forms.Button previousModifiedButton;
        private System.Windows.Forms.Button nextModifiedButton;
    }
}