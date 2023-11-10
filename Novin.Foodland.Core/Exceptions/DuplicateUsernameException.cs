using Novin.Foodland.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Foodland.Core.Exceptions
{
    public class DuplicateUsernameException : Exception,IDataException
    {
        public DuplicateUsernameException() :base("شماره همراه تکراری است") 
        {
        }
    }
}
