namespace BookHavenWinFormUi.PanelForms.Reports
{
    partial class Report
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            cboReportType = new ComboBox();
            dtToDate = new DateTimePicker();
            dtFromDate = new DateTimePicker();
            lblGenre = new Label();
            lblAuthor = new Label();
            cboUser = new ComboBox();
            btnResetFilter = new Button();
            btnSearch = new Button();
            lblSearchKey = new Label();
            dgvReportData = new DataGridView();
            groupBox2 = new GroupBox();
            lblTotalValue = new Label();
            label3 = new Label();
            lblNoOfItems = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportData).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cboReportType);
            groupBox1.Controls.Add(dtToDate);
            groupBox1.Controls.Add(dtFromDate);
            groupBox1.Controls.Add(lblGenre);
            groupBox1.Controls.Add(lblAuthor);
            groupBox1.Controls.Add(cboUser);
            groupBox1.Controls.Add(btnResetFilter);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(lblSearchKey);
            groupBox1.ForeColor = SystemColors.ControlDark;
            groupBox1.Location = new Point(74, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(922, 148);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(6, 91);
            label5.Name = "label5";
            label5.Size = new Size(93, 21);
            label5.TabIndex = 9;
            label5.Text = "Report Type";
            // 
            // cboReportType
            // 
            cboReportType.FormattingEnabled = true;
            cboReportType.Location = new Point(113, 90);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(246, 29);
            cboReportType.TabIndex = 8;
            // 
            // dtToDate
            // 
            dtToDate.Location = new Point(527, 33);
            dtToDate.Name = "dtToDate";
            dtToDate.Size = new Size(282, 29);
            dtToDate.TabIndex = 7;
            // 
            // dtFromDate
            // 
            dtFromDate.Location = new Point(103, 33);
            dtFromDate.Name = "dtFromDate";
            dtFromDate.Size = new Size(294, 29);
            dtFromDate.TabIndex = 7;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.ForeColor = SystemColors.ButtonHighlight;
            lblGenre.Location = new Point(380, 93);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(42, 21);
            lblGenre.TabIndex = 6;
            lblGenre.Text = "User";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = SystemColors.ButtonHighlight;
            lblAuthor.Location = new Point(428, 38);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(61, 21);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "To Date";
            // 
            // cboUser
            // 
            cboUser.FormattingEnabled = true;
            cboUser.Location = new Point(428, 90);
            cboUser.Name = "cboUser";
            cboUser.Size = new Size(183, 29);
            cboUser.TabIndex = 5;
            // 
            // btnResetFilter
            // 
            btnResetFilter.ForeColor = SystemColors.ActiveCaptionText;
            btnResetFilter.Location = new Point(634, 83);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(123, 40);
            btnResetFilter.TabIndex = 2;
            btnResetFilter.Text = "Reset";
            btnResetFilter.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.ForeColor = SystemColors.ActiveCaptionText;
            btnSearch.Location = new Point(773, 83);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(123, 40);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblSearchKey
            // 
            lblSearchKey.AutoSize = true;
            lblSearchKey.ForeColor = SystemColors.ButtonHighlight;
            lblSearchKey.Location = new Point(6, 38);
            lblSearchKey.Name = "lblSearchKey";
            lblSearchKey.Size = new Size(83, 21);
            lblSearchKey.TabIndex = 3;
            lblSearchKey.Text = "From Date";
            // 
            // dgvReportData
            // 
            dgvReportData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportData.Location = new Point(74, 175);
            dgvReportData.MultiSelect = false;
            dgvReportData.Name = "dgvReportData";
            dgvReportData.RowHeadersVisible = false;
            dgvReportData.Size = new Size(922, 424);
            dgvReportData.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblTotalValue);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lblNoOfItems);
            groupBox2.Controls.Add(label1);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(74, 620);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(922, 67);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Total Value";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(367, 34);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(40, 21);
            lblTotalValue.TabIndex = 0;
            lblTotalValue.Text = "0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(241, 34);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 0;
            label3.Text = "Total Value";
            // 
            // lblNoOfItems
            // 
            lblNoOfItems.AutoSize = true;
            lblNoOfItems.Location = new Point(140, 34);
            lblNoOfItems.Name = "lblNoOfItems";
            lblNoOfItems.Size = new Size(19, 21);
            lblNoOfItems.TabIndex = 0;
            lblNoOfItems.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 34);
            label1.Name = "label1";
            label1.Size = new Size(91, 21);
            label1.TabIndex = 0;
            label1.Text = "No of Items";
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1062, 720);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvReportData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Report";
            Text = "Report";
            Load += Report_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportData).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblGenre;
        private Label lblAuthor;
        private ComboBox cboUser;
        private Button btnResetFilter;
        private Button btnSearch;
        private Label lblSearchKey;
        private DataGridView dgvReportData;
        private DateTimePicker dtToDate;
        private DateTimePicker dtFromDate;
        private GroupBox groupBox2;
        private Label lblTotalValue;
        private Label label3;
        private Label lblNoOfItems;
        private Label label1;
        private ComboBox cboReportType;
        private Label label5;
    }
}