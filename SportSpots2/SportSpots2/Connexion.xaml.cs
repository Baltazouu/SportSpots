using Model;
using Persistance;
using System.Xml;

namespace SportsSpots;



public partial class Connexion : ContentPage
{

    string Pass;
    string Mail;

    Data Dt = new Data();
    DataContractJson jsonSource = new DataContractJson();

    List<User> all;

    public Connexion()
	{
		InitializeComponent();

        Dt = new Data();
        jsonSource = new DataContractJson();

        // tester avec le stub

        all = Dt.LoadData(jsonSource).Item2;

        // all = Dt.LoadData(jsonSource).Item2;


    }

    private async void OnConnexionClicked(object sender, EventArgs e)
    {

        Mail = entryMail.Text;
        if (entryPass.Text != null)
        {
            Pass = Hash.HashPassword(entryPass.Text);
        }


        if (!Dt.CheckMailExist(Mail, all) || !Dt.CheckRightPass(Mail, Pass, all))
        {
            ResultLabel.Text = "Adresse ou Mot de Passe Incorrect !";
        }
        else
        {
            ResultLabel.Text = "Connexion en cours..";

            User user = Dt.FindUser(Mail, Pass, all);

           
            await Navigation.PushAsync(new Principale(user));

        }
    }

    private async void OnInscriptionClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new MainPage());
    }
}