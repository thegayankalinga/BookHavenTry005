using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookHavenWinFormUi.Utilz
{
    public class ValidationService
    {
        public static bool IsvalidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidText(TextBox textBox)
        {
            string userInput = textBox.Text;

            if (string.IsNullOrEmpty(userInput))
            {
                return false;
            }

            //Add additional Checks

            return true;
        }
    }

   
            
}
