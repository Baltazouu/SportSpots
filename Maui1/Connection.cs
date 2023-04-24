using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Maui1
{
    public class Connection
    {
        //private string db2 = "postgres://bapt:14010@localhost:5432/testdb";
        private string dburl = "Host=localhost;Username=postgres;Password=14010;Database=test;";//Port=543;2
        //Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";
        string mail { get; set; }
        
        private string _password;

        public int Id { get; set; } 

        public string Password
        {
            get { return _password; }
            set
            {
                if(value == null || value == "" || value.Length < 6) 
                {
                    Console.WriteLine("Please do not type an empty password !");
                    Console.WriteLine("Please type a password of min 6 chars");
                    _password = ReadPasswd();
                }
                else
                    _password = value;

            }
        }

        public Connection()
        {
            connect();
        }

        public void connect()
        {
            Console.WriteLine("Welcome to SportsSpots !");

            Console.Write("Enter Your Email Address : ");

            mail = Console.ReadLine();

            if (checkmailexist())
            {
                Console.WriteLine($"The Mail {mail} Already exist !");
                Console.WriteLine($"1 : To connect to {mail} adress.");
                Console.Write("2 : To create a new account : ");
                string c = Console.ReadLine();

                while (c != "1" && c != "2")
                {
                    Console.Write("Please choose only btw 1 or 2 : ");
                    c = Console.ReadLine();
                }

                if (c == "1")
                {
                    login();
                }
                else
                {
                    inscription();
                }

            }
            else inscription();

        }


        public void inscription()
        {
            Console.Write("[Inscription]\nEnter your email adress : ");
            mail = Console.ReadLine();
            while(checkmailexist())
            {
                Console.WriteLine("This mail is already taken");
                Console.Write("Please re enter your email : ");
                mail = Console.ReadLine();
            }

            Console.WriteLine("[Inscription]\nEnter your password long of min 6 chars");
            Console.Write("Enter your password : ");
            _password = ReadPasswd();
            while(_password.Length < 6)
            {
                Console.WriteLine("Please type a password of min 6 chars");
                _password = ReadPasswd();
            }

            adduser();
            Console.WriteLine("[Inscription]\nSuccess.");
            User u = new User(Id, mail, Password);

        }

        public void adduser()
        { // insert sql command

            int id;

            try
            {
                NpgsqlDataSource dataSource = NpgsqlDataSource.Create(dburl);
                var cmd = dataSource.CreateCommand("SELECT MAX(id) FROM utilisateur;");
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.ExecuteScalar());
                id++;
                Id = id;

                var cmd2 = dataSource.CreateCommand($"INSERT INTO utilisateur VALUES ({id},'{mail}','{Password}')");
                cmd2.ExecuteNonQuery();
                Console.WriteLine("User successfully added to database !");
                
            }
            catch(Exception e) 
            {
                Console.Write("Error : ", e);
            }
        }

        public void login()
        {
            Console.WriteLine($"Welcome back {mail}");

            Console.Write("Enter your password : ");
            _password = ReadPasswd();
            while(!checkpasswd())
            {
                Console.WriteLine("Wrong password please retype it !!");
                Console.Write("Enter your password : ");
                _password = ReadPasswd();
            }
            Console.WriteLine("[connexion]\nSuccess.");
                     
            User u = new User(Id,mail,Password);
        }


        public bool checkpasswd()
        {
            try 
            {
                string sqlcmd = $"SELECT passwd FROM utilisateur WHERE addr = '{mail}' and passwd = '{Password}'";

                DataTable dt = new DataTable();

                var dataSource = Npgsql.NpgsqlDataSource.Create(dburl);

                using var cmd = dataSource.CreateCommand(sqlcmd);
                {
                    cmd.ExecuteNonQuery();
                    dt.Load(cmd.ExecuteReader());

                    return dt.Rows.Count > 0;
                }
            
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error !",ex.Message);
                return false;
            }


        }


        public bool checkmailexist()
        {
            try
            {
                DataTable dt = new DataTable();

                var dataSource = NpgsqlDataSource.Create(dburl);

                string sqlcommand = $"SELECT id FROM utilisateur WHERE addr='{mail}'";

                using var cmd = dataSource.CreateCommand(sqlcommand);
                {
                    cmd.ExecuteNonQuery();
                    dt.Load(cmd.ExecuteReader());

                    //Console.WriteLine(dt.ToString());
                    return (dt.Rows.Count > 0);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error :", ex.Message + "`\n" + ex.StackTrace);
                return false;
            }
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
