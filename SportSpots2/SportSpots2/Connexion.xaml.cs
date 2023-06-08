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

    List<User> all = new();

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
            entryMail.Text = null;
            //entryPass.Text = null;

            ResultLabel.Text = "Connexion en cours..";

            

            User user = Dt.FindUser(Mail, Pass, all);

            entryPass.Text = null;
           
            await Navigation.PushAsync(new Principale(user,all));

            ResultLabel.Text = null;

        }
    }

    private async void OnInscriptionClicked(object sender, EventArgs e)
    {
        
        await Navigation.PushAsync(new MainPage());
    }
}