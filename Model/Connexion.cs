using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Connexion : DbConn
    {
        int Id { get; init; }

        string Addr { get; set; }

        string _passwd;
        string Passwd
        {
            get
            {
                return _passwd;
            }
            set
            {
                if (value == null || value == "" || value.Length < 6)
                {
                    InvalidInputExcept ex = new InvalidInputExcept("Passwd length is at least 6 chars !");
                }
            }
        }

        public Connexion(string addr,string passwd) 
        {
            Addr = addr;
            _passwd = passwd;

            if (!CheckUserExist(addr))
            { 
                Console.WriteLine("Error Adress mail doesn't exist !");
                return;
            }
            if (!CheckRightPasswd(Passwd))
            { 
                Console.WriteLine("Error ! Wrong Password for mail {0}", Addr);
                return;
            }
        }
    }
}
