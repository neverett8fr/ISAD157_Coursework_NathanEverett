namespace ISAD157_Coursework_NathanEverett
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
            this.BTNSelectDataSource = new System.Windows.Forms.Button();
            this.TXTSourceName = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DGVTableview = new System.Windows.Forms.DataGridView();
            this.RTBProfile = new System.Windows.Forms.RichTextBox();
            this.TBCDataViews = new System.Windows.Forms.TabControl();
            this.TBPProfilePage = new System.Windows.Forms.TabPage();
            this.TBPSummary = new System.Windows.Forms.TabPage();
            this.TBPEditData = new System.Windows.Forms.TabPage();
            this.BTNUploadGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTableview)).BeginInit();
            this.TBCDataViews.SuspendLayout();
            this.TBPProfilePage.SuspendLayout();
            this.TBPEditData.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTNSelectDataSource
            // 
            this.BTNSelectDataSource.Location = new System.Drawing.Point(228, 14);
            this.BTNSelectDataSource.Name = "BTNSelectDataSource";
            this.BTNSelectDataSource.Size = new System.Drawing.Size(86, 26);
            this.BTNSelectDataSource.TabIndex = 0;
            this.BTNSelectDataSource.Text = "Select Data Source";
            this.BTNSelectDataSource.UseVisualStyleBackColor = true;
            this.BTNSelectDataSource.Click += new System.EventHandler(this.BTNSelectDataSource_Click);
            // 
            // TXTSourceName
            // 
            this.TXTSourceName.Location = new System.Drawing.Point(12, 14);
            this.TXTSourceName.Name = "TXTSourceName";
            this.TXTSourceName.Size = new System.Drawing.Size(210, 26);
            this.TXTSourceName.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(320, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(208, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // DGVTableview
            // 
            this.DGVTableview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTableview.Location = new System.Drawing.Point(12, 46);
            this.DGVTableview.Name = "DGVTableview";
            this.DGVTableview.RowHeadersWidth = 62;
            this.DGVTableview.RowTemplate.Height = 28;
            this.DGVTableview.Size = new System.Drawing.Size(516, 543);
            this.DGVTableview.TabIndex = 4;
            // 
            // RTBProfile
            // 
            this.RTBProfile.Location = new System.Drawing.Point(6, 47);
            this.RTBProfile.Name = "RTBProfile";
            this.RTBProfile.Size = new System.Drawing.Size(525, 489);
            this.RTBProfile.TabIndex = 5;
            this.RTBProfile.Text = "";
            // 
            // TBCDataViews
            // 
            this.TBCDataViews.Controls.Add(this.TBPProfilePage);
            this.TBCDataViews.Controls.Add(this.TBPSummary);
            this.TBCDataViews.Controls.Add(this.TBPEditData);
            this.TBCDataViews.Location = new System.Drawing.Point(534, 14);
            this.TBCDataViews.Name = "TBCDataViews";
            this.TBCDataViews.SelectedIndex = 0;
            this.TBCDataViews.Size = new System.Drawing.Size(545, 575);
            this.TBCDataViews.TabIndex = 6;
            // 
            // TBPProfilePage
            // 
            this.TBPProfilePage.Controls.Add(this.RTBProfile);
            this.TBPProfilePage.Location = new System.Drawing.Point(4, 29);
            this.TBPProfilePage.Name = "TBPProfilePage";
            this.TBPProfilePage.Padding = new System.Windows.Forms.Padding(3);
            this.TBPProfilePage.Size = new System.Drawing.Size(537, 542);
            this.TBPProfilePage.TabIndex = 0;
            this.TBPProfilePage.Text = "Profile";
            this.TBPProfilePage.UseVisualStyleBackColor = true;
            // 
            // TBPSummary
            // 
            this.TBPSummary.Location = new System.Drawing.Point(4, 29);
            this.TBPSummary.Name = "TBPSummary";
            this.TBPSummary.Padding = new System.Windows.Forms.Padding(3);
            this.TBPSummary.Size = new System.Drawing.Size(537, 542);
            this.TBPSummary.TabIndex = 1;
            this.TBPSummary.Text = "Summary";
            this.TBPSummary.UseVisualStyleBackColor = true;
            // 
            // TBPEditData
            // 
            this.TBPEditData.Controls.Add(this.BTNUploadGroup);
            this.TBPEditData.Location = new System.Drawing.Point(4, 29);
            this.TBPEditData.Name = "TBPEditData";
            this.TBPEditData.Size = new System.Drawing.Size(537, 542);
            this.TBPEditData.TabIndex = 2;
            this.TBPEditData.Text = "Edit / Add Data";
            this.TBPEditData.UseVisualStyleBackColor = true;
            // 
            // BTNUploadGroup
            // 
            this.BTNUploadGroup.Location = new System.Drawing.Point(440, 25);
            this.BTNUploadGroup.Name = "BTNUploadGroup";
            this.BTNUploadGroup.Size = new System.Drawing.Size(75, 23);
            this.BTNUploadGroup.TabIndex = 0;
            this.BTNUploadGroup.Text = "Group";
            this.BTNUploadGroup.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 601);
            this.Controls.Add(this.TBCDataViews);
            this.Controls.Add(this.DGVTableview);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TXTSourceName);
            this.Controls.Add(this.BTNSelectDataSource);
            this.Name = "Form1";
            this.Text = "Admin Views - Facebook Data";
            ((System.ComponentModel.ISupportInitialize)(this.DGVTableview)).EndInit();
            this.TBCDataViews.ResumeLayout(false);
            this.TBPProfilePage.ResumeLayout(false);
            this.TBPEditData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNSelectDataSource;
        private System.Windows.Forms.TextBox TXTSourceName;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView DGVTableview;
        private System.Windows.Forms.RichTextBox RTBProfile;
        private System.Windows.Forms.TabControl TBCDataViews;
        private System.Windows.Forms.TabPage TBPProfilePage;
        private System.Windows.Forms.TabPage TBPSummary;
        private System.Windows.Forms.TabPage TBPEditData;
        private System.Windows.Forms.Button BTNUploadGroup;
    }
}

