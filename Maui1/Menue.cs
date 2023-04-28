using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maui1.Connexion;

using Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maui1
{
    public class Menue
    {
        public Menue() 
        {
            /*Console.Write("""

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
            }           */
        }


        public Sport MenueRech()
        {
            Console.WriteLine("[Sports]");
            
            SportStub s = new SportStub();

            List<Sport> SportAvaible = s.Loadsport();

            int i=1;

            foreach(Sport sport in SportAvaible)
            {
                Console.WriteLine($"{i}. {sport.Name}");
                i++;    
            }
            
            Console.WriteLine("Enter The Number Of Your Choice : ");
                
            string choice = Console.ReadLine();
            //Console.WriteLine(choice.GetType().Name);

            bool valid = int.TryParse(choice, out i);
            while (!valid || i < 0 || i > SportAvaible.Count)
                {
                    Console.WriteLine("Error Choose between our sports");
                    Console.Write("Enter The Number Of Your Choice : ");
                    
                    choice = Console.ReadLine();
                    valid = int.TryParse(choice, out i);
            }
            int v = Convert.ToInt32(choice);
              
            //Console.WriteLine("Convert en int : ", v);

            return SportAvaible[Convert.ToInt32(choice)-1];   

             //return SportAvaible[0];
        }

    }
}
