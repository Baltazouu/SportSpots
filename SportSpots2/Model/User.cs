using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    [DataContract(Name = "user")]
    public class User : INotifyPropertyChanged
    {
        [DataMember]
        public int Id { get; init; }

        [DataMember]
        public string Mail { get; private set; }

        string _passwd;

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [DataMember]
        public string Passwd
        {
            get { return _passwd; }

            private set
            {
                if (value == null || value.Length < 6 )
                {
                    Console.WriteLine("Value null");
                    //throw new ArgumentException("Invalid Password ");
                }
                _passwd = value;
                OnPropertyChanged("Passwd");
            }
        }

        [DataMember(EmitDefaultValue = false)]
        public List<Spot> FavSpots { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Sport> Favsports { get;  set; }

        public List<Spot> History { get; set; }

        public ReadOnlyCollection<Spot> HistoryCollection { get; set; }

        public ReadOnlyCollection<Spot> FavSpotsCollection { get; set; }

        public User(int id, string mail,string pass,List<Spot>?spots,List<Sport> ?sports)
        {
            Id = id;
            Mail = mail;
            Passwd = pass;
            if(spots != null)
            {
                FavSpots = spots;
            }
            else FavSpots = new List<Spot>();

            if(sports!=null)
            {
                Favsports = sports;
            }    
            else Favsports = new List<Sport>();

            History = new();

            FavSpotsCollection = new ReadOnlyCollection<Spot>(History);

            FavSpotsCollection = new ReadOnlyCollection<Spot>(FavSpots);
            

        }

        public bool ChangePasswd(string newpasswd)
        {
            if (newpasswd.Length > 6)
            {
                Passwd = newpasswd;
                return true;
            }
            return false ;
        }

        public bool ChangeMail(string newMail)
        {
            if(newMail.Length > 5)
            {
                Mail = newMail;
                OnPropertyChanged("Mail");
                return true;
                
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
                OnPropertyChanged("FavSpots");
                FavSpotsCollection = new ReadOnlyCollection<Spot>(FavSpots);
                OnPropertyChanged("FavSpotsCollection");
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
                OnPropertyChanged("Favsports");
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
                {
                    present = true;
                    break;
                }
            }
            if (present) {
                FavSpots.Remove(sport); OnPropertyChanged("FavSpots");
                OnPropertyChanged("FavSpots");
                FavSpotsCollection = new ReadOnlyCollection<Spot>(FavSpots);
                OnPropertyChanged("FavSpotsCollection");
            }
            return present;

        }


        public bool RemoveSport(Sport spot)
        {
            foreach (Spot sp in FavSpots)
            {
                if (sp.Numero == spot.Numero)
                {
                    FavSpots.Remove(sp);
                    OnPropertyChanged("FavSpots");
                    return true;
                }
            }
            return false;
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(User other)
        {
            return this.Mail== other.Mail && this.Passwd==other.Passwd;
        }


        public override string ToString()
        {
            return $"{Mail} {Id}";
        }

        public void AddSpotToHistory(Spot s)
        {
            bool find = false;
            
            foreach (Spot sp in History)
                {
                    if (s.Equals(sp))
                        find = true;
                }
             if (!find)
             {
                if (History.Count == 10)
                {
                    History.RemoveAt(0);
                }
                History.Add(s);
                OnPropertyChanged("History");
                HistoryCollection = new ReadOnlyCollection<Spot>(History);
                OnPropertyChanged("HistoryCollection"); 
             }

            
        }
    }
}