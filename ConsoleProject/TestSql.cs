using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleProject
{
    internal class TestSql
    {

        string mail = "bapt.14@hotmail.com";
        string pass = "motdepasse";


        DbConn db = new();
        
        public TestSql()
        {
            Console.WriteLine(db.CheckMailExist(mail));
        }

    }
}
