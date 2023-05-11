
using Model;
using System.Diagnostics;

namespace ConsoleProject
{
    internal class UserActionsSQL : User
    {
        
        /// <summary>
        /// Classe Heritee de User Permettant d'utiliser l'application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public UserActionsSQL(int id, string name, string password)
            :base(id, name, password,null,null)
        { }

        /// <summary>
        /// Methode asynchrone Menue qui permet de gerer les choix du programme
        /// </summary>
        /// <returns></returns>
        public async Task ChooseAction()
        {
            string? choice;
            do
            {
                Console.WriteLine("[UserActions]\n1. Search A Spot\n2. See my favspots\n3. See my favsports\n4. Exit SportsSpots");
                Console.Write("Enter Your Choice : ");
                choice = Console.ReadLine();
                while (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.WriteLine("Error ! Enter A choice Between 1 and 3");
                    Console.Write("Enter Your Choice : ");
                    choice = Console.ReadLine();

                }
                switch (choice)
                {
                    case "1":
                        await SearchSpots();
                        break;

                    case "2":
                       
                        foreach(Spot s in FavSpots)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                    case "3":
                        FavSports();

                        break;
                }
            } while (choice != "4");

            Console.WriteLine("[Saving...]");

            Console.WriteLine("Finished");

        }

        /// <summary>
        /// Methode Asynchrone permettant de rechercher des Spots 
        /// </summary>
        /// <returns>nothing</returns>
        public async Task SearchSpots()
        {
            List<Sport> sportSearchs = new();

            List<Spot> finded = new();

            string? town;
            bool stop = false;
            string? addnew;

            Console.WriteLine("[SearchSpots]\n");
            do {
                Console.Write("Enter The Town to Search the spot :");
                town = Console.ReadLine();
            } while (town == "" || town == null);

            sportSearchs.Add(AddSport());

            do
            {
                do
                {
                    Console.WriteLine("Ajouter Un Autre Sport A Rechercher ?\n1 : Oui\n2 : Non ");
                    Console.Write("Entrez Votre Choix :");
                    addnew = Console.ReadLine();

                } while (addnew != "1" && addnew != "2");
                if(addnew == "1")
                {
                   Sport s = AddSport();
                    bool present = false;
                   foreach (Sport s2 in sportSearchs)
                    {
                        if(s2.Name == s.Name)
                        { Console.WriteLine($"The {s.Name} Sport Is Already in the list to search"); }
                        present = true;

                    }
                    if (!present)
                    { sportSearchs.Add(s); }
                }
                else { stop = true; }
            } while (!stop);


            try
            {
                Search Research = new(town, sportSearchs);
                finded = await Research.ExecuteSearch();
                string?choice;
                foreach (Spot s in finded)
                {
                    Console.WriteLine(s);
                    Console.WriteLine("1. Add Spot To my favorite List");
                    Console.WriteLine("2. Get Route to the spot");
                    Console.WriteLine("3. Display next");

                    do
                    {
                        Console.Write("Enter Your Choice : ");
                        choice = Console.ReadLine();
                    }
                    while (choice != "1" && choice != "2" && choice != "3");

                    if(choice == "1")
                    {
                        if(!AddSpot(s))
                        {
                            Console.WriteLine("Spot Already in your favorite list !");
                        }

                    }
                    if (choice == "2")
                    {
                        OpenBrowser($"www.google.com/search?&q=45.735176%2C+3.008964&sourceid=opera&ie=UTF-8&oe=UTF-8");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during search: {0}", ex.Message);
            }

        }

        /// <summary>
        /// Methode Permettant d'afficher le Spot sur google maps 
        /// </summary>
        /// <param name="url"></param>
        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Methode Permettant d'ajouter un Sport a la liste de recherche
        /// </summary>
        /// <returns>Sport</returns>
        public Sport AddSport()
        {
            Sport?s = null;
            string? choice;
            List<Sport> avaible = SportStub.Loadsport();
            
            Console.WriteLine("Enter A number Corresponding To A Sport !");
            
            int i = 1;

            foreach (Sport sport in avaible)
            {
                Console.WriteLine($"{i} : {sport.ToString()}");
                i++;
            }

            Console.Write("Enter A Number :");
            choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"
                    && choice != "6" && choice != "7" && choice != "8" && choice != "9")
            {

                Console.Write(" Error ! Enter A Number :");
                choice = Console.ReadLine();
            }



                switch (choice)
                {
                    case "1":
                        s= avaible[0];
                        break;

                    case "2":
                        s = avaible[1];
                        break;

                    case "3":
                        s = avaible[2];
                        break;

                    case "4":
                        s = avaible[3];
                        break;

                    case "5":
                        s = avaible[4];
                        break;
                    case "6":
                        s = avaible[5];
                        break;

                    case "7":
                        s = avaible[6];
                        break;

                    case "8":
                        s = avaible[7];
                        break;

                    case "9":
                        s = avaible[8];
                        break;
                    default:
                        s = avaible[0];
                        break;
                    
                    }
            return s;
        }

        public void FavSports()
        {

            string? choice2;
            Console.WriteLine("[FavSpots : ]");
            if (Favsports.Count() < 1 || Favsports == null)
            {
                Console.WriteLine("There is no sports in your favorite list !");
               
            }
            else
            {
                foreach (Sport spot in Favsports)
                {
                    Console.WriteLine($"{spot}");
                }
            }
            
            do
            {
                Console.WriteLine("1. Add Sports To My Favorite List !");
                Console.WriteLine("2. Back to main menue");
                Console.Write("Enter Your Choice : ");
                choice2 = Console.ReadLine();
            }
            while (choice2 != "1" && choice2 != "2");

            /*if (choice2 == "1")
            {
                NewFavsports.Add(AddSport());
            }*/
        }
    }
}
