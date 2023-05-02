using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;

namespace ConsoleProject
{
    internal class UserActions : User
    {

        public UserActions(int id, string name, string password)
            :base(id, name, password)
        { }



        public void ActionsMenue()
        {
            Console.WriteLine("[UserActions]");


        }

        public void ChooseAction()
        {
            Console.WriteLine("[UserActions : ]");
            
        }

    }
}
