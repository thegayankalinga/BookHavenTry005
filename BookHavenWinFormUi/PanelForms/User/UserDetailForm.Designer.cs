namespace BookHavenWinFormUi.PanelForms.User
{
    partial class UserDetailForm
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
            gbBookDetails = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            cmbGenreList = new ComboBox();
            lblGenre = new Label();
            lblStock = new Label();
            lblSellingPrice = new Label();
            lblSBN = new Label();
            lblAuthorName = new Label();
            lblBookTitle = new Label();
            txtCurrentStock = new TextBox();
            txtSellingPrice = new TextBox();
            txtISBN = new TextBox();
            txtBookTitle = new TextBox();
            label1 = new Label();
            gbBookDetails.SuspendLayout();
            SuspendLayout();
            // 
            // gbBookDetails
            // 
            gbBookDetails.Controls.Add(btnSave);
            gbBookDetails.Controls.Add(btnCancel);
            gbBookDetails.Controls.Add(cmbGenreList);
            gbBookDetails.Controls.Add(lblGenre);
            gbBookDetails.Controls.Add(lblStock);
            gbBookDetails.Controls.Add(lblSellingPrice);
            gbBookDetails.Controls.Add(lblSBN);
            gbBookDetails.Controls.Add(label1);
            gbBookDetails.Controls.Add(lblAuthorName);
            gbBookDetails.Controls.Add(lblBookTitle);
            gbBookDetails.Controls.Add(txtCurrentStock);
            gbBookDetails.Controls.Add(txtSellingPrice);
            gbBookDetails.Controls.Add(txtISBN);
            gbBookDetails.Controls.Add(txtBookTitle);
            gbBookDetails.ForeColor = SystemColors.ButtonHighlight;
            gbBookDetails.Location = new Point(35, 33);
            gbBookDetails.Name = "gbBookDetails";
            gbBookDetails.Size = new Size(549, 540);
            gbBookDetails.TabIndex = 6;
            gbBookDetails.TabStop = false;
            gbBookDetails.Text = "User Details";
            // 
            // btnSave
            // 
            btnSave.ForeColor = SystemColors.ActiveCaptionText;
            btnSave.Location = new Point(359, 477);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.ForeColor = SystemColors.ActiveCaptionText;
            btnCancel.Location = new Point(190, 477);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 47);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbGenreList
            // 
            cmbGenreList.FormattingEnabled = true;
            cmbGenreList.Location = new Point(176, 338);
            cmbGenreList.Name = "cmbGenreList";
            cmbGenreList.Size = new Size(323, 29);
            cmbGenreList.TabIndex = 3;
            // 
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(35, 341);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(78, 21);
            lblGenre.TabIndex = 0;
            lblGenre.Text = "User Type";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(35, 286);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(84, 21);
            lblStock.TabIndex = 0;
            lblStock.Text = "Last Name";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(35, 233);
            lblSellingPrice.Margin = new Padding(4, 0, 4, 0);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(86, 21);
            lblSellingPrice.TabIndex = 0;
            lblSellingPrice.Text = "First Name";
            // 
            // lblSBN
            // 
            lblSBN.AutoSize = true;
            lblSBN.Location = new Point(35, 175);
            lblSBN.Margin = new Padding(4, 0, 4, 0);
            lblSBN.Name = "lblSBN";
            lblSBN.Size = new Size(76, 21);
            lblSBN.TabIndex = 0;
            lblSBN.Text = "Password";
            // 
            // lblAuthorName
            // 
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(35, 116);
            lblAuthorName.Margin = new Padding(4, 0, 4, 0);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(61, 21);
            lblAuthorName.TabIndex = 0;
            lblAuthorName.Text = "User ID";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(35, 62);
            lblBookTitle.Margin = new Padding(4, 0, 4, 0);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(44, 21);
            lblBookTitle.TabIndex = 0;
            lblBookTitle.Text = "Emai";
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(309, 283);
            txtCurrentStock.Margin = new Padding(4);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.Size = new Size(190, 29);
            txtCurrentStock.TabIndex = 1;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(309, 230);
            txtSellingPrice.Margin = new Padding(4);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(190, 29);
            txtSellingPrice.TabIndex = 1;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(176, 172);
            txtISBN.Margin = new Padding(4);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(323, 29);
            txtISBN.TabIndex = 1;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(176, 59);
            txtBookTitle.Margin = new Padding(4);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(323, 29);
            txtBookTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 116);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 0;
            label1.Text = "User ID";
            // 
            // UserDetailForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(619, 606);
            Controls.Add(gbBookDetails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "UserDetailForm";
            Text = "UserDetailForm";
            gbBookDetails.ResumeLayout(false);
            gbBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBookDetails;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox cmbGenreList;
        private Label lblGenre;
        private Label lblStock;
        private Label lblSellingPrice;
        private Label lblSBN;
        private Label lblAuthorName;
        private Label lblBookTitle;
        private TextBox txtCurrentStock;
        private TextBox txtSellingPrice;
        private TextBox txtISBN;
        private TextBox txtBookTitle;
        private Label label1;
    }
}