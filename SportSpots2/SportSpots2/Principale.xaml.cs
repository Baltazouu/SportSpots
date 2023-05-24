using Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using Microsoft.VisualBasic;

namespace SportsSpots;

public partial class Principale : ContentPage
{


    ViewModel1 Modelview { get; set; }

    public Principale(User user)
    {

       Modelview = new ViewModel1(user);

        BindingContext = Modelview;

        InitializeComponent();

    }
 
    bool IsClickedStar = false;

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
                    stackLayout.BackgroundColor = Color.FromRgb(0, 0, 255);
                }

                
            }
        }
    }




    public void OnClickedStar(object sender, EventArgs e)
    {
        if(sender is Image img)
        {
            if (!IsClickedStar)
            {
                img.Source = "starfilled.png";
            }
            else img.Source = "star.png";

            IsClickedStar = !IsClickedStar;
        }
    }


    public void StarFav()
    {
        foreach(var Sport in Modelview.Utilisateur.Favsports)
        { 
            foreach(var sportView in Modelview.SportsAvaibles.SportCollection)
            {
                if(Sport.Name.Equals(sportView.Name))
                {

                }
            }
        }


}


