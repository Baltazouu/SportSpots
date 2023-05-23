using Model;
using System.Collections.ObjectModel;

namespace SportsSpots;

public partial class Principale : ContentPage
{

    User Utilisateur;
    SportStub SportsAvaibles = new SportStub();

    public Principale(User user)
    {

        ViewModel1 model = new ViewModel1(user);

        BindingContext = model;

        InitializeComponent();

    }

}


