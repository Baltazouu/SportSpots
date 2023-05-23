using Model;


namespace SportsSpots;

public partial class Principale : ContentPage
{
    User Utilisateur;

    public Principale(User user)
    {

        Utilisateur = user;


        BindingContext = Utilisateur;

        InitializeComponent();

        
    }



}


