namespace TopoDroidTranslationHelper
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stringsDataGridView = new System.Windows.Forms.DataGridView();
            this.tDLanguageStringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.selectLanguageButton = new System.Windows.Forms.Button();
            this.selectedLanguageLabel = new System.Windows.Forms.Label();
            this.saveTDLanguageFileButton = new System.Windows.Forms.Button();
            this.openTopoDroidDirectoryButton = new System.Windows.Forms.Button();
            this.tdDirBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openStringEditorButton = new System.Windows.Forms.Button();
            this.stringIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalTextValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalLineTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linePositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeLineCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCommentedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isTranslatableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.commentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isNotTranslatableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isModifiedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.extractedElementFromCommentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stringsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDLanguageStringBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stringsDataGridView
            // 
            this.stringsDataGridView.AllowUserToAddRows = false;
            this.stringsDataGridView.AllowUserToDeleteRows = false;
            this.stringsDataGridView.AllowUserToOrderColumns = true;
            this.stringsDataGridView.AutoGenerateColumns = false;
            this.stringsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stringsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stringsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stringIdDataGridViewTextBoxColumn,
            this.textValueDataGridViewTextBoxColumn,
            this.lineNumberDataGridViewTextBoxColumn,
            this.originalTextValueDataGridViewTextBoxColumn,
            this.originalLineTextDataGridViewTextBoxColumn,
            this.linePositionDataGridViewTextBoxColumn,
            this.nodeLineCountDataGridViewTextBoxColumn,
            this.isCommentedDataGridViewCheckBoxColumn,
            this.isTranslatableDataGridViewCheckBoxColumn,
            this.commentTypeDataGridViewTextBoxColumn,
            this.isNotTranslatableDataGridViewCheckBoxColumn,
            this.isModifiedDataGridViewCheckBoxColumn,
            this.extractedElementFromCommentDataGridViewTextBoxColumn});
            this.stringsDataGridView.DataSource = this.tDLanguageStringBindingSource;
            this.stringsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.stringsDataGridView.Name = "stringsDataGridView";
            this.stringsDataGridView.Size = new System.Drawing.Size(1459, 442);
            this.stringsDataGridView.TabIndex = 0;
            this.stringsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.stringsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.stringsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.stringsDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.stringsDataGridView_CellFormatting);
            this.stringsDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stringsDataGridView_KeyDown);
            // 
            // tDLanguageStringBindingSource
            // 
            this.tDLanguageStringBindingSource.DataSource = typeof(TopoDroidTranslationHelper.TDLanguageString);
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextBox.Location = new System.Drawing.Point(0, 0);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(1459, 265);
            this.logTextBox.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(1370, 243);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(69, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Cave terms 2";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1295, 243);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(69, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Cave terms 1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.stringsDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel1);
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel2);
            this.splitContainer1.Panel2.Controls.Add(this.logTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1459, 711);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.TabIndex = 16;
            // 
            // selectLanguageButton
            // 
            this.selectLanguageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectLanguageButton.Location = new System.Drawing.Point(156, 12);
            this.selectLanguageButton.Name = "selectLanguageButton";
            this.selectLanguageButton.Size = new System.Drawing.Size(114, 23);
            this.selectLanguageButton.TabIndex = 17;
            this.selectLanguageButton.Text = "Select language";
            this.selectLanguageButton.UseVisualStyleBackColor = true;
            this.selectLanguageButton.Click += new System.EventHandler(this.selectLanguageButton_Click);
            // 
            // selectedLanguageLabel
            // 
            this.selectedLanguageLabel.AutoSize = true;
            this.selectedLanguageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLanguageLabel.Location = new System.Drawing.Point(340, 9);
            this.selectedLanguageLabel.Name = "selectedLanguageLabel";
            this.selectedLanguageLabel.Size = new System.Drawing.Size(179, 24);
            this.selectedLanguageLabel.TabIndex = 18;
            this.selectedLanguageLabel.Text = "no language loaded";
            // 
            // saveTDLanguageFileButton
            // 
            this.saveTDLanguageFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTDLanguageFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveTDLanguageFileButton.Location = new System.Drawing.Point(1337, 9);
            this.saveTDLanguageFileButton.Name = "saveTDLanguageFileButton";
            this.saveTDLanguageFileButton.Size = new System.Drawing.Size(125, 23);
            this.saveTDLanguageFileButton.TabIndex = 19;
            this.saveTDLanguageFileButton.Text = "Save translation file";
            this.saveTDLanguageFileButton.UseVisualStyleBackColor = true;
            this.saveTDLanguageFileButton.Click += new System.EventHandler(this.saveTDLanguageFileButton_Click);
            // 
            // openTopoDroidDirectoryButton
            // 
            this.openTopoDroidDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openTopoDroidDirectoryButton.Location = new System.Drawing.Point(3, 12);
            this.openTopoDroidDirectoryButton.Name = "openTopoDroidDirectoryButton";
            this.openTopoDroidDirectoryButton.Size = new System.Drawing.Size(147, 23);
            this.openTopoDroidDirectoryButton.TabIndex = 20;
            this.openTopoDroidDirectoryButton.Text = "Open TopoDroid directory";
            this.openTopoDroidDirectoryButton.UseVisualStyleBackColor = true;
            this.openTopoDroidDirectoryButton.Click += new System.EventHandler(this.openTopoDroidDirectoryButton_Click);
            // 
            // tdDirBrowserDialog
            // 
            this.tdDirBrowserDialog.Description = "Select the TopoDroid source repository root directory";
            // 
            // openStringEditorButton
            // 
            this.openStringEditorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openStringEditorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openStringEditorButton.Location = new System.Drawing.Point(1169, 9);
            this.openStringEditorButton.Name = "openStringEditorButton";
            this.openStringEditorButton.Size = new System.Drawing.Size(91, 23);
            this.openStringEditorButton.TabIndex = 21;
            this.openStringEditorButton.Text = "String editor";
            this.openStringEditorButton.UseVisualStyleBackColor = true;
            this.openStringEditorButton.Click += new System.EventHandler(this.openStringEditorButton_Click);
            // 
            // stringIdDataGridViewTextBoxColumn
            // 
            this.stringIdDataGridViewTextBoxColumn.DataPropertyName = "StringId";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stringIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.stringIdDataGridViewTextBoxColumn.Frozen = true;
            this.stringIdDataGridViewTextBoxColumn.HeaderText = "StringId";
            this.stringIdDataGridViewTextBoxColumn.Name = "stringIdDataGridViewTextBoxColumn";
            this.stringIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // textValueDataGridViewTextBoxColumn
            // 
            this.textValueDataGridViewTextBoxColumn.DataPropertyName = "TextValue";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textValueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.textValueDataGridViewTextBoxColumn.HeaderText = "TextValue";
            this.textValueDataGridViewTextBoxColumn.Name = "textValueDataGridViewTextBoxColumn";
            this.textValueDataGridViewTextBoxColumn.Width = 400;
            // 
            // lineNumberDataGridViewTextBoxColumn
            // 
            this.lineNumberDataGridViewTextBoxColumn.DataPropertyName = "LineNumber";
            this.lineNumberDataGridViewTextBoxColumn.HeaderText = "LineNumber";
            this.lineNumberDataGridViewTextBoxColumn.Name = "lineNumberDataGridViewTextBoxColumn";
            // 
            // originalTextValueDataGridViewTextBoxColumn
            // 
            this.originalTextValueDataGridViewTextBoxColumn.DataPropertyName = "OriginalTextValue";
            this.originalTextValueDataGridViewTextBoxColumn.HeaderText = "OriginalTextValue";
            this.originalTextValueDataGridViewTextBoxColumn.Name = "originalTextValueDataGridViewTextBoxColumn";
            this.originalTextValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.originalTextValueDataGridViewTextBoxColumn.Width = 400;
            // 
            // originalLineTextDataGridViewTextBoxColumn
            // 
            this.originalLineTextDataGridViewTextBoxColumn.DataPropertyName = "OriginalLineText";
            this.originalLineTextDataGridViewTextBoxColumn.HeaderText = "OriginalLineText";
            this.originalLineTextDataGridViewTextBoxColumn.Name = "originalLineTextDataGridViewTextBoxColumn";
            this.originalLineTextDataGridViewTextBoxColumn.Width = 350;
            // 
            // linePositionDataGridViewTextBoxColumn
            // 
            this.linePositionDataGridViewTextBoxColumn.DataPropertyName = "LinePosition";
            this.linePositionDataGridViewTextBoxColumn.HeaderText = "LinePosition";
            this.linePositionDataGridViewTextBoxColumn.Name = "linePositionDataGridViewTextBoxColumn";
            this.linePositionDataGridViewTextBoxColumn.ReadOnly = true;
            this.linePositionDataGridViewTextBoxColumn.Visible = false;
            // 
            // nodeLineCountDataGridViewTextBoxColumn
            // 
            this.nodeLineCountDataGridViewTextBoxColumn.DataPropertyName = "NodeLineCount";
            this.nodeLineCountDataGridViewTextBoxColumn.HeaderText = "NodeLineCount";
            this.nodeLineCountDataGridViewTextBoxColumn.Name = "nodeLineCountDataGridViewTextBoxColumn";
            this.nodeLineCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.nodeLineCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // isCommentedDataGridViewCheckBoxColumn
            // 
            this.isCommentedDataGridViewCheckBoxColumn.DataPropertyName = "IsCommented";
            this.isCommentedDataGridViewCheckBoxColumn.HeaderText = "IsCommented";
            this.isCommentedDataGridViewCheckBoxColumn.Name = "isCommentedDataGridViewCheckBoxColumn";
            this.isCommentedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCommentedDataGridViewCheckBoxColumn.Width = 40;
            // 
            // isTranslatableDataGridViewCheckBoxColumn
            // 
            this.isTranslatableDataGridViewCheckBoxColumn.DataPropertyName = "IsTranslatable";
            this.isTranslatableDataGridViewCheckBoxColumn.HeaderText = "IsTranslatable";
            this.isTranslatableDataGridViewCheckBoxColumn.Name = "isTranslatableDataGridViewCheckBoxColumn";
            this.isTranslatableDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isTranslatableDataGridViewCheckBoxColumn.Width = 40;
            // 
            // commentTypeDataGridViewTextBoxColumn
            // 
            this.commentTypeDataGridViewTextBoxColumn.DataPropertyName = "CommentType";
            this.commentTypeDataGridViewTextBoxColumn.HeaderText = "CommentType";
            this.commentTypeDataGridViewTextBoxColumn.Name = "commentTypeDataGridViewTextBoxColumn";
            this.commentTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isNotTranslatableDataGridViewCheckBoxColumn
            // 
            this.isNotTranslatableDataGridViewCheckBoxColumn.DataPropertyName = "IsNotTranslatable";
            this.isNotTranslatableDataGridViewCheckBoxColumn.HeaderText = "IsNotTranslatable";
            this.isNotTranslatableDataGridViewCheckBoxColumn.Name = "isNotTranslatableDataGridViewCheckBoxColumn";
            this.isNotTranslatableDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isNotTranslatableDataGridViewCheckBoxColumn.Visible = false;
            this.isNotTranslatableDataGridViewCheckBoxColumn.Width = 40;
            // 
            // isModifiedDataGridViewCheckBoxColumn
            // 
            this.isModifiedDataGridViewCheckBoxColumn.DataPropertyName = "IsModified";
            this.isModifiedDataGridViewCheckBoxColumn.HeaderText = "IsModified";
            this.isModifiedDataGridViewCheckBoxColumn.Name = "isModifiedDataGridViewCheckBoxColumn";
            this.isModifiedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isModifiedDataGridViewCheckBoxColumn.Width = 40;
            // 
            // extractedElementFromCommentDataGridViewTextBoxColumn
            // 
            this.extractedElementFromCommentDataGridViewTextBoxColumn.DataPropertyName = "ExtractedElementFromComment";
            this.extractedElementFromCommentDataGridViewTextBoxColumn.HeaderText = "ExtractedElementFromComment";
            this.extractedElementFromCommentDataGridViewTextBoxColumn.Name = "extractedElementFromCommentDataGridViewTextBoxColumn";
            this.extractedElementFromCommentDataGridViewTextBoxColumn.ReadOnly = true;
            this.extractedElementFromCommentDataGridViewTextBoxColumn.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 753);
            this.Controls.Add(this.openStringEditorButton);
            this.Controls.Add(this.openTopoDroidDirectoryButton);
            this.Controls.Add(this.saveTDLanguageFileButton);
            this.Controls.Add(this.selectedLanguageLabel);
            this.Controls.Add(this.selectLanguageButton);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stringsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDLanguageStringBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stringsDataGridView;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button selectLanguageButton;
        private System.Windows.Forms.Label selectedLanguageLabel;
        private System.Windows.Forms.Button saveTDLanguageFileButton;
        private System.Windows.Forms.Button openTopoDroidDirectoryButton;
        private System.Windows.Forms.FolderBrowserDialog tdDirBrowserDialog;
        private System.Windows.Forms.Button openStringEditorButton;
        private System.Windows.Forms.BindingSource tDLanguageStringBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn stringIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalTextValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalLineTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn linePositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeLineCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCommentedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTranslatableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isNotTranslatableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isModifiedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extractedElementFromCommentDataGridViewTextBoxColumn;
    }
}

