using System.Collections.Specialized;

namespace Model
{
    // All the code in this file is included in all platforms.
    public class Spot
    {

        public int Numero { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Type { get; set; }
        public string Adress { get; set; }
        public int PostalCode { get; set; }
        public double Coord_x { get; set; }
        public double Coord_y { get; set; }
        public bool Accessibilty { get; set; }
        public bool Restauration { get; set; }
        public bool Public_access { get; set; }


        public Spot(int numero, string nom, string family, string type, string adress, int postalcode,
                    double coord_x, double coord_y, bool accessibilty, bool restauration, bool publicAccess)
        {
            Numero = numero;
            Name = nom;
            Family = family;
            Type = type;
            Adress = adress;
            PostalCode = postalcode;
            Coord_x = coord_x;
            Coord_y = coord_y;
            Accessibilty = accessibilty;
            Restauration = restauration;
            Public_access = publicAccess;
        }


        public override string ToString()
        {
            return "Spot : " + Name + " Adresse " + PostalCode;
        }



    }
}