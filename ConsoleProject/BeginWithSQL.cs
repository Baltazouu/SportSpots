using Maui1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace ConsoleProject
{
    internal class BeginWithSQL
    {

        public BeginWithSQL()
        {
            string? Choice;

            ReadPasswd r = new();

            Console.WriteLine("SportSpots App !");

            Console.WriteLine("1. Connexion\n2.Inscription ");
            Console.Write("Enter Your Choice : ");
            Choice = Console.ReadLine();

            while (Choice != "1" && Choice != "2")
            {
                Console.WriteLine("Please Choose between 1 or 2 !");
                Console.WriteLine("1. Connexion\n2.Inscription");
                Console.Write("Enter Your Choice : ");
                Choice = Console.ReadLine();
            }
            Console.Write("Enter Your Email Adress : ");
            string? mail = Console.ReadLine();

            Console.Write("Enter Your Password : ");

            string pass = ReadPasswd.ReadPassword();

            Connexion conn = new(mail, pass);

            /*while (!conn.InternetAvaible())
            {
                Console.WriteLine("[Network Error]\n Check Your Network Connection And Retry...");
                Console.ReadLine();
            }

            while (!conn.SqlServerAvaible())
            {
                Console.WriteLine("[SeverError]\n Sorry Our Server is actually down...");
                Console.ReadLine();
            }
*/
            if (Choice == "1")
                Connection();

            if (Choice == "2")
                Inscription();

            void Inscription()
            {
                while (conn.CheckMailExist(mail))
                {
                    Console.WriteLine("This mail is already taken !");
                    if (pass == "" || pass.Length < 6)
                    {
                        Console.WriteLine("The password need at least 6 chars !");
                    }
                    Console.Write("Enter Your Email Adress : ");
                    mail = Console.ReadLine();

                    Console.Write("Enter Your Password : ");
                    pass = ReadPasswd.ReadPassword();
                    conn = new(mail, pass);
                }
                conn.InsertNewUser(mail, pass);
                Console.WriteLine("[Success Inscription !]");
                UserActions u = new(conn.GetUserID(mail), mail, pass);
                u.ChooseAction();
            }

            void Connection()
            {
                while (!conn.CheckMailExist(mail) || !conn.CheckRightPasswd(mail, pass))
                {
                    Console.WriteLine("Invalid Mail Or Password !");
                    Console.Write("Enter Your Email Adress : ");
                    mail = Console.ReadLine();

                    Console.WriteLine("Enter Your Password : ");
                    pass = ReadPasswd.ReadPassword();
                    conn = new(mail, pass);
                }
                Console.WriteLine("[Success Connection !]");
                UserActions u = new(conn.GetUserID(mail), mail, pass);
                u.ChooseAction();
            }
        }
    }
}
