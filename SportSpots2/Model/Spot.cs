using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Model
{
   /// <summary>
   /// Spot class (result of API data-es requests)
   /// </summary>
    public class Spot
    {
        [DataMember(Name = "commune")]
        public string? NomCommune { get; init; }
        [DataMember(Name = "SpotNum")]
        public int?Numero { get; init; }
        [DataMember(Name = "SpotName")]
        public string?Name { get; init; }
        [DataMember(Name = "SpotFamily")]
        public string?Family { get; init; }
        [DataMember(Name = "SpotAddress")]
        public string?Adress { get; init; }
        [DataMember(Name = "SpotDepartement")]
        public string?Dept { get; init; }
        [DataMember(Name = "PostalCode")]
        public int?PostalCode { get; init; }
        [DataMember(Name = "SpotCoord_x")]
        public double?Coord_x { get; init; }
        [DataMember(Name = "SpotCoord_x")]
        public double?Coord_y { get; init; }
        [DataMember(Name="AccessHandicap")]
        public bool AccessibiltyHandicap { get; init; }
        [DataMember(Name = "Restauration")]
        public bool Restauration { get; init; }
        [DataMember(Name = "PublicAcess")]
        public bool Public_access { get; init; }

        [DataMember(Name = "imgLink")]
        public string? ImgLink { get; set; }

        [DataMember(Name = "favorite")]
        public string Favorite { get; set; } // image favoris pour les bindings

        [DataMember(Name="urllink")]
        public string UrlLink { get; init; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numero">national number of spot</param>
        /// <param name="nomcomm">name of town of the spot</param>
        /// <param name="nom">name of the spot</param>
        /// <param name="family">family sport of the spot</param>
        /// <param name="adress">adress of the spot</param>
        /// <param name="postalcode">postalcode of the spot</param>
        /// <param name="dept">departement of the spot</param>
        /// <param name="coord_x">X coordinate</param>
        /// <param name="coord_y">Y coordinate</param>
        /// <param name="asccessHandicap">boolean accessiblity for handicap persons</param>
        /// <param name="restauration">boolean is restauration avaible on the site</param>
        /// <param name="publicAccess">boolean is the spot in public access</param>
        public Spot(int? numero, string? nomcomm, string? nom, string? family,
                    string? adress, int? postalcode, string? dept,
                    double? coord_x, double? coord_y, bool asccessHandicap,
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
            string Coord_x_Link = Coord_x.ToString().Replace(",", "."); // on remplace la virgule par un point, sinon openstreetmap ne reconnait pas les coordonnées
            string Coord_y_Link = Coord_y.ToString().Replace(",", "."); 
            AccessibiltyHandicap = asccessHandicap;
            Restauration = restauration;
            Public_access = publicAccess;
            Dept = dept;
            Favorite = "star.png";
            UrlLink = $"https://www.openstreetmap.org/export/embed.html?bbox={Coord_y_Link}%2C{Coord_x_Link}&layer=mapnik";
        }

        public bool Equals(Spot other)
            => Numero.Equals(other.Numero);

        public override string ToString()
        {
            return $"Spot : {Name}  {Family} {NomCommune} {Adress} {Dept} {PostalCode}";
        }

    }
}