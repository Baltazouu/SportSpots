using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace SportsSpots
{
    public class BindingClass : INotifyPropertyChanged
    {

        public User Utilisateur { get; set; }
        
        public static List<Sport> SportsAvaibles { get; set; } = SportStub.Loadsport();

        public ReadOnlyCollection<Sport> SportsAvaiblesCollection { get; } 
        public List<Sport> toSearch { get; set; } = new();

        public  List<Spot> SpotsFinded { get; set; }
        
        public string Town { get; set; }

        // ne marche pas quand bindée ??
        public ReadOnlyCollection<Spot> collectionFinded;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BindingClass(User utilisateur)
        {
            Utilisateur = utilisateur;
            SpotsFinded = new();
            collectionFinded = new ReadOnlyCollection<Spot>(SpotsFinded);
            SportsAvaiblesCollection = new ReadOnlyCollection<Sport>(SetFavoriteSports());
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ImageSource star { get;init; } = "star.png";
        public ImageSource starfilled { get; init; } = "starfilled.png";

        public async  Task executeResearch(string town,int postalcode)
        {
            Search s = null;
            if(postalcode > 0 && postalcode < 100)
            {
                s = new(town, toSearch, postalcode);
            }
            else s = new(town, toSearch);

            Town = town;
            OnPropertyChanged("Town");

            SpotsFinded = await s.ExecuteSearch();

            collectionFinded = new ReadOnlyCollection<Spot>(SpotsFinded);
            
            OnPropertyChanged("SpotsFinded");
            OnPropertyChanged("collectionFinded");

            //debug test
            Debug.WriteLine("[Test Collection Finded]\n\n");
            foreach (var spot in collectionFinded)
                Debug.WriteLine(spot.ToString());



            // debug test
            //Debug.WriteLine("[Test Collection Finded]\n\n");
            //foreach (var spot in collectionFinded)
            //    Debug.WriteLine(spot.ToString());

        }


        public List<Sport> SetFavoriteSports()
        {
            foreach(var sport in SportsAvaibles)
            {
                foreach(var sportUser in Utilisateur.Favsports)
                {
                    if(sport.Equals(sportUser))
                    {
                        sport.Favorite = "starfilled.png";
                    }
                }
            }
            SportsAvaibles.OrderByDescending(s => s.Favorite == "starfilled.png").ToList();
            return SportsAvaibles;
        }


       

    }
}
