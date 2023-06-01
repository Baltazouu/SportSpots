using Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using Microsoft.VisualBasic;
using Persistance;
using System.Diagnostics;
namespace SportsSpots;

public partial class Principale : ContentPage
{

    Data Dt { get; set; } = new Data();
    DataContractJson JsonSource { get; set; } = new DataContractJson();

    List<User> All { get; set; }

    BindingClass Binding { get; set; }

    public Principale(User user,List<User> allusers)
    {
       Binding = new BindingClass(user);
       BindingContext = Binding;
       InitializeComponent();
       All = allusers;


}



void ClickedAccount(object sender, EventArgs e)
    {
        ParametreUser.IsVisible = !ParametreUser.IsVisible;
    }

    private async void ClickedResult(object sender, EventArgs e)
    {
        int postalcode;
        if(sender is SearchBar)
        {
            if (searchCity.Text == "" || searchCity.Text == null || searchCity.Text.Length < 2)
            {
                errorSearchLabel.Text = "Entrez une ville de recherche valide";
            }
            else if (Binding.toSearch.Count < 1)
            { errorSearchLabel.Text = "Séléctionnez au moins un sport à rechercher"; }
            else
            {
                try
                {
                    postalcode = Convert.ToInt32(searchPostalCode.Text);
                    Debug.WriteLine("Code Postal : {0}", postalcode);

                }
                catch (Exception)
                {
                    postalcode = 0;
                }

                errorSearchLabel.Text = null;
                searchinfo.Text = "Chargement...";
                ResultSearch.IsVisible = true;
                // rechercher les spots

                await Binding.executeResearch(searchCity.Text, postalcode);

                if (Binding.SpotsFinded.Count <1 ) 
                {
                    searchinfo.Text = $"Aucun Spot Trouvé Pour {searchCity.Text}";
                }
                else { searchinfo.Text = "Spots Trouvés :"; }
               
                
            }
                   
        }
        if(sender is ImageButton)
        {
            ResultSearch.IsVisible = false;
        }
    }
    

    public void OnClickedSport(object sender, EventArgs e)
    {
        if (sender is StackLayout stackLayout)
        {
            if (stackLayout.BindingContext is Sport sport)
            {
                bool find = false;

                for (int i = Binding.toSearch.Count - 1; i >= 0; i--)
                {
                    if (Binding.toSearch[i].Name == sport.Name)
                    {
                        find = true;
                        stackLayout.BackgroundColor = null;
                        Binding.toSearch.RemoveAt(i);
                        OnPropertyChanged(nameof(Binding));
                        break;
                    }
                }

                if (!find)
                {
                    Binding.toSearch.Add(sport);
                    OnPropertyChanged(nameof(Binding));
                    stackLayout.BackgroundColor = Color.FromArgb("737373");
                }

                
            }
        }
    }

    public void OnClickedStarSport(object sender,EventArgs e)
    {
        if(sender is Image img)
        {
            if(img.BindingContext is Sport sport)
            {
                if(sport.Favorite == "star.png")
                {
                    sport.Favorite = "starfilled.png";
                    img.Source = "starfilled.png";
                    // and add to favorite
                    Binding.Utilisateur.Favsports.Add(sport);
                    OnPropertyChanged(nameof(Binding.Utilisateur.Favsports));
                    Dt.SaveData(JsonSource, All);
                }
                else
                {
                    sport.Favorite = "star.png";
                    img.Source = "star.png";
                    Binding.Utilisateur.Favsports.Remove(sport);
                    OnPropertyChanged(nameof(Binding.Utilisateur.Favsports));
                    Dt.SaveData(JsonSource, All);
                }
            }    
        }
    }

    public void OnClickedStar(object sender, EventArgs e)
    {
        if(sender is Image img)
        {
            if (img.Source == Binding.star)
            {
                img.Source = Binding.starfilled;

                if (img.BindingContext is Spot spot)
                {
                    spot.Favorite = "starfilled.png";
                    Binding.Utilisateur.AddSpot(spot);
                }

                // et ajouter à list des favoris
            }
            else
            {
                img.Source = Binding.star;
                if (img.BindingContext is Spot spot)
                {
                    spot.Favorite = "star.png";
                    Binding.Utilisateur.RemoveSpot(spot);
                }
            }
            
        }
    }

    private void OnChangeMailClicked(object sender, EventArgs e)
    {
        string userEmail = Binding.Utilisateur.Mail;
        string newEmail = NewTextMail.Text;
        string password = Hash.HashPassword(MailMotDePasse.Text);

        if (password == Binding.Utilisateur.Passwd)
        {
            if (Dt.CheckMailExist(newEmail, All))
            {
                errorNewMailLabel.Text = "Erreur cette adresse email est déjà utilisée";
            }
            else
            {
                Binding.Utilisateur.ChangeMail(newEmail);

                // a refaire mieux

               // All.Remove(Modelview.Utilisateur);
                //All.Add(Modelview.Utilisateur);
                //
                Dt.SaveData(JsonSource, All);
                errorNewMailLabel.Text = "Changement Effectué !";
            }
        }
        else errorNewMailLabel.Text = "Le mot de passe du compte n'est pas bon";
    }

    private void OnChangePasswordClicked(object sender, EventArgs e)
    {
        string userPassword = Binding.Utilisateur.Passwd;
        string actualPassword = Hash.HashPassword(ActualPassword.Text);
        string newPassword = Hash.HashPassword(NewTextPassword.Text);
        string confirmNewPassword = Hash.HashPassword(ConfirmNewPassword.Text);

        

        if (actualPassword == userPassword)
        {
            if (newPassword == confirmNewPassword)
            {
                if (NewTextPassword.Text.Length >= 6)
                {
                    Binding.Utilisateur.ChangePasswd(newPassword);

                    Dt.SaveData(JsonSource, All);
                    errorNewPasswordLabel.Text = "Changement Effectué !";
                }
                else errorNewPasswordLabel.Text = "Entrez un mot de passe d'au moins 6 caractères";
                
            }
            else
            {
                errorNewPasswordLabel.Text = "Les 2 mot de passes sont différents";
            }
        }
        else errorNewPasswordLabel.Text = "Le mot de passe du compte n'est pas bon !";
    }

    public async void OpenDetail(object sender,EventArgs e)
    {
        Debug.WriteLine("Into OpenDetail");
        if(sender is Image  img)
        {
            Debug.WriteLine("into viewCell condition");
            if (img.BindingContext is Spot s)
            {
                Debug.WriteLine("Into spot condition");

                Binding.Utilisateur.AddSpotToHistory(s);
                Dt.SaveData(JsonSource, All);


                SpotDetail detail = new SpotDetail(s);

                
                //string urlLink = $"https://www.google.fr/maps/@{s.Coord_x},{s.Coord_y}";

                //await Navigation.PushAsync(detail);// modal en attendant
                await Navigation.PushModalAsync(new SpotDetail(s));

            }
        }
        

    }

    public async void OnDisconnect(object sender, EventArgs e)
    {

        Dt.SaveData(JsonSource, All);
        await Navigation.PopToRootAsync();
    }
}


