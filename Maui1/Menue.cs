using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui1
{
    internal class Menue
    {
        public Menue() 
        {
            Console.Write("""

            [SportSpotMenue] : 

            1 : Login 
            2 : Inscription

            """);
            Console.Write("Enter Your Choice : ");
            string c = Console.ReadLine();

            while(c != "1" &&  c != "2")
            {
                Console.WriteLine("Choose Only Between 1 or 2 !");

                c = Console.ReadLine();
            }

            if ( c == "1")
            {
                Login l = new Login();
            }

            if ( c == "2") 
            {
                Inscription i = new Inscription();
            }           
        }

    }
}
