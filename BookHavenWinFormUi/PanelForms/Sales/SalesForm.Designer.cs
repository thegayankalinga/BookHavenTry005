namespace BookHavenWinFormUi.PanelForms.Customer
{
    partial class SalesForm
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
            groupBox2 = new GroupBox();
            btnEditBook = new Button();
            btnDeleteBook = new Button();
            btnAddNewBook = new Button();
            groupBox1 = new GroupBox();
            btnResetFilter = new Button();
            btnSearch = new Button();
            txtSearchKey = new TextBox();
            lblSearchKey = new Label();
            gridViewBookList = new DataGridView();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEditBook);
            groupBox2.Controls.Add(btnDeleteBook);
            groupBox2.Controls.Add(btnAddNewBook);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(75, 595);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(917, 104);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Actions";
            // 
            // btnEditBook
            // 
            btnEditBook.ForeColor = SystemColors.ActiveCaptionText;
            btnEditBook.Location = new Point(172, 41);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(123, 40);
            btnEditBook.TabIndex = 2;
            btnEditBook.Text = "Edit";
            btnEditBook.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteBook.Location = new Point(328, 41);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(123, 40);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Delete";
            btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnAddNewBook
            // 
            btnAddNewBook.ForeColor = SystemColors.ActiveCaptionText;
            btnAddNewBook.Location = new Point(21, 41);
            btnAddNewBook.Name = "btnAddNewBook";
            btnAddNewBook.Size = new Size(123, 40);
            btnAddNewBook.TabIndex = 2;
            btnAddNewBook.Text = "New Sale";
            btnAddNewBook.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnResetFilter);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearchKey);
            groupBox1.Controls.Add(lblSearchKey);
            groupBox1.ForeColor = SystemColors.ControlDark;
            groupBox1.Location = new Point(70, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(922, 129);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
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
            // txtSearchKey
            // 
            txtSearchKey.Location = new Point(94, 30);
            txtSearchKey.Name = "txtSearchKey";
            txtSearchKey.Size = new Size(211, 29);
            txtSearchKey.TabIndex = 4;
            // 
            // lblSearchKey
            // 
            lblSearchKey.AutoSize = true;
            lblSearchKey.ForeColor = SystemColors.ButtonHighlight;
            lblSearchKey.Location = new Point(14, 33);
            lblSearchKey.Name = "lblSearchKey";
            lblSearchKey.Size = new Size(57, 21);
            lblSearchKey.TabIndex = 3;
            lblSearchKey.Text = "Search";
            // 
            // gridViewBookList
            // 
            gridViewBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewBookList.Location = new Point(70, 169);
            gridViewBookList.MultiSelect = false;
            gridViewBookList.Name = "gridViewBookList";
            gridViewBookList.RowHeadersVisible = false;
            gridViewBookList.Size = new Size(922, 420);
            gridViewBookList.TabIndex = 9;
            // 
            // SaleRequestForm
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
            Name = "SaleRequestForm";
            Text = "SaleRequestForm";
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnEditBook;
        private Button btnDeleteBook;
        private Button btnAddNewBook;
        private GroupBox groupBox1;
        private Button btnResetFilter;
        private Button btnSearch;
        private TextBox txtSearchKey;
        private Label lblSearchKey;
        private DataGridView gridViewBookList;
    }
}