using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sport
    {

        public int Numero { get; set; }

        public string Name { get; init; }

        public string TypeEquipement { get; init; }

        public bool Indoor { get; init; }

        public bool Outdoor {  get; init; }

        public Sport(int num,string name,string typ, bool indoor, bool outdoor)
        {
            name = name.Replace(" ","+");
            //Console.WriteLine(name);
            
            Name = name;

            typ = typ.Replace(" ", "+");
            Numero = num;   
            TypeEquipement = typ;
            Indoor = indoor;
            Outdoor = outdoor;
        }
    }
}
