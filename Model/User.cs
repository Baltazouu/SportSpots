using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : DbConn
    {
        public int Id { get; init; }

        string Mail { get; set; }

        string Passwd { get; set; }

        List<Spot> FavSpots { get; set; }

        public List<Spot> NewFavSpots { get; private set; }
        List<Sport> Favsports { get; set; }

        List<Spot> History { get; set; }
        public User(int id, string mail, string passwd)
        {
            Id = id;
            Mail = mail;
            Passwd = passwd;
        }

        public bool ChangePasswd(string newpasswd)
        {
            if(newpasswd.Length > 6)
            {
                Passwd = newpasswd;
                return UpdatePass(Id,Mail,Passwd);


            }
            return false;
        }

        public bool ChangeMail(string newMail)
        {
            if(UpdateMail(Id,Mail))
            { 
                Mail = newMail;
                return true;
            }
            return false;
        }

        public bool AddSpot(Spot spot)
        {
            bool present = false;
            foreach(Spot sp in FavSpots)
            {
                if(sp.Numero == spot.Numero)
                {
                    present = true;
                }
            }
            foreach(Spot sp in newFavSpots)
            {
                if(sp.Numero == spot.Numero)
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
                if(sp.Numero == sport.Numero)
                    present = true;
                break;
            }
            if (present) { FavSpots.Remove(sport); }
            return present;
                
        }


        public bool RemoveSport(Sport spot)
        {
            foreach(Spot sp in FavSpots)
            {
                if (sp.Numero == spot.Numero)
                {
                    FavSpots.Remove(sp);
                    return true;
                }
            }
            return false;
        }




    }
}
