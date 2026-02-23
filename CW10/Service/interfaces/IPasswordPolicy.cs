using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW10.Service.interfaces
{
    internal interface IPasswordPolicy
    {
        void Validate(string username, string password);
    }
}
