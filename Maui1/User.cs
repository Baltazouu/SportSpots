using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui1
{
    public class User
    {

        string Mail { get; set; }
        
        string Passwd { get; set; }

        List<Spot> favorite_spots;
        List<Sport> favorite_sport;
        List<Search> searchs;

        public string Name { get; set; }

        void searchSpot()
        {
            //to do
        }
        void addToFavorite(Spot s)
        {
            favorite_spots.Insert(0, s);
        }

        void addToFavorite(Sport s)
        {
            favorite_sport.Insert(0, s);
        }

        void addToHistory(Search s)
        {
            searchs.Insert(0,s);
        }

        List<Search> getHistory() 
        {
            return searchs;
        }

    }
}
