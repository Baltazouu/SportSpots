using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserStub
    {
        public UserStub() { }

        public static List<User> LoadUser()
        {
            List<User> user = new List<User>();

            user.Insert(0, new User(4, "michel.test@gmail.com", "password"));
            user.Insert(1, new User(5, "pierre.dupont@gmail.com", "pierred"));
            user.Insert(2, new User(6, "dylan1@gmail.com", "motdepasse"));
            user.Insert(3, new User(7, "henry15@hotmail.fr", "1234"));
            user.Insert(4, new User(8, "alfredo@outlook.fr", "azerty"));
            user.Insert(5, new User(9, "baltazarthegoat@gmail.com", "azerty"));

            return user;
        }

    }
    /* public bool InserUserDB()
     {

     }*/


}
