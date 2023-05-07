using System.Collections.Specialized;

namespace ModelMaui
{
    // All the  code in this file is included in all platforms.
    public class Spot
    {
        public string NomCommune { get; init; }
        public int Numero { get; init; }
        public string Name { get; init; }
        public string Family { get; init; }
        public string Adress { get; init; }
        public string Dept {  get; init; }
        public int PostalCode { get; init; }
        public double Coord_x { get; init; }
        public double Coord_y { get; init; }
        public bool AccessibiltyHandicap { get; init; }
        public bool Restauration { get; init; }
        public bool Public_access { get; init; }


        public Spot(int numero,string nomcomm, string nom, string family,
                    string adress, int postalcode,string dept,
                    double coord_x, double coord_y, bool asccessHandicap, 
                    bool restauration, bool publicAccess)
        {
            NomCommune = nomcomm;
            Numero = numero;
            Name = nom;
            Family = family;
            Adress = adress;
            PostalCode = postalcode;
            Coord_x = coord_x;
            Coord_y = coord_y;
            AccessibiltyHandicap = asccessHandicap;
            Restauration = restauration;
            Public_access = publicAccess;
            Dept = dept;
        }


        public override string ToString()
        {
            return $"Spot : {Name}  {Family} {NomCommune} {Adress} {Dept} {PostalCode}";
        }


    }
}