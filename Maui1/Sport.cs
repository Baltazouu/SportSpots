using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui1
{ 
    internal class Sport
    {
        string Name { get; set; }

        bool Indoor { get; set; }

        bool Outdoor { get; set; }

        Sport(string name,bool indoor, bool outdoor) 
        {
            Name = name;
            Indoor = indoor;
            Outdoor = outdoor;
        }
    }
}
