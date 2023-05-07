using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class NoSQLApp
    {
        public List<Spot> AvaibleSpotList { get; set; }

        public List<Sport> AvaibleSports { get; set; }

        public List<User> Users { get; set; }

        public NoSQLApp()
        {
            SpotsStub spots_stub = new SpotsStub();
            SportStub sportstub = new SportStub();
            AvaibleSports = sportstub.Loadsport();

            AvaibleSports = sportstub.Loadsport();
        }

        public int GetMaxUserId()
        {
            int maxUserId = 0;
            foreach(User u  in Users)
            {
                if(u.Id > maxUserId)
                    maxUserId = u.Id;

            }
            return maxUserId;
        }

        public bool CheckAddrExist(string addr)
        {
            bool find = false;
            foreach (User u in Users)
            {
                if(u.Mail == addr)
                    find = true;
            }
            return find;
        }

        public bool CheckRightPass(string mail,string pass)
        {
            bool find = false;
            foreach (User u in Users)
            {
                if (u.Mail == mail && u.Passwd == pass)
                    find = true;
            }
            return find;
        }

        public void Login()
        {
            bool right = false;
            while (!right)
            {
                Console.Write("[Login]\n Enter Your Email : ");
                string addr = Console.ReadLine();

                Console.Write("Enter Your Password : ");

                string pass = Console.ReadLine();

                User u = new(GetMaxUserId(),addr,pass);

                if (CheckAddrExist(u.Mail) && CheckRightPass(u.Mail, u.Passwd))
                {
                    Console.WriteLine("[Authentification]\nSuccess");
                    right = true;
                }
                else
                    Console.WriteLine("Error Wrong Password Or Email Please Retype !");
            }
        }

        public void Inscription()
        {
            bool right = false;
            string? pass,addr;
            
            Console.WriteLine("[Inscription]");

            while(!right)
            {
                Console.Write("[Inscription]\nEnter Your Email : ");
                addr = Console.ReadLine();

                Console.Write("[Inscription]\nEnter Your Passwd");

                pass = Console.ReadLine();

                while (pass == null || pass.Length <6)
                {
                    Console.WriteLine("Error !\n Enter A Password Of At Least 6 chars");
                    Console.Write("[Inscription]\nEnter Your Passwd");

                    addr = Console.ReadLine();
                }

                User u = new User(GetMaxUserId(),addr,pass);
                if(CheckAddrExist(addr))
                {
                    Users.Add(u);
                    Console.WriteLine("[User Successfully Added To Database !]");
                    right= true;
                }
                else Console.WriteLine("[Inscription]\nError ! This Address Already Exist !");

            }
        }
    }
}