using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sport
    {
        public string Name { get; init; }

        public bool Indoor { get; init; }

        public bool Outdoor {  get; init; }

        public Sport(string name, bool indoor, bool outdoor)
        {
            Name = name;
            Indoor = indoor;
            Outdoor = outdoor;
        }
    }
}
