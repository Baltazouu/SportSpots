using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class StubUser
    {
        public StubUser() { }


        public List<User> LoadUser()
        {
            List<User> list = new List<User>();
            list.Add(new(12345, "test.com@mail.fr","passwd"));
            list.Add(new (12346, "test2.com@gmail.com", "passwd"));
            list.Add(new(12347, "test3.com@mail.fr", "passwd"));
            list.Add(new(12348, "test3.com@mail.fr", "passwd"));
            list.Add(new(12349, "test4.com@mail.fr", "passwd"));

            return list;

        }

    }
}
