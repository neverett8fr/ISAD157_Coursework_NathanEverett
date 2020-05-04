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
            this.CMBTableSelect = new System.Windows.Forms.ComboBox();
            this.DGVTableview = new System.Windows.Forms.DataGridView();
            this.RTBProfile = new System.Windows.Forms.RichTextBox();
            this.TBCDataViews = new System.Windows.Forms.TabControl();
            this.TBPProfilePage = new System.Windows.Forms.TabPage();
            this.TBPQuery = new System.Windows.Forms.TabPage();
            this.BTNLoadCSV = new System.Windows.Forms.Button();
            this.OFDLoadExcel = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVQueryTable = new System.Windows.Forms.DataGridView();
            this.CMBTableSelectQuery = new System.Windows.Forms.ComboBox();
            this.CMBQueryCondition = new System.Windows.Forms.ComboBox();
            this.TXTQueryCondition = new System.Windows.Forms.TextBox();
            this.BTNQuerySubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CMBQueryColumn = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTableview)).BeginInit();
            this.TBCDataViews.SuspendLayout();
            this.TBPProfilePage.SuspendLayout();
            this.TBPQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQueryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNSelectDataSource
            // 
            this.BTNSelectDataSource.Location = new System.Drawing.Point(16, 12);
            this.BTNSelectDataSource.Name = "BTNSelectDataSource";
            this.BTNSelectDataSource.Size = new System.Drawing.Size(171, 37);
            this.BTNSelectDataSource.TabIndex = 0;
            this.BTNSelectDataSource.Text = "Select Data Source";
            this.BTNSelectDataSource.UseVisualStyleBackColor = true;
            this.BTNSelectDataSource.Click += new System.EventHandler(this.BTNSelectDataSource_Click);
            // 
            // CMBTableSelect
            // 
            this.CMBTableSelect.FormattingEnabled = true;
            this.CMBTableSelect.Location = new System.Drawing.Point(374, 17);
            this.CMBTableSelect.Name = "CMBTableSelect";
            this.CMBTableSelect.Size = new System.Drawing.Size(158, 28);
            this.CMBTableSelect.TabIndex = 2;
            this.CMBTableSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DGVTableview
            // 
            this.DGVTableview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTableview.Location = new System.Drawing.Point(16, 55);
            this.DGVTableview.Name = "DGVTableview";
            this.DGVTableview.RowHeadersWidth = 62;
            this.DGVTableview.RowTemplate.Height = 28;
            this.DGVTableview.Size = new System.Drawing.Size(516, 531);
            this.DGVTableview.TabIndex = 4;
            this.DGVTableview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTableview_CellContentClick);
            // 
            // RTBProfile
            // 
            this.RTBProfile.Location = new System.Drawing.Point(6, 47);
            this.RTBProfile.Name = "RTBProfile";
            this.RTBProfile.Size = new System.Drawing.Size(525, 477);
            this.RTBProfile.TabIndex = 5;
            this.RTBProfile.Text = "";
            // 
            // TBCDataViews
            // 
            this.TBCDataViews.Controls.Add(this.TBPProfilePage);
            this.TBCDataViews.Controls.Add(this.TBPQuery);
            this.TBCDataViews.Location = new System.Drawing.Point(538, 12);
            this.TBCDataViews.Name = "TBCDataViews";
            this.TBCDataViews.SelectedIndex = 0;
            this.TBCDataViews.Size = new System.Drawing.Size(545, 577);
            this.TBCDataViews.TabIndex = 6;
            // 
            // TBPProfilePage
            // 
            this.TBPProfilePage.Controls.Add(this.label1);
            this.TBPProfilePage.Controls.Add(this.RTBProfile);
            this.TBPProfilePage.Location = new System.Drawing.Point(4, 29);
            this.TBPProfilePage.Name = "TBPProfilePage";
            this.TBPProfilePage.Padding = new System.Windows.Forms.Padding(3);
            this.TBPProfilePage.Size = new System.Drawing.Size(537, 544);
            this.TBPProfilePage.TabIndex = 0;
            this.TBPProfilePage.Text = "Profile";
            this.TBPProfilePage.UseVisualStyleBackColor = true;
            // 
            // TBPQuery
            // 
            this.TBPQuery.Controls.Add(this.label5);
            this.TBPQuery.Controls.Add(this.CMBQueryColumn);
            this.TBPQuery.Controls.Add(this.label4);
            this.TBPQuery.Controls.Add(this.label3);
            this.TBPQuery.Controls.Add(this.label2);
            this.TBPQuery.Controls.Add(this.BTNQuerySubmit);
            this.TBPQuery.Controls.Add(this.TXTQueryCondition);
            this.TBPQuery.Controls.Add(this.CMBQueryCondition);
            this.TBPQuery.Controls.Add(this.CMBTableSelectQuery);
            this.TBPQuery.Controls.Add(this.DGVQueryTable);
            this.TBPQuery.Location = new System.Drawing.Point(4, 29);
            this.TBPQuery.Name = "TBPQuery";
            this.TBPQuery.Padding = new System.Windows.Forms.Padding(3);
            this.TBPQuery.Size = new System.Drawing.Size(537, 544);
            this.TBPQuery.TabIndex = 1;
            this.TBPQuery.Text = "Query";
            this.TBPQuery.UseVisualStyleBackColor = true;
            // 
            // BTNLoadCSV
            // 
            this.BTNLoadCSV.Location = new System.Drawing.Point(195, 12);
            this.BTNLoadCSV.Name = "BTNLoadCSV";
            this.BTNLoadCSV.Size = new System.Drawing.Size(171, 37);
            this.BTNLoadCSV.TabIndex = 1;
            this.BTNLoadCSV.Text = "Load From CSV";
            this.BTNLoadCSV.UseVisualStyleBackColor = true;
            this.BTNLoadCSV.Click += new System.EventHandler(this.BTNLoadCSV_Click);
            // 
            // OFDLoadExcel
            // 
            this.OFDLoadExcel.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Profile";
            // 
            // DGVQueryTable
            // 
            this.DGVQueryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVQueryTable.Location = new System.Drawing.Point(6, 64);
            this.DGVQueryTable.Name = "DGVQueryTable";
            this.DGVQueryTable.RowHeadersWidth = 62;
            this.DGVQueryTable.RowTemplate.Height = 28;
            this.DGVQueryTable.Size = new System.Drawing.Size(525, 474);
            this.DGVQueryTable.TabIndex = 7;
            // 
            // CMBTableSelectQuery
            // 
            this.CMBTableSelectQuery.FormattingEnabled = true;
            this.CMBTableSelectQuery.Location = new System.Drawing.Point(6, 32);
            this.CMBTableSelectQuery.Name = "CMBTableSelectQuery";
            this.CMBTableSelectQuery.Size = new System.Drawing.Size(100, 28);
            this.CMBTableSelectQuery.TabIndex = 8;
            this.CMBTableSelectQuery.SelectedIndexChanged += new System.EventHandler(this.CMBTableSelectQuery_SelectedIndexChanged);
            // 
            // CMBQueryCondition
            // 
            this.CMBQueryCondition.FormattingEnabled = true;
            this.CMBQueryCondition.Items.AddRange(new object[] {
            "=",
            ">",
            "<"});
            this.CMBQueryCondition.Location = new System.Drawing.Point(218, 32);
            this.CMBQueryCondition.Name = "CMBQueryCondition";
            this.CMBQueryCondition.Size = new System.Drawing.Size(100, 28);
            this.CMBQueryCondition.TabIndex = 9;
            // 
            // TXTQueryCondition
            // 
            this.TXTQueryCondition.Location = new System.Drawing.Point(324, 34);
            this.TXTQueryCondition.Name = "TXTQueryCondition";
            this.TXTQueryCondition.Size = new System.Drawing.Size(100, 26);
            this.TXTQueryCondition.TabIndex = 10;
            // 
            // BTNQuerySubmit
            // 
            this.BTNQuerySubmit.Location = new System.Drawing.Point(468, 6);
            this.BTNQuerySubmit.Name = "BTNQuerySubmit";
            this.BTNQuerySubmit.Size = new System.Drawing.Size(63, 52);
            this.BTNQuerySubmit.TabIndex = 11;
            this.BTNQuerySubmit.Text = "Go";
            this.BTNQuerySubmit.UseVisualStyleBackColor = true;
            this.BTNQuerySubmit.Click += new System.EventHandler(this.BTNQuerySubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Table: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Condition: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Enter info:";
            // 
            // CMBQueryColumn
            // 
            this.CMBQueryColumn.FormattingEnabled = true;
            this.CMBQueryColumn.Location = new System.Drawing.Point(112, 32);
            this.CMBQueryColumn.Name = "CMBQueryColumn";
            this.CMBQueryColumn.Size = new System.Drawing.Size(100, 28);
            this.CMBQueryColumn.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Column:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 601);
            this.Controls.Add(this.BTNLoadCSV);
            this.Controls.Add(this.TBCDataViews);
            this.Controls.Add(this.DGVTableview);
            this.Controls.Add(this.CMBTableSelect);
            this.Controls.Add(this.BTNSelectDataSource);
            this.Name = "Form1";
            this.Text = "Admin Views - Facebook Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVTableview)).EndInit();
            this.TBCDataViews.ResumeLayout(false);
            this.TBPProfilePage.ResumeLayout(false);
            this.TBPProfilePage.PerformLayout();
            this.TBPQuery.ResumeLayout(false);
            this.TBPQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVQueryTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTNSelectDataSource;
        private System.Windows.Forms.ComboBox CMBTableSelect;
        private System.Windows.Forms.DataGridView DGVTableview;
        private System.Windows.Forms.RichTextBox RTBProfile;
        private System.Windows.Forms.TabControl TBCDataViews;
        private System.Windows.Forms.TabPage TBPProfilePage;
        private System.Windows.Forms.TabPage TBPQuery;
        private System.Windows.Forms.OpenFileDialog OFDLoadExcel;
        private System.Windows.Forms.Button BTNLoadCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNQuerySubmit;
        private System.Windows.Forms.TextBox TXTQueryCondition;
        private System.Windows.Forms.ComboBox CMBQueryCondition;
        private System.Windows.Forms.ComboBox CMBTableSelectQuery;
        private System.Windows.Forms.DataGridView DGVQueryTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CMBQueryColumn;
    }
}

