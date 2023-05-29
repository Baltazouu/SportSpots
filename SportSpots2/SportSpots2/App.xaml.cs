using Model;


namespace SportsSpots;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//MainPage = new ViewSpot();

		//User u = new(155,"testmail.com","dadadada",SpotStub.LoadSpots(), SportStub.Loadsport());

		//MainPage = new Principale(u);
	}
}
