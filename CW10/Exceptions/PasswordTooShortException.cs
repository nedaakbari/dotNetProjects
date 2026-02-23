using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Exceptions
{
    internal class PasswordTooShortException:Exception
    {
        public PasswordTooShortException(string message):base(message)
        {
            
        }
    }
}
