using Model;
using Persistance;
using System.Diagnostics;

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

        //UserStub source = new();
        //all = Dt.LoadData(source).Item2;
        all = Dt.LoadData(jsonSource).Item2;


    }

    /// <summary>
    /// Async Method to create an account to sportspots
    /// </summary>
    /// <param name="sender">button</param>
    /// <param name="e"></param>
	async void OnInscriptionClicked(Object sender,EventArgs e)
	{
		
        

        if(Dt.CheckMailExist(entryMail.Text, all))
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

            User u = new(Dt.GetNewUserId(all), Mail, Pass, null, null,null);

            all.Add(u);
            Dt.SaveData(jsonSource, all);

            Debug.WriteLine("User Added to json");

            await Navigation.PushAsync(new Principale(u, all));
        }

    }

    /// <summary>
    /// Display the connexion page instead
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void OnConnexionClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        //await Navigation.PushAsync(new Connexion());
    }
}


