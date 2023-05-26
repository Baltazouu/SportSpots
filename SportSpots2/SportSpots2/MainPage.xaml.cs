using Model;
using Persistance;

namespace SportsSpots;

public partial class MainPage : ContentPage
{

    // page inscription

    string Pass;
    string Mail;

    Data Dt = new Data();
    DataContractJson jsonSource = new DataContractJson();

    List<User> all;


    public MainPage()
	{
		
        InitializeComponent();
        Dt = new Data();
        jsonSource = new DataContractJson();

        //all = Dt.LoadData(jsonSource).Item2;

        UserStub source = new();
        all = Dt.LoadData(source).Item2;

    }


	async void OnInscriptionClicked(Object sender,EventArgs e)
	{
		
        

        if(Dt.CheckMailExist(Mail,all))
        {
            ResultLabel.Text = "Adresse Mail déjà utilisée !";
        }
        
        else if(entryPass.Text ==  null || entryPass.Text.Length < 6)
        {
            ResultLabel.Text = "Entrez un mot de passe d'au moins 6 Caractères !";
        }

        else if(entryMail.Text == null || entryMail.Text.Length < 5)
        {
            ResultLabel.Text = "Entrez Une Adresse email valide !";
        }

        else
        { 
            ResultLabel.Text = "Connexion en cours ...";

            Mail = entryMail.Text;
            Pass = Hash.HashPassword(entryPass.Text);

            User u = new(Dt.GetNewUserId(all), Mail, Pass, SpotStub.LoadSpots(), null);

            all.Add(u);
            Dt.SaveData(jsonSource, all);

            await Navigation.PushAsync(new Principale(u));
        }

    }

    async void OnConnexionClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        //await Navigation.PushAsync(new Connexion());
    }
}


