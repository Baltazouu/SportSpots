using System.Collections.Specialized;

namespace Maui1
{
    // All the code in this file is included in all platforms.
    public class Spot
    { 

        public string Numero { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        int PostalCode {get; set;}
        public float Coord_x { get; set; }
        public float Coord_y { get; set; }
        public bool Accessibilty { get; set; }
        public bool Restauration { get; set; }
        public bool Public_access { get; set; }


        public Spot(string numero,string nom,string family, string type, string adress, int postalcode,float coord_x, float coord_y,bool accessibilty,bool publicAccess)
        {
            Numero = numero;
            Name = nom;
            Family = family;
            Type = type;
            Adress = adress;
            PostalCode = postalcode;
            Coord_x =coord_x;
            Coord_y=coord_y;
            Accessibilty = accessibilty;
            Public_access = publicAccess;
        }


         public override string ToString()
        {
            return "Spot : " + Name + " Adresse " + PostalCode;
        }


        
    }
}