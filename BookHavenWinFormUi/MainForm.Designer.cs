namespace BookHavenWinFormUi
{
    partial class MainForm
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
            panelSideMenu = new Panel();
            btnLogout = new FontAwesome.Sharp.IconButton();
            btnReport = new FontAwesome.Sharp.IconButton();
            btnSales = new FontAwesome.Sharp.IconButton();
            btnSupplierOrder = new FontAwesome.Sharp.IconButton();
            btnUsers = new FontAwesome.Sharp.IconButton();
            btnBooks = new FontAwesome.Sharp.IconButton();
            btnSupplier = new FontAwesome.Sharp.IconButton();
            btnDashboard = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelShadow = new Panel();
            panelDesktop = new Panel();
            pictureBox2 = new PictureBox();
            btnCustomer = new FontAwesome.Sharp.IconButton();
            panelSideMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelSideMenu.Controls.Add(btnCustomer);
            panelSideMenu.Controls.Add(btnLogout);
            panelSideMenu.Controls.Add(btnReport);
            panelSideMenu.Controls.Add(btnSales);
            panelSideMenu.Controls.Add(btnSupplierOrder);
            panelSideMenu.Controls.Add(btnUsers);
            panelSideMenu.Controls.Add(btnBooks);
            panelSideMenu.Controls.Add(btnSupplier);
            panelSideMenu.Controls.Add(btnDashboard);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(220, 798);
            panelSideMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.Gainsboro;
            btnLogout.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            btnLogout.IconColor = Color.RosyBrown;
            btnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogout.IconSize = 32;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(0, 738);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(10, 0, 20, 0);
            btnLogout.Size = new Size(220, 60);
            btnLogout.TabIndex = 10;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnReport
            // 
            btnReport.Dock = DockStyle.Top;
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.ForeColor = Color.Gainsboro;
            btnReport.IconChar = FontAwesome.Sharp.IconChar.ChartArea;
            btnReport.IconColor = Color.RosyBrown;
            btnReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReport.IconSize = 32;
            btnReport.ImageAlign = ContentAlignment.MiddleLeft;
            btnReport.Location = new Point(0, 500);
            btnReport.Name = "btnReport";
            btnReport.Padding = new Padding(10, 0, 20, 0);
            btnReport.Size = new Size(220, 60);
            btnReport.TabIndex = 8;
            btnReport.Text = "Report";
            btnReport.TextAlign = ContentAlignment.MiddleLeft;
            btnReport.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnSales
            // 
            btnSales.Dock = DockStyle.Top;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.ForeColor = Color.Gainsboro;
            btnSales.IconChar = FontAwesome.Sharp.IconChar.Bullhorn;
            btnSales.IconColor = Color.RosyBrown;
            btnSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSales.IconSize = 32;
            btnSales.ImageAlign = ContentAlignment.MiddleLeft;
            btnSales.Location = new Point(0, 440);
            btnSales.Name = "btnSales";
            btnSales.Padding = new Padding(10, 0, 20, 0);
            btnSales.Size = new Size(220, 60);
            btnSales.TabIndex = 7;
            btnSales.Text = "Sales";
            btnSales.TextAlign = ContentAlignment.MiddleLeft;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnSupplierOrder
            // 
            btnSupplierOrder.Dock = DockStyle.Top;
            btnSupplierOrder.FlatAppearance.BorderSize = 0;
            btnSupplierOrder.FlatStyle = FlatStyle.Flat;
            btnSupplierOrder.ForeColor = Color.Gainsboro;
            btnSupplierOrder.IconChar = FontAwesome.Sharp.IconChar.Shop;
            btnSupplierOrder.IconColor = Color.RosyBrown;
            btnSupplierOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSupplierOrder.IconSize = 32;
            btnSupplierOrder.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplierOrder.Location = new Point(0, 380);
            btnSupplierOrder.Name = "btnSupplierOrder";
            btnSupplierOrder.Padding = new Padding(10, 0, 20, 0);
            btnSupplierOrder.Size = new Size(220, 60);
            btnSupplierOrder.TabIndex = 6;
            btnSupplierOrder.Text = "Orders";
            btnSupplierOrder.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplierOrder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplierOrder.UseVisualStyleBackColor = true;
            btnSupplierOrder.Click += btnSupplierOrder_Click;
            // 
            // btnUsers
            // 
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.ForeColor = Color.Gainsboro;
            btnUsers.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            btnUsers.IconColor = Color.RosyBrown;
            btnUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsers.IconSize = 32;
            btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsers.Location = new Point(0, 320);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(10, 0, 20, 0);
            btnUsers.Size = new Size(220, 60);
            btnUsers.TabIndex = 5;
            btnUsers.Text = "Users";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnBooks
            // 
            btnBooks.Dock = DockStyle.Top;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.ForeColor = Color.Gainsboro;
            btnBooks.IconChar = FontAwesome.Sharp.IconChar.Book;
            btnBooks.IconColor = Color.RosyBrown;
            btnBooks.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBooks.IconSize = 32;
            btnBooks.ImageAlign = ContentAlignment.MiddleLeft;
            btnBooks.Location = new Point(0, 260);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(10, 0, 20, 0);
            btnBooks.Size = new Size(220, 60);
            btnBooks.TabIndex = 4;
            btnBooks.Text = "Books";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Dock = DockStyle.Top;
            btnSupplier.FlatAppearance.BorderSize = 0;
            btnSupplier.FlatStyle = FlatStyle.Flat;
            btnSupplier.ForeColor = Color.Gainsboro;
            btnSupplier.IconChar = FontAwesome.Sharp.IconChar.Shop;
            btnSupplier.IconColor = Color.RosyBrown;
            btnSupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSupplier.IconSize = 32;
            btnSupplier.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplier.Location = new Point(0, 200);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Padding = new Padding(10, 0, 20, 0);
            btnSupplier.Size = new Size(220, 60);
            btnSupplier.TabIndex = 3;
            btnSupplier.Text = "Suppliers";
            btnSupplier.TextAlign = ContentAlignment.MiddleLeft;
            btnSupplier.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.ForeColor = Color.Gainsboro;
            btnDashboard.IconChar = FontAwesome.Sharp.IconChar.HomeUser;
            btnDashboard.IconColor = Color.RosyBrown;
            btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 140);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(10, 0, 20, 0);
            btnDashboard.Size = new Size(220, 60);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 140);
            panelLogo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cropped_final_image;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(217, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(26, 25, 62);
            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1204, 70);
            panelTitleBar.TabIndex = 1;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleChildForm.ForeColor = Color.IndianRed;
            lblTitleChildForm.Location = new Point(68, 28);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(56, 21);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Home";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(26, 25, 62);
            iconCurrentChildForm.ForeColor = Color.IndianRed;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.IndianRed;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.Location = new Point(22, 22);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(32, 32);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            panelShadow.BackColor = Color.FromArgb(26, 24, 58);
            panelShadow.Dock = DockStyle.Top;
            panelShadow.Location = new Point(220, 70);
            panelShadow.Name = "panelShadow";
            panelShadow.Size = new Size(1204, 8);
            panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            panelDesktop.Controls.Add(pictureBox2);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(220, 78);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1204, 720);
            panelDesktop.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = Properties.Resources.cropped_final_image;
            pictureBox2.Location = new Point(401, 205);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(389, 288);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // btnCustomer
            // 
            btnCustomer.Dock = DockStyle.Top;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.ForeColor = Color.Gainsboro;
            btnCustomer.IconChar = FontAwesome.Sharp.IconChar.Bullhorn;
            btnCustomer.IconColor = Color.RosyBrown;
            btnCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCustomer.IconSize = 32;
            btnCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomer.Location = new Point(0, 560);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Padding = new Padding(10, 0, 20, 0);
            btnCustomer.Size = new Size(220, 60);
            btnCustomer.TabIndex = 11;
            btnCustomer.Text = "Customer";
            btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
            btnCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 51, 73);
            ClientSize = new Size(1424, 798);
            Controls.Add(panelDesktop);
            Controls.Add(panelShadow);
            Controls.Add(panelTitleBar);
            Controls.Add(panelSideMenu);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "MainForm";
            panelSideMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnLogout;
        private FontAwesome.Sharp.IconButton btnReport;
        private FontAwesome.Sharp.IconButton btnSales;
        private FontAwesome.Sharp.IconButton btnSupplierOrder;
        private FontAwesome.Sharp.IconButton btnUsers;
        private FontAwesome.Sharp.IconButton btnBooks;
        private FontAwesome.Sharp.IconButton btnSupplier;
        private PictureBox pictureBox1;
        private Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label lblTitleChildForm;
        private Panel panelShadow;
        private Panel panelDesktop;
        private PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton btnCustomer;
    }
}