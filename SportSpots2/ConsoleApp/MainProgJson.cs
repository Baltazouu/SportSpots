using ConsoleApp;
using Model;
using Persistance;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleProject
{
    internal class MainProgJson
    {
        string? Addr;
        string? Passwd;

        //DataContractJson DataSrc = new();
        Data Dt = new();
        DataContractJson JsonSource = new DataContractJson();

        List<User> all;

        public MainProgJson()
        {
            all = Dt.LoadData(JsonSource).Item2;
        }


        public void Program()
        {
            string? choice;
            Console.WriteLine("Welcome To SportSpots !");
            do
            {
                Console.WriteLine("1. Inscription");
                Console.WriteLine("2. Connection");

                Console.Write("Enter Your Choice :");
                choice = Console.ReadLine();
            }
            while (choice != "1" && choice != "2");

            if (choice == "1")
                Inscription();
            else
                Connection();
            

        }

        public void Inscription()
        {
            Console.WriteLine("[Inscription]");

            bool errorConditions = false;

            do
            {
                do
                {
                    Console.Write("Enter Your Email Address : ");
                    Addr = Console.ReadLine();
                }
                while (Addr == "" || Addr == null);
                do
                {
                    Console.Write("Enter Your Password : ");
                    Passwd = ReadPasswd.ReadPassword(); // a faire : faire retourner le nb de caract du passwd initial !
                }
                while (Passwd.Length < 10); // 10 car hash meme si ca sert a rien 

                if (Dt.CheckMailExist(Addr, all))
                {
                    errorConditions = true;
                    Console.WriteLine("Error ! Wrong This email altready exists !");
                }
                else errorConditions = false;

            } while (errorConditions);


            /*User?u = Dt.FindUser(Addr, Passwd, all);
            if (u == null)
            {
                throw new Exception("Error While Connecting to persistence");
            }*/

            User u = new(Dt.GetNewUserId(all), Addr, Passwd, null, null);
           
            UserActions actions = new UserActions(u);
            actions.actions();
        }

        public void Connection()
        {
            bool errorConditions = false;
            do
            {
                do
                {
                    Console.Write("Enter Your Email Address : ");
                    Addr = Console.ReadLine();
                }
                while (Addr == "" || Addr == null);
                do
                {
                    Console.Write("Enter Your Password : ");
                    Passwd = ReadPasswd.ReadPassword();
                }
                while (Passwd.Length < 6);

                if (!Dt.CheckMailExist(Addr, all))
                {
                    errorConditions = true;
                    Console.WriteLine("Error ! Wrong This email does'nt exists !");
                }
                else if (!Dt.CheckRightPass(Addr, Passwd, all))
                {
                    Console.WriteLine("Error ! Wrong Password !");
                    errorConditions = false;
                }
                else errorConditions = false;

            } while (errorConditions);


            User u = Dt.FindUser(Addr, Passwd, all);
            all.Add(u);
            Dt.SaveData(JsonSource, all);

            UserActions actions = new(u);
            actions.actions();

        }
    }
}
