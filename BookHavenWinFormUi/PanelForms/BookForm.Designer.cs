namespace BookHavenWinFormUi.PanelForms
{
    partial class BookForm
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
            gridViewBookList = new DataGridView();
            btnSaveBook = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtBookTitle = new TextBox();
            this.txtAuthorName = new TextBox();
            this.txtISBN = new TextBox();
            this.txtSellingPrice = new TextBox();
            btnDeleteBook = new Button();
            btnEditBook = new Button();
            btnAddBookStock = new Button();
            label5 = new Label();
            txtCurrentStock = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.txtSellingPrice);
            groupBox1.Controls.Add(txtCurrentStock);
            groupBox1.Controls.Add(this.txtISBN);
            groupBox1.Controls.Add(this.txtAuthorName);
            groupBox1.Controls.Add(txtBookTitle);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = SystemColors.ButtonFace;
            groupBox1.Location = new Point(51, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 391);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Book Record";
            // 
            // gridViewBookList
            // 
            gridViewBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewBookList.Location = new Point(506, 55);
            gridViewBookList.Name = "gridViewBookList";
            gridViewBookList.Size = new Size(521, 502);
            gridViewBookList.TabIndex = 1;
            // 
            // btnSaveBook
            // 
            btnSaveBook.Location = new Point(340, 473);
            btnSaveBook.Name = "btnSaveBook";
            btnSaveBook.Size = new Size(123, 40);
            btnSaveBook.TabIndex = 2;
            btnSaveBook.Text = "Save";
            btnSaveBook.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 59);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 0;
            label1.Text = "Book Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 105);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 0;
            label2.Text = "Author Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 153);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 0;
            label3.Text = "ISBN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 200);
            label4.Name = "label4";
            label4.Size = new Size(136, 21);
            label4.TabIndex = 0;
            label4.Text = "Selling Price [LKR]";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(161, 61);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(245, 29);
            txtBookTitle.TabIndex = 1;
            // 
            // txtAuthorName
            // 
            this.txtAuthorName.Location = new Point(161, 102);
            this.txtAuthorName.Name = "txtAuthorName";
            this.txtAuthorName.Size = new Size(245, 29);
            this.txtAuthorName.TabIndex = 1;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new Point(161, 150);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new Size(245, 29);
            this.txtISBN.TabIndex = 1;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Location = new Point(203, 197);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new Size(203, 29);
            this.txtSellingPrice.TabIndex = 1;
            this.txtSellingPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(904, 599);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(123, 40);
            btnDeleteBook.TabIndex = 2;
            btnDeleteBook.Text = "Delete";
            btnDeleteBook.UseVisualStyleBackColor = true;
            // 
            // btnEditBook
            // 
            btnEditBook.Location = new Point(762, 599);
            btnEditBook.Name = "btnEditBook";
            btnEditBook.Size = new Size(123, 40);
            btnEditBook.TabIndex = 2;
            btnEditBook.Text = "Edit";
            btnEditBook.UseVisualStyleBackColor = true;
            // 
            // btnAddBookStock
            // 
            btnAddBookStock.Location = new Point(610, 599);
            btnAddBookStock.Name = "btnAddBookStock";
            btnAddBookStock.Size = new Size(123, 40);
            btnAddBookStock.TabIndex = 2;
            btnAddBookStock.Text = "Add Stock";
            btnAddBookStock.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 255);
            label5.Name = "label5";
            label5.Size = new Size(104, 21);
            label5.TabIndex = 0;
            label5.Text = "Current Stock";
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(161, 252);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.Size = new Size(245, 29);
            txtCurrentStock.TabIndex = 1;
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1132, 651);
            Controls.Add(btnEditBook);
            Controls.Add(btnDeleteBook);
            Controls.Add(btnAddBookStock);
            Controls.Add(btnSaveBook);
            Controls.Add(gridViewBookList);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "BookForm";
            Text = "BookForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewBookList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView gridViewBookList;
        private Button btnSaveBook;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txtBookTitle;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtCurrentStock;
        private Label label5;
        private Button btnDeleteBook;
        private Button btnEditBook;
        private Button btnAddBookStock;
    }
}