using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Repositories;
using BookHavenClassLibrary.Services;
using BookHavenWinFormUi.PanelForms;
using BookHavenWinFormUi.Utilz;
using Microsoft.Extensions.DependencyInjection;

namespace BookHavenWinFormUi
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly IUserSessionService _sessionService;
        public LoginForm(IUserRepository userRepository, IServiceProvider serviceProvider, IUserSessionService sessionService)
        {

            _serviceProvider = serviceProvider;
            _userRepository = userRepository;
            _sessionService = sessionService;
            InitializeComponent();

            //TODO: remove for production
            userEmail.Text = "admin@bookhaven.com";
            userPassword.Text = "Test@123";
            _serviceProvider = serviceProvider;
            _sessionService = sessionService;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            if (ValidationService.IsValidText(userEmail) == false)
            {
                MessageBox.Show(this, "Email field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userEmail.Focus();
                return;
            }

            //TODO: Call the email regex validation here



            if (ValidationService.IsValidText(userPassword) == false)
            {
                MessageBox.Show(this, "Password field cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userPassword.Focus();
                return;
            }

            string email = userEmail.Text;
            string password = userPassword.Text;
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            loginRequestDto.Email = email;
            loginRequestDto.Password = password;

            bool loginSuccessful = await _sessionService.LoginAsync(loginRequestDto);

            if (loginSuccessful)
            {
                MainForm mainForm = _serviceProvider.GetRequiredService<MainForm>();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Invalid User, Please use correct login information");
            }






        }
    }
}
