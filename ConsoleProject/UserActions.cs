using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
/*
namespace ConsoleProject
{
    internal class UserActions : User
    {
        List<Sport> sports = new();

        public UserActions(int id, string name, string password)
                         : base(id, name, password)
        {
            SportStub stub = new();
            sports = stub.Loadsport();
        }

        public void SearchASport()
        {
            Console.WriteLine("[Search A Spot ]");
            
        }

        public void ActionsMenue()
        {
            Console.WriteLine("[UserActions]");
        }

        public void ChooseAction()
        {
            Console.WriteLine("[UserActions : ]");
            
        }

    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;

namespace ConsoleProject
{
    internal class UserActions : User

        
    {
        

        public UserActions(int id, string name, string password)
            :base(id, name, password)
        { }

        public async Task ChooseAction()
        {
             
            Console.WriteLine("[UserActions]\n1. Search A Spot\n2. See my favspots\n3. See my favsports");
            Console.Write("Enter Your Choice : ");
            string?choice = Console.ReadLine();
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
                    Console.WriteLine("Bientot dispo !");
                    break;
            }

        }

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

            sportSearchs.Add(AddSportToSearch());

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
                   Sport s = AddSportToSearch();
                   foreach (Sport s2 in sportSearchs)
                    {
                        if(s2.Name == s.Name)
                        { Console.WriteLine($"The {s.Name} Sport Is Already in the list to search"); }

                    }
                    sportSearchs.Add(s);
                }
                else { stop = true; }
            } while (!stop);


            try
            {
                Search Research = new(town, sportSearchs);
                finded = await Research.ExecuteSearch();
                //Console.WriteLine
                foreach (Spot s in finded)
                {
                    Console.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during search: {0}", ex.Message);
            }

        }


        public Sport AddSportToSearch()
        {
            Sport?s = null;

            List<Sport> avaible = SportStub.Loadsport();
            
            Console.WriteLine("Enter A number Corresponding To A Sport !");
            
            int i = 1;

            foreach (Sport sport in avaible)
            {
                Console.WriteLine($"{i} : {sport.ToString()}");
                i++;
            }

            Console.Write("Enter A Number :");
            string choice = Console.ReadLine();

            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5"
                    && choice != "6" && choice != "7" && choice != "8")
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
                    
                    }
            return s;
        }

    }
}

