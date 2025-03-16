using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public class NavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowLoginForm()
        {
            var loginForm = _serviceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
        }

        public void ShowMainForm()
        {
            var mainForm = _serviceProvider.GetRequiredService<MainForm>();
            mainForm.Show();
        }
    }

}
