using Model;

namespace SportsSpots;


public partial class SpotDetail : ContentPage
{
	public SpotDetail(Spot s)
	{

		BindingContext = s;

		InitializeComponent();
	}

	public async void CloseClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	private async void ClickedItinerary(object sender, EventArgs e)
	{
		string userLocation = userLocationText.Text;		
        if(BindingContext is Spot sp)
		{
			string linkItinary = $"https://www.openstreetmap.org/directions?from={userLocation}&to={sp.Coord_x},{sp.Coord_y}";
			webViewMap.Source = linkItinary;
		}

    }
}