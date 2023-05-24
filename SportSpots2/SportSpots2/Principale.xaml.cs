using Model;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;

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
    /*
    public void OnClickedSport(object sender, EventArgs e)
    {


        if(sender is StackLayout stackLayout)
        {
            if(stackLayout.BackgroundColor == Color.FromRgb(0, 0, 255))
            {
                // change back do grey
                stackLayout.BackgroundColor = Color.FromRgb(192, 192, 192);
            }
            //change to grey
            else stackLayout.BackgroundColor = Color.FromRgb(0, 0, 255);
        }
       
    }
    */
    bool IsClickedSport = false;
    bool IsClickedStar = false;

    public void OnClickedSport(object sender, EventArgs e)
    {
        if (sender is StackLayout stackLayout)
        {
            if (IsClickedSport)
            {
                // Changement en gris
                // stackLayout.BackgroundColor = Color.FromArgb("808080");
                stackLayout.BackgroundColor = null;

                // delete from to search when clicked
                if(stackLayout.BindingContext is Sport sp)
                {
                    Modelview.toSearch.Remove(sp);
                    
                }
                
            }
            else
            {
                // Changement en bleu
                stackLayout.BackgroundColor = Color.FromRgb(0, 0, 255);
                if(stackLayout.BindingContext is Sport sp)
                {
                    // recuperer l'objet et l'ajouter a la liste
                    Modelview.toSearch.Add(sp);
                    
                }
                 
            }

            IsClickedSport = !IsClickedSport;
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



}


