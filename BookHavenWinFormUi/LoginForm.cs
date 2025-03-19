using BookHavenClassLibrary.Dtos.User;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Repositories;
using BookHavenWinFormUi.PanelForms;
using BookHavenWinFormUi.Utilz;
using Microsoft.Extensions.DependencyInjection;

namespace BookHavenWinFormUi
{
    public partial class LoginForm : Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        public LoginForm(IUserRepository userRepository, IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            _userRepository = userRepository;
            InitializeComponent();

            //TODO: remove for production
            userEmail.Text = "admin@bookhaven.com";
            userPassword.Text = "test123";
            _serviceProvider = serviceProvider;
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

            UserResponseDto? userResponseDto = await _userRepository.Login(loginRequestDto);

            if (userResponseDto != null)
            {

                // Store user details in session
                UserSession.SetUser(userResponseDto.Id, userResponseDto.Email, userResponseDto.FullName, userResponseDto.Role);

                //TODO: gotomain form
                MainForm mainForm = _serviceProvider.GetRequiredService<MainForm>();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();

              
                //MessageBox.Show(this, "Login Successful");
            }
            else {
               MessageBox.Show(this, $"Invalid User, Please use correct login information");
            }
        }
           
            

        

        
    }
}
