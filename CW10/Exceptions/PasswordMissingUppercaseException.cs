using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Exceptions
{
    internal class PasswordMissingUppercaseException :Exception
    {
        public PasswordMissingUppercaseException(string message):base(message)
        {
            
        }
    }
}
