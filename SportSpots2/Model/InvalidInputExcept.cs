using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Exception Class for false input 
    /// </summary>
    public class InvalidInputExcept : Exception
    {
        public InvalidInputExcept(string errmsg)
        : base(errmsg)
        {
            
        }
    }
}
