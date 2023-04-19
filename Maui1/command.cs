using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Maui1
{
    internal class Command
    {

        string sqlString { get; set; } = "";

        string user { get; }
        string passwd { get; }

        public Command(string login,string password )
        {
            user = user;
            passwd = password;
        }

        public int execCommand(string cmd)
        {
            return 0;
            /*
            using (SqlConnection conn = new SqlConnection(sqlString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(cmd, conn);

                conn.Close();

                if (comm==null)
                {
                    
                    return 0;
                }
                return 1;
            }
            
            */
        }

    }


}
