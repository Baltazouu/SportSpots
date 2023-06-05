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
    /// <summary>
    /// Public Class User to manage user favorites and history
    /// </summary>
    [DataContract(Name = "user")]
    public class User : INotifyPropertyChanged
    {
        /// <summary>
        /// User id
        /// </summary>
        [DataMember]
        public int Id { get; init; }

        /// <summary>
        /// User Mail
        /// </summary>
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

        /// <summary>
        /// User Password (normally hashed)
        /// </summary>
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
        public ObservableCollection<Spot> FavSpots { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Sport> Favsports { get;  set; }

        [DataMember(EmitDefaultValue = false)]
        public ObservableCollection<Spot> History { get; set; }

        //public ReadOnlyCollection<Spot> HistoryCollection { get; set; }

        //public ReadOnlyCollection<Spot> FavSpotsCollection { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="mail">User Mail</param>
        /// <param name="pass">User password</param>
        /// <param name="spots">User list of spots favorite</param>
        /// <param name="sports">User list of sports favorite</param>
        /// <param name="history">user list of history</param>
        public User(int id, string mail,string pass,ObservableCollection<Spot>?spots,ObservableCollection<Sport> ?sports,ObservableCollection<Spot>?history)
        {
            Id = id;
            Mail = mail;
            Passwd = pass;
            if(spots != null)
            {
                FavSpots = spots;
            }
            else FavSpots = new ObservableCollection<Spot>();

            if(sports!=null)
            {
                Favsports = sports;
            }    
            else Favsports = new ObservableCollection<Sport>();
            
            if(history!=null)
            {
                History = history;
            }
            else History = new();

           // FavSpotsCollection = new ReadOnlyCollection<Spot>(History);

           // FavSpotsCollection = new ReadOnlyCollection<Spot>(FavSpots);
            

        }

        /// <summary>
        /// method who manage userpasswordchange
        /// </summary>
        /// <param name="newpasswd">new hashed password</param>
        /// <returns>boolean of operation result</returns>
        public bool ChangePasswd(string newpasswd)
        {
            if (newpasswd.Length > 6)
            {
                Passwd = newpasswd;
                return true;
            }
            return false ;
        }

        /// <summary>
        /// Method who manage changing mail opearation
        /// </summary>
        /// <param name="newMail"></param>
        /// <returns>boolean of operation success</returns>
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

        /// <summary>
        /// Method Who manage adding spot into user favspots list
        /// </summary>
        /// <param name="spot">spot to add</param>
        /// <returns>boolean result of operation</returns>
        public bool AddToFavSpot(Spot spot)
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
                OnPropertyChanged("Favorite");
                return true;
            }
            return false;

        }

        /// <summary>
        /// Method Who Manage Adding sport into favsports list
        /// </summary>
        /// <param name="sport">sport to add</param>
        /// <returns>result of operation</returns>
        public bool AddSToFavSport(Sport sport)
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

        /// <summary>
        /// Method to manage removing sport into favlist
        /// </summary>
        /// <param name="sport">sport to remove</param>
        /// <returns>resultt of operation</returns>
        public bool RemoveToFavSpot(Spot spot)
        {
            
            foreach (Spot sp in FavSpots)
            {
                if (sp.Numero == spot.Numero)
                {
                    FavSpots.Remove(sp);
                    OnPropertyChanged("FavSpots");
                    OnPropertyChanged("Favorite");
                    return true;
                    
                }
            }
            return false;
            

        }

        /// <summary>collection cannot work with indices larger than Int32.MaxValue - 1 (0x7FFFFFFF - 1). Arg_ParamName_Name'

        /// Method to manage removing spot of favspot list
        /// </summary>
        /// <param name="spot">spot to remove</param>
        /// <returns>boolean result of operation</returns>
        public bool RemoveToFavSport(Sport sport)
        {
            foreach (Sport sp in Favsports)
            {
                if (sp.Numero == sport.Numero)
                {
                    Favsports.Remove(sp);
                    //OnPropertyChanged("FavSpots");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="other">other to compare</param>
        /// <returns>bool</returns>
        public bool Equals(User other)
        {
            return this.Mail== other.Mail && this.Passwd==other.Passwd;
        }


        public override string ToString()
        {
            return $"{Mail} {Id}";
        }

        /// <summary>
        /// Add Spot to history method
        /// When history.count equals 10 the older is removed of the list
        /// </summary>
        /// <param name="s">spot to add</param>
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
             }

            
        }
        
    }
}