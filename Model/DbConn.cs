using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Model
{
    public class DbConn
    {

        static string dburl = "Host=localhost;Port=5432;Database=testdb;Username=bapt;Password=14010";

        public DbConn()
        { }


        


        public bool CheckUserExist(string addr)
        {
            string sqlcommand = $"SELECT id FROM USER WHERE addr =\"{addr}\"";

            //NpgsqlConnection conn = new NpgsqlConnection(dburl);

            try
            {
                NpgsqlDataSource datasrc = NpgsqlDataSource.Create(dburl);

                using NpgsqlCommand cmd = datasrc.CreateCommand(sqlcommand);
                {
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();

                    dt.Load(cmd.ExecuteReader());
                    // if res = addr 

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error", ex.Message);
                return false;
            }

            }
            

        }




    }

    

