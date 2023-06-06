using Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using Microsoft.VisualBasic;
using Persistance;
using System.Diagnostics;
namespace SportsSpots;

/// <summary>
/// Princpal View Code Behind
/// On This Page the user can find spots, see favorite sports, spots his search history
/// You can also manage your account here
/// </summary>
public partial class Principale : ContentPage
{

    Data Dt { get; set; } = new Data();
    DataContractJson JsonSource { get; set; } = new DataContractJson();

    List<User> All { get; set; }

    BindingClass Binding { get; set; }

    public Principale(User user, List<User> allusers)
    {
        Binding = new BindingClass(user);
        BindingContext = Binding;
        InitializeComponent();
        All = allusers;


    }


    /// <summary>
    /// Show Details about account Ex change : password,mail or disconnect
    /// </summary>
    /// <param name="sender"> Button </param>
    /// <param name="e"></param>
    void ClickedAccount(object sender, EventArgs e)
    {
        ParametreUser.IsVisible = !ParametreUser.IsVisible;
        if (ParametreUser.IsVisible)
        {
            accountArrow.Source = "fleche_haut.png";
        }
        else
        {
            accountArrow.Source = "fleche_bas.png";
        }
    }


    /// <summary>
    /// Search Spots Using data-es API with a town selected by entry and a list of Sport
    /// </summary>
    /// <param name="sender"> SearchBar </param>
    /// <param name="e"></param>
    private async void ClickedResult(object sender, EventArgs e)
    {
        int postalcode;
        if (sender is SearchBar)
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

                await Binding.ExecuteResearch(searchCity.Text, postalcode);

                if (Binding.SpotsFinded.Count < 1)
                {
                    searchinfo.Text = $"Aucun Spot Trouvé Pour {searchCity.Text}";
                }
                else { searchinfo.Text = "Spots Trouvés :"; }


            }

        }
        if (sender is ImageButton)
        {
            ResultSearch.IsVisible = false;
        }
    }

    /// <summary>
    /// Goal : Add a sport to searchList for finding spots around you
    /// </summary>
    /// <param name="sender">Sport selected</param>
    /// <param name="e"></param>
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

    /// <summary>
    /// This Method Allow User to add a Spot to his favorite Spot List
    /// </summary>
    /// <param name="sender">Image star/starfilled</param>
    /// <param name="e"></param>
    public void OnClickedStarSport(object sender, EventArgs e)
    {
        if (sender is Image img)
        {
            //Sport s = (Sport)img.BindingContext;
            if (img.BindingContext is Sport sport)
            {
                if (sport.Favorite == "star.png")
                {
                    sport.Favorite = "starfilled.png";
                    img.Source = "starfilled.png";
                    // and add to favorite
                    Binding.Utilisateur.Favsports.Add(sport);




                    Dt.SaveData(JsonSource, All);
                }
                else
                {
                    sport.Favorite = "star.png";
                    img.Source = "star.png";
                    Binding.Utilisateur.Favsports.Remove(sport);



                    Dt.SaveData(JsonSource, All);
                }
            }
        }
    }


    /// <summary>
    /// This Method Allows User to add a spot to his favorite list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnClickedStar(object sender, EventArgs e)
    {
        if (sender is Image img)
        {
            Spot sp = (Spot)img.BindingContext;

            if (sp.Favorite == "star.png")
            {
                sp.Favorite = "starfilled.png";
                Binding.Utilisateur.AddToFavSpot(sp);
                Binding.UpdatedSpotFinded();
            }
            else
            {
                sp.Favorite = "star.png";
                Binding.Utilisateur.RemoveToFavSpot(sp);
                Binding.UpdatedSpotFinded();
            }

        }
                        
    }
  

    /// <summary>
    /// This Method Allows to user to change is email adress account from view
    /// </summary>
    /// <param name="sender"> Button </param>
    /// <param name="e"></param>
    private void OnChangeMailClicked(object sender, EventArgs e)
    {
        string userEmail = Binding.Utilisateur.Mail;
        string newEmail = NewTextMail.Text;

        if(MailMotDePasse.Text == null || MailMotDePasse.Text == "")
        {
            errorNewMailLabel.Text = "Entrez votre mot de passe !";
            return;
        }

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

    /// <summary>
    /// This Method allows user to change his passoword from the view page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnChangePasswordClicked(object sender, EventArgs e)
    {

        if(ActualPassword.Text == null ||  ActualPassword.Text.Length <6)
        {
            errorNewPasswordLabel.Text = "entrez votre mot de passe actuel !";
            return;
        }

        if(NewTextPassword.Text == null || ActualPassword.Text.Length > 6)
        {
            errorNewPasswordLabel.Text = "Entrez Un Nouveau Mot de passe d'au moins 6 caratères";
            return;
        }


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


    /// <summary>
    /// This method allows user to open a detail spot when a Spot is clicked on the result view content
    /// </summary>
    /// <param name="sender">Image direction</param>
    /// <param name="e"></param>
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

                
       

                //await Navigation.PushAsync(detail);// modal en attendant
                await Navigation.PushModalAsync(new SpotDetail(s));

            }
        }
        

    }

    /// <summary>
    /// This Method is made to disconnet the user from the princpal page
    /// </summary>
    /// <param name="sender">button</param>
    /// <param name="e"></param>
    public async void OnDisconnect(object sender, EventArgs e)
    {

        Dt.SaveData(JsonSource, All);
        await Navigation.PopToRootAsync();
    }

}


