using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMaui
{
    internal class InvalidInputExcept : Exception
    {
        public InvalidInputExcept(string errmsg)
        : base(errmsg)
        {
            
        }
    }
}
