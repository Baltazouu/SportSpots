using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Menus
    {
        public Menus() { }

        User u = new(12346,"test.com@gmail.com","password");

        

        public void StartMenue()
        {
            Console.WriteLine("Welcome To SportsSpots APP\n1. Connection\n2. Inscription");
        }

        public void UserMenue()
        {
            string choice = "";
            do
            {
                Console.WriteLine("""
                [UserMenu]
                1. See Our Favspots !
                2. See Our FavSports !
                3. Search A Spot !
                4. Change Passwd Or Mail
                5. Exit !
                """);


                if(choice == "1")
                {
                    //
                }

            } while (choice != "5");
        }


    }
}
