using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Model;
namespace Maui1
{
    public class User
    {
        int Id { get; set; }
        string Mail { get; set; }
        
        string Passwd { get; set; }

        List<Spot> favorite_spots;
        List<Sport> favorite_sport;
        List<Search> searchs;

        public string Name { get; set; }

        void searchSpot()
        {
            Console.WriteLine("[Search a Spot]");
            
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

        public void RequListSearchs()
        {
            string s = """SELECT * FROM SEARCHS WHERE""";
        }


        public User(int id, string mail, string _passwd)

        {
            Id = id;
            Mail = mail;
            Passwd = _passwd;

            while(true)
            {
                menue(); // print menue
                options(); // select user choice
            }
        }
        

        public void search()
        {

        }

        public void menue()
        {
            Console.WriteLine("[SportsSpots Menue]");
            Console.Write(""""
                1 : Search a Spot
                2 : Display Favorite Spots
                3 : Display Favorite Sports  
                4 : Leave SportsSpots
                Entrez votre choix : 
                """");
        }


        public void affSports()
        {
            Console.Write("""

                [SearchSpots]
                Type numbers following to theses sports :
                1.  Football Fields
                2.  Basketball Fields
                3.  Rugby Fields
                4.  CityStades
                5.  Dojos
                6.  Gym
                7.  Boxing gym
                8.  Skateparks
                9.  Petanque
                10. Fitness Trails
                11. Swimming Pools
                12. Golfs
                13. VolleyBall
                14. Velodrome
                15. Tennis Courts
                16. Handball Fields
                17. Athletics

                """);
        }

        public void options()
        {
            string c = Console.ReadLine();

            while (c!="1" && c!="2" && c!="3" && c != "4")
            {
                Console.Write("Error, Please Choose Between Theses Choices : ");
                menue();
                c = Console.ReadLine();
            }
            switch(c)
            {
                case "1":
                    // call search function
                    

                    
                    break;

                case "2":
                    // call fav spots function
                    break;

                case "3":
                    // call fav sports func
                    break;

                case "4":
                    // exit
                    break;
            }
           
        }


    }
}
