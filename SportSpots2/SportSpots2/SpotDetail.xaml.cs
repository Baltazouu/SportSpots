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

}