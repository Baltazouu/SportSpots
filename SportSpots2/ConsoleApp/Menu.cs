﻿using Model;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Serialization;

namespace ConsoleApp
{
    internal class Menu
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

        public void MyFavspots(ObservableCollection<Spot> list)
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


        public void MyFavSports(ObservableCollection<Sport> list)
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

        public bool ChangeEmail(User u)
        {
            string? mail,pass;
            Console.WriteLine("[ChangeEmail]");

            Console.Write("Enter Your Actual Email : ");
            string? oldmail = Console.ReadLine();

            Console.Write("Enter Your New Email : ");
            mail = Console.ReadLine();

            Console.Write("Enter Your Password :");
            pass = ReadPasswd.ReadPassword();

            if(pass.Equals(u.Passwd) && oldmail.Equals(u.Mail))
            {
                if (u.ChangeMail(mail))
                {
                    Console.WriteLine("[New Mail Setted Successfully]");
                    return true;
                }
                else Console.WriteLine("[Error Mail Not Updated :( ]");
            }
            Console.WriteLine("Error Mail Not Updated !");
            return false;



        }

        public bool ChangePass(User u)
        {
            string? pass,newpass;
            Console.WriteLine("[ChangePasswd]");

            Console.Write("Enter Your Password : ");
            pass = ReadPasswd.ReadPassword();

            Console.Write("Enter new Password :");
            newpass = ReadPasswd.ReadPassword();

            if (pass.Equals(u.Passwd))
            {
                bool succes = false;
                try
                {
                    u.ChangePasswd(newpass);
                    succes = true;

                }
                catch (Exception)
                { succes = false; }

                if(succes) { 
                    Console.WriteLine("[New passwd Setted Successfully]");
                }

                return succes;
            }
            Console.WriteLine("Error passwd Not Updated !");
            return false;


        }

    }
}
