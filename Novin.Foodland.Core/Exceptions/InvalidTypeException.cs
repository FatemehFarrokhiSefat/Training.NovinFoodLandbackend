using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novin.Foodland.Core.Exceptions
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException()
            :base("نوع فرم مشخص نشده است")
        {
            
        }
    }
}
