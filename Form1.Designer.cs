
namespace LogReader
{
    partial class Form1
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
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.lbClearKeys = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLogFile = new System.Windows.Forms.ComboBox();
            this.btnAddFindFolders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFindFolders = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnLnNumRange = new System.Windows.Forms.Button();
            this.tbLnNum2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbLnNum1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.rtbFilter = new System.Windows.Forms.RichTextBox();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.btnDelFindFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtLog
            // 
            this.rtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtLog.HideSelection = false;
            this.rtLog.Location = new System.Drawing.Point(2, 724);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(1330, 151);
            this.rtLog.TabIndex = 33;
            this.rtLog.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(2, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDelFindFolder);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lbClearKeys);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cbLogFile);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddFindFolders);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lbFindFolders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1330, 717);
            this.splitContainer1.SplitterDistance = 278;
            this.splitContainer1.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Filters:";
            // 
            // lbClearKeys
            // 
            this.lbClearKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClearKeys.FormattingEnabled = true;
            this.lbClearKeys.Location = new System.Drawing.Point(3, 210);
            this.lbClearKeys.Name = "lbClearKeys";
            this.lbClearKeys.Size = new System.Drawing.Size(270, 316);
            this.lbClearKeys.TabIndex = 45;
            this.lbClearKeys.SelectedIndexChanged += new System.EventHandler(this.lbClearKeys_SelectedIndexChanged);
            this.lbClearKeys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbClearKeys_KeyPress);
            this.lbClearKeys.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbClearKeys_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Select log file:";
            // 
            // cbLogFile
            // 
            this.cbLogFile.FormattingEnabled = true;
            this.cbLogFile.Location = new System.Drawing.Point(3, 136);
            this.cbLogFile.Name = "cbLogFile";
            this.cbLogFile.Size = new System.Drawing.Size(270, 21);
            this.cbLogFile.TabIndex = 43;
            this.cbLogFile.SelectedIndexChanged += new System.EventHandler(this.cbLogFile_SelectedIndexChanged);
            // 
            // btnAddFindFolders
            // 
            this.btnAddFindFolders.Location = new System.Drawing.Point(3, 78);
            this.btnAddFindFolders.Name = "btnAddFindFolders";
            this.btnAddFindFolders.Size = new System.Drawing.Size(129, 23);
            this.btnAddFindFolders.TabIndex = 42;
            this.btnAddFindFolders.Text = "Add Find Folder";
            this.btnAddFindFolders.UseVisualStyleBackColor = true;
            this.btnAddFindFolders.Click += new System.EventHandler(this.btnAddFindFolders_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Find Folders:";
            // 
            // lbFindFolders
            // 
            this.lbFindFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFindFolders.FormattingEnabled = true;
            this.lbFindFolders.Location = new System.Drawing.Point(3, 16);
            this.lbFindFolders.Name = "lbFindFolders";
            this.lbFindFolders.Size = new System.Drawing.Size(270, 56);
            this.lbFindFolders.TabIndex = 40;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Location = new System.Drawing.Point(4, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnLnNumRange);
            this.splitContainer2.Panel1.Controls.Add(this.tbLnNum2);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.tbLnNum1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.btnClearFilter);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddFilter);
            this.splitContainer2.Panel1.Controls.Add(this.rtbFilter);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbContent);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(1039, 709);
            this.splitContainer2.SplitterDistance = 127;
            this.splitContainer2.TabIndex = 2;
            // 
            // btnLnNumRange
            // 
            this.btnLnNumRange.Location = new System.Drawing.Point(267, 87);
            this.btnLnNumRange.Name = "btnLnNumRange";
            this.btnLnNumRange.Size = new System.Drawing.Size(75, 23);
            this.btnLnNumRange.TabIndex = 7;
            this.btnLnNumRange.Text = "Set Range";
            this.btnLnNumRange.UseVisualStyleBackColor = true;
            this.btnLnNumRange.Click += new System.EventHandler(this.btnLnNumRange_Click);
            // 
            // tbLnNum2
            // 
            this.tbLnNum2.Location = new System.Drawing.Point(181, 87);
            this.tbLnNum2.Name = "tbLnNum2";
            this.tbLnNum2.Size = new System.Drawing.Size(79, 20);
            this.tbLnNum2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "to:";
            // 
            // tbLnNum1
            // 
            this.tbLnNum1.Location = new System.Drawing.Point(68, 87);
            this.tbLnNum1.Name = "tbLnNum1";
            this.tbLnNum1.Size = new System.Drawing.Size(79, 20);
            this.tbLnNum1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lines from:";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Location = new System.Drawing.Point(952, 50);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 30);
            this.btnClearFilter.TabIndex = 2;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFilter.Location = new System.Drawing.Point(951, 12);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(75, 31);
            this.btnAddFilter.TabIndex = 1;
            this.btnAddFilter.Text = "Set Filter";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click_1);
            // 
            // rtbFilter
            // 
            this.rtbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFilter.Location = new System.Drawing.Point(3, 16);
            this.rtbFilter.Name = "rtbFilter";
            this.rtbFilter.Size = new System.Drawing.Size(942, 64);
            this.rtbFilter.TabIndex = 0;
            this.rtbFilter.Text = "";
            // 
            // rtbContent
            // 
            this.rtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbContent.Location = new System.Drawing.Point(3, 3);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(1034, 575);
            this.rtbContent.TabIndex = 1;
            this.rtbContent.Text = "";
            // 
            // btnDelFindFolder
            // 
            this.btnDelFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelFindFolder.Location = new System.Drawing.Point(151, 78);
            this.btnDelFindFolder.Name = "btnDelFindFolder";
            this.btnDelFindFolder.Size = new System.Drawing.Size(122, 23);
            this.btnDelFindFolder.TabIndex = 47;
            this.btnDelFindFolder.Text = "Remove Find Folder";
            this.btnDelFindFolder.UseVisualStyleBackColor = true;
            this.btnDelFindFolder.Click += new System.EventHandler(this.btnDelFindFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 878);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.rtLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddFindFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFindFolders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLogFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbClearKeys;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.RichTextBox rtbFilter;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnLnNumRange;
        private System.Windows.Forms.TextBox tbLnNum2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbLnNum1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelFindFolder;
    }
}

