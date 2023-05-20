using Model;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Serialization;

namespace ConsoleApp
{
    internal class Menue
    {

        public void Actions()
        {
            Console.WriteLine("""
                [UserActions]
                1. Search a Spot
                2. See my FavSpots
                3. See my FavSports
                4. Change my Mail
                5. Change my Pass
                6. Exit SportSpots
                """);
        }

        public void MyFavspots(List<Spot> list)
        {
            string? c;
            Console.WriteLine("[FavSpots]");
            foreach (Spot spot in list)
            {
                Console.WriteLine(spot.ToString());
                do
                {
                    Console.WriteLine("1. Afficher l'itineraire vers le spot");
                    Console.WriteLine("2. Supprimer ce spot");
                    Console.WriteLine("3. Afficher le spot suivant");
                    Console.Write("Entrez Votre Choix : ");
                    c = Console.ReadLine();
                }
                while (c != "1" && c != "2" && c != "3");

                switch (c)
                {
                    case "1":
                        Console.WriteLine("Coming Soon !");
                        break;

                    case "2":

                        list.Remove(spot);
                        Console.WriteLine("Spot Deleted of your Fav's List !");
                        break;

                    case "3":
                        break;
                }
            }
            //return list;
        }


        public void MyFavSports(List<Sport> list)
        {
            string? c;
            Console.WriteLine("[FavSpots]");
            foreach (Sport sport in list)
            {
                Console.WriteLine(sport.ToString());
                do
                {
                    Console.WriteLine("1. Supprimer ce sport");
                    Console.WriteLine("2. Afficher le sport suivant");
                    Console.Write("Entrez Votre Choix : ");
                    c = Console.ReadLine();
                }
                while (c != "1" && c != "2" && c != "3");

                switch (c)
                {
                    case "1":

                        list.Remove(sport);
                        Console.WriteLine("Sport Deleted of your Fav's List !");
                        break;

                    case "2":
                        break;
                }
            }
            //return list;
        }



    }
}
