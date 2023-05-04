using Maui1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Net.Mail;

namespace ConsoleProject
{
    public class MainProg
    {

        

        public async Task Prog()
        {
            string? Choice;

            //ReadPasswd r = new();

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
            pass = ReadPasswd.HashPassword(pass);


            Connexion conn = new(mail, pass);


            Console.WriteLine("[TEST INTERN]");
            /*while (!conn.InternetAvaible())
            {
                Console.WriteLine("[Network Error]\n Check Your Network Connection And Retry...");
                Console.ReadLine();
            }


            Console.WriteLine("[TEST SQL SERVER AVAIBLE]");
            while (!conn.SqlServerAvaible())
            {
                Console.WriteLine("[SeverError]\n Sorry Our Server is actually down...");
                Console.ReadLine();
            }
            Console.WriteLine("[SQL SERVER RUNS]");
            */
            if (Choice == "1")
                await Connection(conn,mail,pass);

            if (Choice == "2")
                await Inscription(conn, mail, pass);

        }
        public async Task Inscription(Connexion conn, string mail, string pass)
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
                //pass = r.ReadPassword();
                pass = ReadPasswd.ReadPassword();
                pass = ReadPasswd.HashPassword(pass);
                conn = new(mail, pass);
            }
            conn.InsertNewUser(mail, pass);
            Console.WriteLine("[Success Inscription !]");
            UserActions u = new(conn.GetUserID(mail), mail, pass);
            await u.ChooseAction();
        }

        async Task Connection(Connexion conn,string mail,string pass)
            {
                while (!conn.CheckMailExist(mail) || !conn.CheckRightPasswd(mail, pass))
                {
                    Console.WriteLine("Invalid Mail Or Password !");
                    Console.Write("Enter Your Email Adress : ");
                    mail = Console.ReadLine();

                    Console.Write("Enter Your Password : ");
                    //pass = r.ReadPassword();
                    pass = ReadPasswd.ReadPassword();
                    pass = ReadPasswd.HashPassword(pass);
                    conn = new(mail, pass);
                }
                Console.WriteLine("[Success Connection !]");
                UserActions u = new(conn.GetUserID(mail), mail, pass);
                await u.ChooseAction();
            }

        }
    }