using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Exceptions
{
    internal class PasswordMissingDigitException : Exception
    {
        public PasswordMissingDigitException(string message) : base(message)
        {

        }
    }
}
