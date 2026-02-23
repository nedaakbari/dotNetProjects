using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Exceptions
{
    internal class PasswordContainsUsernameException : Exception
    {
        public PasswordContainsUsernameException(string message) : base(message)
        {

        }
    }
}