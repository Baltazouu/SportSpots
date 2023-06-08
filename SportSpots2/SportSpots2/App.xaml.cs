using Model;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace SportsSpots;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        UserAppTheme = AppTheme.Light;

        MainPage = new AppShell();
        

        // tests 
        /*
		ObservableCollection<Sport> l = new ObservableCollection<Sport>();

        l.Insert(0, new Sport(1, "Terrain de Rugby", "Terrain de rugby", true, true, "rugby.png"));
        l.Insert(1, new Sport(2, "Terrain de Basket", "Terrain de basket-ball", true, true, "basket.png"));
        l.Insert(2, new Sport(3,"Pétanque", "Terrain de Pétanque", true, true, "petanque.png"));
        l.Insert(3, new Sport(4, "Terrain de Football", "Terrain de Football", true, true, "foot.png"));
        l.Insert(4, new Sport(5, "Musculation", "Salle de musculation/cardiotraining", false, false, "muscu.png"));
        l.Insert(5, new Sport(6, "Terrain de Tennis", "Court de tennis", true, true, "tennis.png"));

        User u = new(155, "testmail.com", "dadadada", null,null,null);

       MainPage = new Principale(u, new List<User>());
        */

        //MainPage = new SpotDetail(SpotStub.LoadSpots()[0]);

        //Spot s = SpotStub.LoadSpots()[0];
        //MainPage = new SpotDetail(s);



	}
}
