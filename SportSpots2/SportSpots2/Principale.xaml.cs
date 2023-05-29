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

    ViewModel1 Modelview { get; set; }

    public Principale(User user,List<User> allusers)
    {
       Modelview = new ViewModel1(user);
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
            if (img.Source == Modelview.star )
            {
                img.Source = Modelview.starfilled;
                // et ajouter à list des favoris
            }
            else img.Source = Modelview.star;
            // to do later remove to favlist
        }
    }


    public void StarFav()
    {
        foreach (var Sport in Modelview.Utilisateur.Favsports)
        {
            foreach (var sportView in Modelview.SportsAvaibles.SportCollection)
            {
                if (Sport.Name.Equals(sportView.Name))
                {

                }
            }
        }
    }

    private void OnChangeMailClicked(object sender, EventArgs e)
    {
        string userEmail = Modelview.Utilisateur.Mail;
        string newEmail = NewTextMail.Text;

        if (newEmail != userEmail)
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
        else errorNewMailLabel.Text = "Veuillez Saisir Un Nouvel Email !";
    }

    }


