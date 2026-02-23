using CW10.Exceptions;
using CW10.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Service
{
    internal class StrongPasswordPolicy : IPasswordPolicy
    {
        private static char[] SpecialChars = new[] { '!', '@', '#', '$', '%' };

        public void Validate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("password");
            IsPreperLength(password);
            HasUpperCase(password);
            HasLoweCase(password);
            HasDigit(password);
            HasSpecialChar(password);
            HasEqualToUsername(username, password);
        }

        private void HasSpecialChar(string password)
        {
            //!password.Any(c => SpecialChars.Contains(c))
            if (!password.Any(ch => "!@#$%^&*".Contains(ch))) throw new PasswordMissingSpecialCharException("should have special char");
        }

        private void IsPreperLength(string input)
        {
            if (input.Length < 8) throw new PasswordTooShortException("pass must be 8 char");
        }
        private void HasLoweCase(string input)
        {
            if (!input.Any(char.IsLower)) throw new PasswordMissingLowercaseException("nedd lowercase");
        }
        private void HasUpperCase(string input)
        {
            if (!input.Any(char.IsUpper)) throw new PasswordMissingUppercaseException("uppercase missed");
        }
        private void HasDigit(string input)
        {
            if (!input.Any(char.IsDigit)) throw new PasswordMissingDigitException("need digit");
        }
        private void HasEqualToUsername(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && password.Contains(username)) throw new PasswordContainsUsernameException("password can not have username");
        }
    }
}