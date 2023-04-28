using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Maui1.Connexion
{
    internal class Inscription
    {
        string db = "Host=localhost;Port=5432;Database=testdb;Username=bapt;Password=14010\";";
        string addr { get; set; }
        string passwd { get; set; }

        public Inscription()

        {
            Console.WriteLine("Enter an email address : ");
            addr = Console.ReadLine();

            while (checkexist())
            {
                Console.WriteLine("Wrong an account is already existing");
                Console.WriteLine("Enter an email address : ");
                addr = Console.ReadLine();

            }


            Console.WriteLine("Enter your passwd : ");
            passwd = ReadPasswd();

            NpgsqlConnection conn = new NpgsqlConnection(db);
            conn.Open();

            string sqlcommd = $"SELECT id FROM USER WHERE addr=\"{addr}\"";

            //conn.CreateCommand(sqlcommd);


            conn.Close();
        }



        public bool checkexist()
        {

            return true;
            // Checking that the mail doesn't exist

        }

        static string ReadPasswd()
        {
            string passwd = "";

            ConsoleKeyInfo keyinfo;

            do
            {
                keyinfo = Console.ReadKey(true);
                if (keyinfo.Key != ConsoleKey.Backspace && keyinfo.Key != ConsoleKey.Enter)
                {
                    passwd += keyinfo.KeyChar;
                    Console.Write("*");

                }
                else if (keyinfo.Key == ConsoleKey.Backspace && passwd.Length > 0)
                {
                    passwd = passwd.Remove(passwd.Length - 1);
                    Console.Write("\b \b");
                }
                else if (keyinfo.Key == ConsoleKey.Delete && passwd.Length > 0)
                {
                    passwd = passwd.Remove(0, 1);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                }
            }
            while (keyinfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return passwd;
        }
    }
}
