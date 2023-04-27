using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Connexion : DbConn
    {
        int Id { get; init; }

        string addr { get; set; }

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



    }
}
