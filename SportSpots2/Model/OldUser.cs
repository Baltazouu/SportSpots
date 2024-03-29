﻿using System.Runtime.Serialization;
/*

namespace Model
{

    [DataContract(Name = "oldoldoldoldUser")]
    public class oldUser : DataBaseConnection
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Mail { get; private set; }

        [DataMember]
        public string Passwd { get; private set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Spot> FavSpots { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Sport> Favsports { get; set; }


        public oldUser(int id, string mail, string passwd, List<Spot>? spots, List<Sport>? sports)
        {
            Id = id;
            Mail = mail;
            Passwd = passwd;
            if (spots != null)
            {
                FavSpots = spots;
            }
            else FavSpots = new List<Spot>();

            if (sports != null)
            {
                Favsports = sports;
            }
            else Favsports = new List<Sport>();
        }

        public bool ChangePasswd(string newpasswd)
        {
            if (newpasswd.Length > 6)
            {
                Passwd = newpasswd;
                return UpdatePass(Id, Mail, Passwd);


            }
            return false;
        }

        public bool ChangeMail(string newMail)
        {
            if (newMail.Length > 5)
            {
                if (UpdateMail(Id, Mail))
                {
                    Mail = newMail;
                    return true;
                }
            }

            return false;
        }

        public bool AddSpot(Spot spot)
        {
            bool present = false;
            foreach (Spot sp in FavSpots)
            {
                if (sp.Numero == spot.Numero)
                {
                    present = true;
                }
            }
            if (!present)
            {
                FavSpots.Add(spot);
                return true;
            }
            return false;

        }

        public bool AddSport(Sport sport)
        {
            bool present = false;
            foreach (Sport sp in Favsports)
            {
                if (sp.Numero == sport.Numero)
                {
                    present = true;
                }
            }
            if (!present)
            {
                Favsports.Add(sport);
                return true;
            }
            return false;
        }


        public bool RemoveSpot(Spot sport)
        {
            bool present = false;

            foreach (Spot sp in FavSpots)
            {
                if (sp.Numero == sport.Numero)
                    present = true;
               
            }
            if (present) { FavSpots.Remove(sport); }
            return present;

        }


        public bool RemoveSport(Sport spot)
        {
            foreach (Spot sp in FavSpots)
            {
                if (sp.Numero == spot.Numero)
                {
                    FavSpots.Remove(sp);
                    return true;
                }
            }
            return false;
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(oldUser other)
        {
            return this.Mail == other.Mail && this.Passwd == other.Passwd;
        }


        public override string ToString()
        {
            return $"{Mail} {Id}";
        }
    }

}
*/
