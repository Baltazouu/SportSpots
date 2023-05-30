using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace Model
{
    // All the  code in this file is included in all platforms.
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