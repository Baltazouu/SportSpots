using System.Collections.Specialized;

namespace Maui1
{
    // All the code in this file is included in all platforms.
    public class Spot
    { 

        public string Numero { get; set; }
        public string Nom { get; set; }
        public string Famille { get; set; }
        public string Type { get; set; }
        public string Adresse { get; set; }
        int CodePostal {get; set;}
        public string Coord_x { get; set; }
        public string Coord_y { get; set; }
        public bool accessibilite { get; set; }
        public bool restauration { get; set; }

        public bool public_access { get; set; }



        public Spot(string coord_x, string coord_y, string adresse,string nom)
        {
            Coord_x=coord_x;
            Coord_y=coord_y;
            Adresse=adresse;
            Nom = nom;
        }

        public Spot()
        { }

         public override string ToString()
        {
            return "Spot : " + Nom + " Adresse " + CodePostal;
        }


    }
}