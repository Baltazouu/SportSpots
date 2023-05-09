using Model;

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
       
            //Console.WriteLine("[TEST INTERN]");

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
                await Connection(mail,pass);

            if (Choice == "2")
                await Inscription(mail, pass);

        }

        /// <summary>
        /// Methode Permettant 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="mail"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public async Task Inscription(string? mail, string pass)
        {
            DataBaseConnection dbconn = new DataBaseConnection();
            while ( mail == null || dbconn.CheckMailExist(mail) || mail.Length < 3)
            {
                Console.WriteLine("Error With this address taken or not an email!");
                if (pass == "" || pass.Length < 6)
                {
                    Console.WriteLine("The password need at least 6 chars !");
                }
                Console.Write("Enter Your Email Adress : ");
                mail = Console.ReadLine();

                Console.Write("Enter Your Password : ");
                //pass = r.ReadPassword();
                pass = ReadPasswd.ReadPassword();
            }
            dbconn.InsertNewUser(mail, pass);
            Console.WriteLine("[Success Inscription !]");
            UserActions u = new(dbconn.GetUserID(mail), mail, pass);
            await u.ChooseAction();
        }

        /// <summary>
        /// Methode Permettant de gerer la connexion
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="mail"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        async Task Connection(string?mail,string pass)
            {
                DataBaseConnection conn = new();
                while (!conn.CheckMailExist(mail) || !conn.CheckRightPasswd(mail, pass))
                {
                    Console.WriteLine("Invalid Mail Or Password !");
                    Console.Write("Enter Your Email Adress : ");
                    mail = Console.ReadLine();

                    Console.Write("Enter Your Password : ");
                    
                    pass = ReadPasswd.ReadPassword();
                    
                }
                Console.WriteLine("[Success Connection !]");
                UserActions u = new(conn.GetUserID(mail), mail, pass);
                await u.ChooseAction();
            }

        }
    }