using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Foodland.Core.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() 
            :base ("کلمه عبور پیچیدگی لازم را ندارد")
        {
            
        }
    }
}
