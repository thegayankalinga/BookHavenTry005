namespace BookHavenWinFormUi.PanelForms.Order
{
    partial class OrderDetailsForm
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnCancel = new Button();
            gbBookDetails = new GroupBox();
            btnSave = new Button();
            lblGenre = new Label();
            lblStock = new Label();
            lblSellingPrice = new Label();
            lblAuthorName = new Label();
            txtCurrentStock = new TextBox();
            txtSellingPrice = new TextBox();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            textBox1 = new TextBox();
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
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
            // gbBookDetails
            // 
            gbBookDetails.Controls.Add(btnSave);
            gbBookDetails.Controls.Add(btnCancel);
            gbBookDetails.Controls.Add(comboBox1);
            gbBookDetails.Controls.Add(comboBox2);
            gbBookDetails.Controls.Add(lblGenre);
            gbBookDetails.Controls.Add(lblStock);
            gbBookDetails.Controls.Add(lblSellingPrice);
            gbBookDetails.Controls.Add(lblAuthorName);
            gbBookDetails.Controls.Add(lblBookTitle);
            gbBookDetails.Controls.Add(textBox1);
            gbBookDetails.Controls.Add(txtCurrentStock);
            gbBookDetails.Controls.Add(txtSellingPrice);
            gbBookDetails.ForeColor = SystemColors.ButtonHighlight;
            gbBookDetails.Location = new Point(35, 33);
            gbBookDetails.Name = "gbBookDetails";
            gbBookDetails.Size = new Size(549, 540);
            gbBookDetails.TabIndex = 6;
            gbBookDetails.TabStop = false;
            gbBookDetails.Text = "Order Details";
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
            // lblGenre
            // 
            lblGenre.AutoSize = true;
            lblGenre.Location = new Point(35, 283);
            lblGenre.Margin = new Padding(4, 0, 4, 0);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(77, 21);
            lblGenre.TabIndex = 0;
            lblGenre.Text = "Total Cost";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(35, 226);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(70, 21);
            lblStock.TabIndex = 0;
            lblStock.Text = "Quantity";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(35, 170);
            lblSellingPrice.Margin = new Padding(4, 0, 4, 0);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(111, 21);
            lblSellingPrice.TabIndex = 0;
            lblSellingPrice.Text = "Purchase Price";
            // 
            // lblAuthorName
            // 
            lblAuthorName.AutoSize = true;
            lblAuthorName.Location = new Point(35, 116);
            lblAuthorName.Margin = new Padding(4, 0, 4, 0);
            lblAuthorName.Name = "lblAuthorName";
            lblAuthorName.Size = new Size(68, 21);
            lblAuthorName.TabIndex = 0;
            lblAuthorName.Text = "Supplier";
            // 
            // txtCurrentStock
            // 
            txtCurrentStock.Location = new Point(309, 223);
            txtCurrentStock.Margin = new Padding(4);
            txtCurrentStock.Name = "txtCurrentStock";
            txtCurrentStock.Size = new Size(190, 29);
            txtCurrentStock.TabIndex = 1;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(309, 167);
            txtSellingPrice.Margin = new Padding(4);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(190, 29);
            txtSellingPrice.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(176, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(323, 29);
            comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(176, 113);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(323, 29);
            comboBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(309, 280);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(190, 29);
            textBox1.TabIndex = 1;
            // 
            // OrderDetailsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(619, 606);
            Controls.Add(gbBookDetails);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "OrderDetailsForm";
            Text = "OrderDetailsForm";
            Load += OrderDetailsForm_Load;
            gbBookDetails.ResumeLayout(false);
            gbBookDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBookTitle;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnCancel;
        private GroupBox gbBookDetails;
        private Button btnSave;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label lblGenre;
        private Label lblStock;
        private Label lblSellingPrice;
        private Label lblAuthorName;
        private TextBox textBox1;
        private TextBox txtCurrentStock;
        private TextBox txtSellingPrice;
    }
}