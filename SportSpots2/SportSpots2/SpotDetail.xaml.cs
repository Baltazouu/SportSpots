using Model;

namespace SportsSpots;


public partial class SpotDetail : ContentPage
{

	Spot spot { get; set; }

	public SpotDetail(Spot s)
	{
		spot = s;
		BindingContext = spot;

		InitializeComponent();
	}

	public async void CloseClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	private void ClickedItinerary(object sender, EventArgs e)
	{
		string userLocation = userLocationText.Text;		
        if(BindingContext is Spot sp)
		{
			string linkItinary = $"https://www.openstreetmap.org/directions?from={userLocation}&to={sp.Coord_x},{sp.Coord_y}";
			webViewMap.Source = linkItinary;
		}

    }

	private void ChangeNoteSpot(Object sender,EventArgs e)
	{
		if (Notes.Text == null || Notes.Text == "")
			errorNotes.Text = "Entrez des caracteres ! ";

		else
		{
			
			
			spot.AddNotes(Notes.Text);
            errorNotes.Text = "";
			Notes.Text = null;
        }
	}

}