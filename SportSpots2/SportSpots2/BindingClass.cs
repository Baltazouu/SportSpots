using Model;
using Persistance;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace SportsSpots
{
    public class BindingClass : INotifyPropertyChanged
    {
        public User Utilisateur { get; set; }
        
        public static ObservableCollection<Sport> SportsAvaibles { get; set; } = SportStub.Loadsport();

        public ReadOnlyCollection<Sport> SportsAvaiblesCollection { get; } 
        public List<Sport> toSearch { get; set; } = new();

        public  ObservableCollection<Spot> SpotsFinded { get; private set; }
        
        public string Town { get; set; }

        // ne marche pas quand bindée ??

        public event PropertyChangedEventHandler? PropertyChanged;

        public BindingClass(User utilisateur)
        {
            Utilisateur = utilisateur;

            // test not works
            
            SportsAvaiblesCollection = new ReadOnlyCollection<Sport>(SetFavoriteSports());

            Data dt = new();
            
           // exception a gerer
           // dt.SaveSport(new SportContract(), SportsAvaibles.ToList());
            
        }

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public async  Task ExecuteResearch(string town,int postalcode)
        {
            Search s = null;
            if(postalcode > 0 && postalcode < 100)
            {
                s = new(town, toSearch, postalcode);
            }
            else s = new(town, toSearch);

            Town = town;
            OnPropertyChanged(nameof(Town));

            SpotsFinded = new ObservableCollection<Spot>(await s.ExecuteSearch());
            
            for(int i = 0; i < SpotsFinded.Count; i++)
            {
                for(int x = 0; x < Utilisateur.FavSpots.Count;x++)
                {
                    if (SpotsFinded[i].Numero.Equals(Utilisateur.FavSpots[x].Numero))
                    {
                        SpotsFinded[i] = Utilisateur.FavSpots[x];
                    }
                }
            }

            for (int i = 0; i < SpotsFinded.Count; i++)
            {
                for (int x = 0; x < Utilisateur.History.Count; x++)
                {
                    if (SpotsFinded[i].Numero.Equals(Utilisateur.History[x].Numero))
                    {
                        SpotsFinded[i] = Utilisateur.History[x];
                    }
                }
            }

            OnPropertyChanged(nameof(SpotsFinded));
            
         
#if DEBUG
            Debug.WriteLine("[Test Collection Finded]\n\n");
            foreach (var spot in SpotsFinded)
                Debug.WriteLine(spot.ToString());

            Debug.WriteLine("Nombre de spots : {0}", SpotsFinded.Count);
#endif
        }


        public ObservableCollection<Sport> SetFavoriteSports()
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
