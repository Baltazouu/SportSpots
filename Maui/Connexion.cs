using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMaui
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
           
        }

        public bool Connect()
        {
            if(CheckMailExist(Addr) &&  CheckMailExist(Passwd))
            {
                User u = new(GetNewUserId(), Addr, Passwd);
            }
            return false;
        }


        

    }
}
