using Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using Microsoft.VisualBasic;
using Persistance;

namespace SportsSpots;

public partial class Principale : ContentPage
{

    Data Dt { get; set; } = new Data();
    DataContractJson JsonSource { get; set; } = new DataContractJson();

    List<User> All { get; set; }

    BindingClass Modelview { get; set; }

    public Principale(User user,List<User> allusers)
    {
       Modelview = new BindingClass(user);
       BindingContext = Modelview;
       InitializeComponent();
        All = allusers;
}

    void ClickedAccount(object sender, EventArgs e)
    {
        ParametreUser.IsVisible = !ParametreUser.IsVisible;
    }

    private async void ClickedResult(object sender, EventArgs e)
    {
        
        if(sender is SearchBar)
        {
            if (searchCity.Text == "" || searchCity.Text == null || searchCity.Text.Length < 2)
            {
                errorSearchLabel.Text = "Entrez une ville de recherche valide";
            }
            else if (Modelview.toSearch.Count < 1)
            { errorSearchLabel.Text = "Séléctionnez au moins un sport à rechercher"; }
            else
            {
                
                errorSearchLabel.Text = null;
                searchinfo.Text = "Chargement...";
                ResultSearch.IsVisible = true;
                // rechercher les spots

                await Modelview.executeResearch(searchCity.Text);

                if(Modelview.SpotsFinded.Count <1 ) 
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

                for (int i = Modelview.toSearch.Count - 1; i >= 0; i--)
                {
                    if (Modelview.toSearch[i].Name == sport.Name)
                    {
                        find = true;
                        stackLayout.BackgroundColor = null;
                        Modelview.toSearch.RemoveAt(i);
                        OnPropertyChanged(nameof(Modelview));
                        break;
                    }
                }

                if (!find)
                {
                    Modelview.toSearch.Add(sport);
                    OnPropertyChanged(nameof(Modelview));
                    stackLayout.BackgroundColor = Color.FromArgb("737373");
                }

                
            }
        }
    }


    public void OnClickedStar(object sender, EventArgs e)
    {
        if(sender is Image img)
        {
            if (img.Source == Modelview.star)
            {
                img.Source = Modelview.starfilled;

                if (img.BindingContext is Spot spot)
                {
                    spot.Favorite = "starfilled.png";
                    Modelview.Utilisateur.AddSpot(spot);
                }

                // et ajouter à list des favoris
            }
            else
            {
                img.Source = Modelview.star;
                if (img.BindingContext is Spot spot)
                {
                    spot.Favorite = "star.png";
                    Modelview.Utilisateur.RemoveSpot(spot);
                }
            }
            
        }
    }

    private void OnChangeMailClicked(object sender, EventArgs e)
    {
        string userEmail = Modelview.Utilisateur.Mail;
        string newEmail = NewTextMail.Text;
        string password = Hash.HashPassword(MailMotDePasse.Text);

        if (password == Modelview.Utilisateur.Passwd)
        {
            if (Dt.CheckMailExist(newEmail, All))
            {
                errorNewMailLabel.Text = "Erreur cette adresse email est déjà utilisée";
            }
            else
            {
                Modelview.Utilisateur.ChangeMail(newEmail);

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
        string userPassword = Modelview.Utilisateur.Passwd;
        string actualPassword = Hash.HashPassword(ActualPassword.Text);
        string newPassword = Hash.HashPassword(NewTextPassword.Text);
        string confirmNewPassword = Hash.HashPassword(ConfirmNewPassword.Text);

        

        if (actualPassword == userPassword)
        {
            if (newPassword == confirmNewPassword)
            {
                if (NewTextPassword.Text.Length >= 6)
                {
                    Modelview.Utilisateur.ChangePasswd(newPassword);

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

}


