using Model;


namespace SportsSpots;

public partial class Principale : ContentPage
{
    User User;

    public Principale(User user)
    {

        Data dt;

        User = user;
        InitializeComponent();
    }



}


