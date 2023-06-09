using Model;
using Persistance;

namespace SportsSpots;


public partial class SpotDetail : ContentPage
{
	User User { get;set; }
	Spot Spot { get; set; }

	Data Dt { get;  }

	DataContractJson Jsource { get;  }

	List<User> All;

	public SpotDetail(Spot s,User u, Data dt, DataContractJson jsource, List<User> all)
	{
		Spot = s;
		User = u;
		BindingContext = Spot;
		Dt = dt;
		Jsource = jsource;
		All = all;

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

		
		else if(!User.SpotPresentToFav(Spot))
		{
			errorNotes.Text = "Ce spot doit etre en favoris \n pour ajouter des notes!";
		}

		else
		{
			Spot.AddNotes(Notes.Text);
			Dt.SaveData(Jsource, All);
            errorNotes.Text = "";
			Notes.Text = null;
        }
	}

}