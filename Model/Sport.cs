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

        public string TypeEquipement { get; init; }

        public bool Indoor { get; init; }

        public bool Outdoor {  get; init; }

        public Sport(string name,string typ, bool indoor, bool outdoor)
        {
            name = name.Replace(" ","+");
            //Console.WriteLine(name);
            
            Name = name;

            typ = typ.Replace(" ", "+");

            TypeEquipement = typ;
            Indoor = indoor;
            Outdoor = outdoor;
        }
    }
}
