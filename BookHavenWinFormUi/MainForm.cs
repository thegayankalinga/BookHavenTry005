using BookHavenClassLibrary.Interfaces;
using BookHavenWinFormUi.PanelForms;
using BookHavenWinFormUi.PanelForms.Customer;
using BookHavenWinFormUi.PanelForms.Reports;
using BookHavenWinFormUi.PanelForms.Supplier;
using BookHavenWinFormUi.PanelForms.User;
using BookHavenWinFormUi.Utilz;
using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BookHavenWinFormUi
{



    public partial class MainForm : Form
    {
        private readonly IUserSessionService _userSessionService;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;




        public MainForm(IUserSessionService sessionService)
        {


            InitializeComponent();
            _userSessionService = sessionService;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelSideMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        // Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                //Deactivate the previous button 
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left Boarder Button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon & Text set to child form title
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.BackColor = color;
                lblTitleChildForm.Text = currentBtn.Text;
            }

        }


        private void DisableButton()
        {
            if (currentBtn != null)
            {

                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            currentChildForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;

        }

        //TODO: Do this for all buttons
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var dashboardForm = Program.Host.Services.GetRequiredService<Dashboard>();
            OpenChildForm(dashboardForm);

            //TODO: For all child forms to open in the button click
            //OpenChildForm(new FormDashboard());
        }


        private void btnSupplier_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var supplierForm = Program.Host.Services.GetRequiredService<SupplierForm>();
            OpenChildForm(supplierForm);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var bookForm = Program.Host.Services.GetRequiredService<BookForm>();
            OpenChildForm(bookForm);

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var userForm = Program.Host.Services.GetRequiredService<UserForm>();
            OpenChildForm(userForm);

        }

        private void btnSupplierOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var orderForm = Program.Host.Services.GetRequiredService<OrderForm>();
            OpenChildForm(orderForm);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var salesForm = Program.Host.Services.GetRequiredService<SalesForm>();
            OpenChildForm(salesForm);
        }


        private void btnReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var reportForm = Program.Host.Services.GetRequiredService<Report>();
            OpenChildForm(reportForm);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            var customerForm = Program.Host.Services.GetRequiredService<CustomerForm>();
            OpenChildForm(customerForm);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _userSessionService.Logout();
            Application.Restart(); //this is much easier.

            // Redirect to login form
            //this.Close();
            //var navigationService = Program.Host.Services.GetRequiredService<NavigationService>();
            //navigationService.ShowLoginForm();

            // Close current form
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm?.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.IndianRed;
            lblTitleChildForm.Text = "Home";
        }


        #region Code to handle the window
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnSupplier.Visible = _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Admin);
            btnUsers.Visible = _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Admin);
            btnSupplierOrder.Visible = _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Admin);

            btnBooks.Visible = _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Admin)
            || _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Sales);

            btnReport.Visible = _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Admin)
            || _userSessionService.HasPermission(BookHavenClassLibrary.Enumz.UserRoleType.Sales);


        }

        #endregion












        //TODO: Implement these
        //Buttons to close, minimize & maxmimize
        //remember to anchor to top & right

        //Application.Exit()
        /*
         * if(WindowState == FormWindowState.Normal)
         *  WindowState = FormWindowState.Maximized;
         * else
         *  WindowState = FormWindowState.Normal;
         * 
         */


        /*
         * WindowState = FormWindowState.Minimized;
         */
    }
}
