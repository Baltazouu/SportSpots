using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Maui1.Connexion
{
    public class Login
    {

        string mail;

        string Mail
        {
            get { return mail; }

            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException("Mail Value Error");

                }
                else
                    mail = value;
            }
        }

        string _password;

        string Password
        {
            get { return _password; }

            set
            {
                if (value == null || value.Length < 6 || value == "")
                {
                    throw new ArgumentException("Password Exception Not null, at least 6 char");
                }
                else
                {
                    _password = value;
                }
            }
        }

        public Login()
        {
            Console.WriteLine("[Login]");
            Console.Write("Enter  Your Email Address : ");
            string m = Console.ReadLine();

            while (m == null || m == "")
            {
                Console.WriteLine("Please do not enter empty email adress !!");
                Console.Write("Enter  Your Email Address : ");
                m = Console.ReadLine();
            }

            Mail = m;

            Console.WriteLine("Enter Your Password of at least 6 chars");
            Console.Write("Enter Your Password : ");
            ReadPasswd r = new ReadPasswd();
            string pass = r.ReadPassword();
            while (pass.Length < 6 || pass == "")
            {
                Console.WriteLine("Please Enter A password of at least 6 chars !!");
                Console.Write("Enter Your Password : ");
                pass = r.ReadPassword();
            }

        }


        /*public bool CheckExists()
        {

        }*/


    }
}
