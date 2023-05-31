
using System.Runtime.Serialization;

namespace Model
{
    public class Sport : IEquatable<Sport>
    {
        [DataMember(Name="SportNumero")]
        public int Numero { get; set; }
        [DataMember(Name = "SportName")]
        public string Name { get; init; }
        [DataMember(Name = "Sporttype")]
        public string TypeEquipement { get; init; }
        [DataMember(Name = "indoor")]
        public bool Indoor { get; init; }
        [DataMember(Name = "outdoor")]
        public bool Outdoor { get; init; }

        [DataMember(Name="imglink")]
        public string ImgLink { get; set; }

        public string Favorite { get; set; } 

        public Sport(int num, string name, string typ, bool indoor, bool outdoor,string urlImage)
        {
            //name = name.Replace(" ", "+");
            //Console.WriteLine(name);

            Name = name;

            //typ = typ.Replace(" ", "+");
            Numero = num;
            TypeEquipement = typ;
            Indoor = indoor;
            Outdoor = outdoor;
            ImgLink = urlImage;
            Favorite = "star.png";

        }

        public override int GetHashCode()
            => base.GetHashCode();

        public bool Equals(Sport? other)
        => Name.Equals(other.Name);

        public override string ToString()
        {
            string indoor = "No";
            string outdoor = "No";

            string name = Name.Replace("+", " ");

            string typ = TypeEquipement.Replace("+", " ");

            if (Indoor)
                indoor = "Yes";
            if (Outdoor)
                outdoor = "Yes";

            return $"Name : {name} Type : {typ} Indoor : {indoor}, Outdoor : {outdoor}";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Sport);
        }

    }
}
