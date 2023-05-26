using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace SportsSpots
{
    public class ViewModel1 : INotifyPropertyChanged
    {

        public User Utilisateur { get; set; }
        public SportStub SportsAvaibles { get; set; } = new SportStub();

        public List<Sport> toSearch { get; set; } = new();

        public List<Spot> SpotsFinded { get; set; }

        public ReadOnlyCollection<Spot> collectionFinded;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModel1(User utilisateur)
        {
            Utilisateur = utilisateur;
            SpotsFinded = new();
            collectionFinded = new ReadOnlyCollection<Spot>(SpotsFinded);
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

        public async  Task executeResearch(string town)
        {
            Search s = new(town, toSearch);

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



    }
}
