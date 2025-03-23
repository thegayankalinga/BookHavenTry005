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
            lblGenre = new Label();
            lblAuthor = new Label();
            cmbGenre = new ComboBox();
            btnResetFilter = new Button();
            btnSearch = new Button();
            lblSearchKey = new Label();
            gridViewBookList = new DataGridView();
            groupBox2 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(lblGenre);
            groupBox1.Controls.Add(lblAuthor);
            groupBox1.Controls.Add(cmbGenre);
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
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.ForeColor = SystemColors.ButtonHighlight;
            lblGenre.Location = new Point(643, 33);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(42, 21);
            lblGenre.TabIndex = 6;
            lblGenre.Text = "User";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = SystemColors.ButtonHighlight;
            lblAuthor.Location = new Point(333, 33);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(61, 21);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "To Date";
            // 
            // cmbGenre
            // 
            cmbGenre.FormattingEnabled = true;
            cmbGenre.Location = new Point(713, 30);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(183, 29);
            cmbGenre.TabIndex = 5;
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
            // 
            // lblSearchKey
            // 
            lblSearchKey.AutoSize = true;
            lblSearchKey.ForeColor = SystemColors.ButtonHighlight;
            lblSearchKey.Location = new Point(14, 33);
            lblSearchKey.Name = "lblSearchKey";
            lblSearchKey.Size = new Size(83, 21);
            lblSearchKey.TabIndex = 3;
            lblSearchKey.Text = "From Date";
            // 
            // gridViewBookList
            // 
            gridViewBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewBookList.Location = new Point(74, 175);
            gridViewBookList.MultiSelect = false;
            gridViewBookList.Name = "gridViewBookList";
            gridViewBookList.RowHeadersVisible = false;
            gridViewBookList.Size = new Size(922, 424);
            gridViewBookList.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(74, 620);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(922, 67);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Total Value";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 34);
            label2.Name = "label2";
            label2.Size = new Size(19, 21);
            label2.TabIndex = 0;
            label2.Text = "0";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(367, 34);
            label4.Name = "label4";
            label4.Size = new Size(40, 21);
            label4.TabIndex = 0;
            label4.Text = "0.00";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(103, 33);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(212, 29);
            dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(411, 33);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 29);
            dateTimePicker2.TabIndex = 7;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1062, 720);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(gridViewBookList);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Report";
            Text = "Report";
            Load += Report_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblGenre;
        private Label lblAuthor;
        private ComboBox cmbGenre;
        private Button btnResetFilter;
        private Button btnSearch;
        private Label lblSearchKey;
        private DataGridView gridViewBookList;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}