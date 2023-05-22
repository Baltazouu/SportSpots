namespace SportsSpots;

public partial class Connexion : ContentPage
{

	public Connexion()
	{
		InitializeComponent();

    }

    private async void OnInscriptionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}