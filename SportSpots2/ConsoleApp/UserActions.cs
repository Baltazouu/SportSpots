using Model;


namespace ConsoleApp
{
    internal class UserActions
    {
        User User;

        Menue menue = new Menue();

        public UserActions(User u)
        {
            User = u;
        }


        public async Task actions()
        {

            Console.WriteLine($"Welcome Back {User.Mail} , {User.Id} !");
            string? choice;
            do
            {
                menue.Actions();
                Console.Write("Enter Your Choice : ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await SearchSpots();
                        break;

                    case "2":
                        menue.MyFavspots(User.FavSpots);
                        
                        break;

                    case "3":
                        menue.MyFavSports(User.Favsports);
                        break;

                    case "5":

                        break;

                    case "6":

                        break;

                }
            } while (choice == "6");
            


        }


        public Sport AddSport()
        {

            string? choice;
            List<Sport> avaible = SportStub.Loadsport();
            Sport?s = null;

            Console.WriteLine("Enter A number Corresponding To A Sport !");

            int i = 1;

            foreach (Sport sport in avaible)
            {
                Console.WriteLine($"{i} : {sport.ToString()}");
                i++;
            }

            do
            {
                Console.Write(" Enter A Number in the list : ");
                choice = Console.ReadLine();
            }
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"
                    && choice != "6" && choice != "7" && choice != "8" && choice != "9");


            switch (choice)
            {
                case "1":
                    s = avaible[0];
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


        public async Task SearchSpots()
        {
            List<Sport> sportSearchs = new();

            List<Spot> finded = new();

            string? town;
            bool stop = false;
            string? addnew;

            Console.WriteLine("[SearchSpots]\n");
            do
            {
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
                if (addnew == "1")
                {
                    Sport s = AddSport();
                    bool present = false;
                    foreach (Sport s2 in sportSearchs)
                    {
                        if (s2.Name == s.Name)
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

                    if (choice == "1")
                    {
                        IEnumerable<Spot> find = User.FavSpots.Where(u => Equals(u.Numero, s.Numero));
                        if (find.Count() > 0)
                            Console.WriteLine("This spot is already in your favorite list !");
                        else
                        {
                            User.FavSpots.Add(s);
                        }

                    }
                    if (choice == "2")
                    {
                        //OpenBrowser($"www.google.com/search?&q=45.735176%2C+3.008964&sourceid=opera&ie=UTF-8&oe=UTF-8");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during search: {0}", ex.Message);
            }

        }


    }
}
