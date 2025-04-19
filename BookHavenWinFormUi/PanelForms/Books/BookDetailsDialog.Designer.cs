namespace BookHavenWinFormUi.PanelForms.Books
{
    partial class BookDetailsDialog
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
            components = new System.ComponentModel.Container();
            lblBookTitle = new Label();
            txtBookTitle = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cmbGenreList = new ComboBox();
            btnCancel = new Button();
            gbBookDetails = new GroupBox();
            cbAddAnother = new CheckBox();
            btnSave = new Button();
            lblGenre = new Label();
            lblStock = new Label();
            lblSellingPrice = new Label();
            lblSBN = new Label();
            lblAuthorName = new Label();
            txtCurrentStock = new TextBox();
            txtSellingPrice = new TextBox();
            txtISBN = new TextBox();
            txtAuthorName = new TextBox();
            gbBookDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(35, 62);
            lblBookTitle.Margin = new Padding(4, 0, 4, 0);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(78, 21);
            lblBookTitle.TabIndex = 0;
            lblBookTitle.Text = "Book Title";
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(176, 59);
            txtBookTitle.Margin = new Padding(4);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(323, 29);
            txtBookTitle.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cmbGenreList
            // 
            cmbGenreList.FormattingEnabled = true;
            cmbGenreList.Location = new Point(176, 338);
            cmbGenreList.Name = "cmbGenreList";
            cmbGenreList.Size = new Size(323, 29);
            cmbGenreList.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.ForeColor = SystemColors.ActiveCaptionText;
            btnCancel.Location = new Point(190, 477);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 47);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // gbBookDetails
            // 
            gbBookDetails.Controls.Add(cbAddAnother);
            gbBookDetails.Controls.Add(btnSave);
            gbBookDetails.Controls.Add(btnCancel);
            gbBookDetails.Controls.Add(cmbGenreList);
            gbBookDetails.Controls.Add(lblGenre);
            gbBookDetails.Controls.Add(lblStock);
            gbBookDetails.Controls.Add(lblSellingPrice);
            gbBookDetails.Controls.Add(lblSBN);
            gbBookDetails.Controls.Add(lblAuthorName);
            gbBookDetails.Controls.Add(lblBookTitle);
            gbBookDetails.Controls.Add(txtCurrentStock);
            gbBookDetails.Controls.Add(txtSellingPrice);
            gbBookDetails.Controls.Add(txtISBN);
            gbBookDetails.Controls.Add(txtAuthorName);
            gbBookDetails.Controls.Add(txtBookTitle);
            gbBookDetails.ForeColor = SystemColors.ButtonHighlight;
            gbBookDetails.Location = new Point(33, 34);
            gbBookDetails.Name = "gbBookDetails";
            gbBookDetails.Size = new Size(549, 540);
            gbBookDetails.TabIndex = 5;
            gbBookDetails.TabStop = false;
            gbBookDetails.Text = "Book Details";
            // 
            // cbAddAnother
            // 
            cbAddAnother.AutoSize = true;
            cbAddAnother.Location = new Point(382, 398);
            cbAddAnother.Name = "cbAddAnother";
            cbAddAnother.Size = new Size(117, 25);
            cbAddAnother.TabIndex = 7;
            cbAddAnother.Text = "Add Another";
            cbAddAnother.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(359, 477);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 47);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(35, 341);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(52, 21);
            lblGenre.TabIndex = 0;
            lblGenre.Text = "Genre";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(35, 286);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(104, 21);
            lblStock.TabIndex = 0;
            lblStock.Text = "Current Stock";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(35, 233);
            lblSellingPrice.Margin = new Padding(4, 0, 4, 0);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(95, 21);
            lblSellingPrice.TabIndex = 0;
            lblSellingPrice.Text = "Selling Price";
            // 
            // lblSBN
            // 
            lblSBN.AutoSize = true;
            lblSBN.Location = new Point(35, 175);
            lblSBN.Margin = new Padding(4, 0, 4, 0);
            lblSBN.Name = "lblSBN";
            lblSBN.Size = new Size(44, 21);
            lblSBN.TabIndex = 0;
            lblSBN.Text = "ISBN";
            // 
            // lblAuthorName
            // 
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(35, 116);
            lblAuthorName.Margin = new Padding(4, 0, 4, 0);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(104, 21);
            lblAuthorName.TabIndex = 0;
            lblAuthorName.Text = "Author Name";
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(309, 283);
            txtCurrentStock.Margin = new Padding(4);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.Size = new Size(190, 29);
            txtCurrentStock.TabIndex = 5;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(309, 230);
            txtSellingPrice.Margin = new Padding(4);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(190, 29);
            txtSellingPrice.TabIndex = 4;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(176, 172);
            txtISBN.Margin = new Padding(4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(323, 29);
            txtISBN.TabIndex = 3;
            // 
            // txtAuthorName
            // 
            txtAuthorName.Location = new Point(176, 113);
            txtAuthorName.Margin = new Padding(4);
            txtAuthorName.Name = "txtAuthorName";
            txtAuthorName.Size = new Size(323, 29);
            txtAuthorName.TabIndex = 2;
            // 
            // BookDetailsDialog
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(619, 606);
            Controls.Add(gbBookDetails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "BookDetailsDialog";
            Text = "Add New Book";
            Load += BookDetailsDialog_Load;
            gbBookDetails.ResumeLayout(false);
            gbBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBookTitle;
        private TextBox txtBookTitle;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox cmbGenreList;
        private Button btnCancel;
        private GroupBox gbBookDetails;
        private Button btnSave;
        private Label lblGenre;
        private Label lblStock;
        private Label lblSellingPrice;
        private Label lblSBN;
        private Label lblAuthorName;
        private TextBox txtCurrentStock;
        private TextBox txtSellingPrice;
        private TextBox txtISBN;
        private TextBox txtAuthorName;
        private CheckBox cbAddAnother;
    }
}