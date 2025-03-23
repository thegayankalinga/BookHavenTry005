namespace BookHavenWinFormUi.PanelForms.Customer
{
    partial class CustomerDetails
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
            lblStock = new Label();
            lblSellingPrice = new Label();
            lblSBN = new Label();
            lblAuthorName = new Label();
            lblBookTitle = new Label();
            txtPhoneNumber = new TextBox();
            txtCity = new TextBox();
            txtAddressLineTwo = new TextBox();
            txtAddressLineOne = new TextBox();
            txtFullName = new TextBox();
            gbBookDetails.SuspendLayout();
            SuspendLayout();
            // 
            // gbBookDetails
            // 
            gbBookDetails.Controls.Add(btnSave);
            gbBookDetails.Controls.Add(btnCancel);
            gbBookDetails.Controls.Add(lblStock);
            gbBookDetails.Controls.Add(lblSellingPrice);
            gbBookDetails.Controls.Add(lblSBN);
            gbBookDetails.Controls.Add(lblAuthorName);
            gbBookDetails.Controls.Add(lblBookTitle);
            gbBookDetails.Controls.Add(txtPhoneNumber);
            gbBookDetails.Controls.Add(txtCity);
            gbBookDetails.Controls.Add(txtAddressLineTwo);
            gbBookDetails.Controls.Add(txtAddressLineOne);
            gbBookDetails.Controls.Add(txtFullName);
            gbBookDetails.ForeColor = SystemColors.ButtonHighlight;
            gbBookDetails.Location = new Point(43, 52);
            gbBookDetails.Name = "gbBookDetails";
            gbBookDetails.Size = new Size(549, 540);
            gbBookDetails.TabIndex = 6;
            gbBookDetails.TabStop = false;
            gbBookDetails.Text = "Customer Details";
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
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(35, 286);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(120, 21);
            lblStock.TabIndex = 0;
            lblStock.Text = "Mobile Number";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(35, 233);
            lblSellingPrice.Margin = new Padding(4, 0, 4, 0);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(37, 21);
            lblSellingPrice.TabIndex = 0;
            lblSellingPrice.Text = "City";
            // 
            // lblSBN
            // 
            lblSBN.AutoSize = true;
            lblSBN.Location = new Point(35, 175);
            lblSBN.Margin = new Padding(4, 0, 4, 0);
            lblSBN.Name = "lblSBN";
            lblSBN.Size = new Size(112, 21);
            lblSBN.TabIndex = 0;
            lblSBN.Text = "Address Line 2";
            // 
            // lblAuthorName
            // 
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(35, 116);
            lblAuthorName.Margin = new Padding(4, 0, 4, 0);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(112, 21);
            lblAuthorName.TabIndex = 0;
            lblAuthorName.Text = "Address Line 1";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Location = new Point(35, 62);
            lblBookTitle.Margin = new Padding(4, 0, 4, 0);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(124, 21);
            lblBookTitle.TabIndex = 0;
            lblBookTitle.Text = "Customer Name";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(176, 283);
            txtPhoneNumber.Margin = new Padding(4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(323, 29);
            txtPhoneNumber.TabIndex = 1;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(176, 230);
            txtCity.Margin = new Padding(4);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(323, 29);
            txtCity.TabIndex = 1;
            // 
            // txtAddressLineTwo
            // 
            txtAddressLineTwo.Location = new Point(176, 172);
            txtAddressLineTwo.Margin = new Padding(4);
            txtAddressLineTwo.Name = "txtAddressLineTwo";
            txtAddressLineTwo.Size = new Size(323, 29);
            txtAddressLineTwo.TabIndex = 1;
            // 
            // txtAddressLineOne
            // 
            txtAddressLineOne.Location = new Point(176, 113);
            txtAddressLineOne.Margin = new Padding(4);
            txtAddressLineOne.Name = "txtAddressLineOne";
            txtAddressLineOne.Size = new Size(323, 29);
            txtAddressLineOne.TabIndex = 1;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(176, 59);
            txtFullName.Margin = new Padding(4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(323, 29);
            txtFullName.TabIndex = 1;
            // 
            // CustomerDetails
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(635, 645);
            Controls.Add(gbBookDetails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "CustomerDetails";
            Text = "CustomerDetails";
            Load += CustomerDetails_Load;
            gbBookDetails.ResumeLayout(false);
            gbBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBookDetails;
        private Button btnSave;
        private Button btnCancel;
        private Label lblStock;
        private Label lblSellingPrice;
        private Label lblSBN;
        private Label lblAuthorName;
        private Label lblBookTitle;
        private TextBox txtPhoneNumber;
        private TextBox txtCity;
        private TextBox txtAddressLineTwo;
        private TextBox txtAddressLineOne;
        private TextBox txtFullName;
    }
}