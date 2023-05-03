using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Model
{
    public class DbConn
    {
        //static string dburl = "Host=localhost;Username=postgres;Password=14010;Database=test";
        static string dburl = "Host=ppqqwyo2ga.tflguiznc2.tsdb.cloud.timescale.com;Username=tsdbadmin;Password=yji0k7194gy9201i;Port=39598;Database=tsdb";

        NpgsqlDataSource Datasrc = NpgsqlDataSource.Create(dburl);

        public DbConn()
        { }
         

        List<Sport> LoadFavSportFromUser(string mail, string password)
        {
            List<Sport> l = new List<Sport>();
            
            if(CheckMailExist(mail) && CheckRightPasswd(mail,password))
            {
                // sql request
            }
            return l;
        }

        /// <summary>
        /// Check that inernet is avaible
        /// </summary>
        /// <returns></returns>
        public bool InternetAvaible()
        {
            NetworkAccess network = Connectivity.NetworkAccess;

            return (network == NetworkAccess.Internet);
        }

        public bool SqlServerAvaible()
        {
            try 
            {
                Datasrc.OpenConnection();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }



        public List<Spot> LoadFavSpotFromUser(string mail)
        {
            List<Spot> spots = new List<Spot>();

            string sqlcmd = $"SELECT * FROM FavSpots WHERE utilisateur = (SELECT id FROM Utilisateur WHERE addr = '{mail}')";

            Console.WriteLine(sqlcmd);

            try
            {
                List<Spot>fav = new();

                using NpgsqlCommand cmd = Datasrc.CreateCommand(sqlcmd) ;

                DataTable dt = new DataTable();

                cmd.ExecuteNonQuery();

                dt.Load(cmd.ExecuteReader()) ;
                

                foreach (DataRow dr in dt.Rows)
                {
                    bool access = false;
                    bool restauration = false;
                    bool publicaccess = false;

                    if (dr[10].ToString() == "O")
                    {  access = true; }
                    if (dr[11].ToString() == "O")
                    { restauration = true; }    
                    if (dr[12].ToString() == "O")
                    { publicaccess = true; }
                    
                    fav.Add(new(Convert.ToInt32(dr[0]),dr[4].ToString(),
                                                dr[2].ToString(),
                                                dr[3].ToString(),
                                                dr[5].ToString(),
                                                Convert.ToInt32(dr[6]),
                                                dr[7].ToString(),
                                                Convert.ToDouble(dr[8]),
                                                Convert.ToDouble(dr[9]),
                                                access,
                                                restauration,
                                                publicaccess));
                }

                return fav;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return spots;
        }

        // public for the moment only
        public bool CheckRightPasswd(string addr,string passwd)
        {
            string sqlcmd = $"SELECT passwd FROM UTILISATEUR WHERE addr = '{addr}' and passwd = '{passwd}';";

            try
            {
                //DataTable dt = new DataTable();
                
                using NpgsqlCommand cmd = Datasrc.CreateCommand(sqlcmd);
                {
                    cmd.ExecuteNonQuery();

                   if (cmd.ExecuteScalar() == null) { return false; }
                    
                    string pass = cmd.ExecuteScalar().ToString();

                    return (pass == passwd);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("erreur : {0}",ex.Message);
                return false;
            }

        }

        // public for the tests only
        public bool CheckMailExist(string addr)
        {
            string sqlcommand = $"SELECT addr FROM utilisateur WHERE addr ='{addr}';";

            //NpgsqlConnection conn = new NpgsqlConnection(dburl);

            try
            {
                DataTable dt = new DataTable();

                using NpgsqlCommand cmd = Datasrc.CreateCommand(sqlcommand);
                {
                    if (cmd.ExecuteScalar() == null) { return false; }
                    if(cmd.ExecuteScalar().ToString() == null) { return false; }
                    string mail = cmd.ExecuteScalar().ToString();


                    //Console.WriteLine("MAIL : {0} Mail SQL : {1}",addr,mail);
                    return mail == addr;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Error l'erreur est ic", ex.Message);
                return false;
            }
            
        }

        public int GetNewUserId()
        {
            string sqlcmd = "SELECT MAX(id) FROM Utilisateur;";
            try
            {
                using NpgsqlCommand cmd = Datasrc.CreateCommand(sqlcmd);
                {
                    cmd.ExecuteNonQuery();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    id++;
                    Console.WriteLine($"New User ID: {id}");
                    return id;
                }
            }

            catch ( Exception ex )
            {
                Console.WriteLine (ex.Message);
                return -1;
            }
            
        }

        public int GetUserID(string addr)
        {
            string sqlcmd = $"SELECT id FROM Utilisateur where addr = '{addr}';";
            try { 
                using NpgsqlCommand select = Datasrc.CreateCommand(sqlcmd);
                {
                    select.ExecuteNonQuery();
                    int id = Convert.ToInt32(select.ExecuteScalar());
                    return id;
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine (ex.Message);
                return -1;
            }
        }

        public bool InsertNewSport(int id,string addr,Sport s)
        {
            bool indoor = false;
            bool outdoor = false;

            if(s.Indoor)
                indoor = true;
            if(s.Outdoor)
                outdoor = true;

            string sqlcmd = $"INSERT INTO FAVSPORT VALUES({s.Numero},{id},'{indoor}','{outdoor}');";

            try
            {
                using NpgsqlCommand cmd = Datasrc.CreateCommand(sqlcmd);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch ( Exception ex )
            {
                return false;
            }
        }

        public bool InsertNewUser(string addr,string passwd)
        {
            int id = GetNewUserId();
            try
            {
                using NpgsqlCommand cmd = Datasrc.CreateCommand(
                    $"INSERT INTO Utilisateur VALUES({id},'{addr}','{passwd}')");
                {
                    cmd.ExecuteNonQuery();
                    //Console.WriteLine("[InserUser] User Successfully added to database !");
                    return true;
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        internal bool UpdateMail(int id, string addr)
        {
            if (CheckMailExist(addr))
            {
                try
                {
                    using NpgsqlCommand update = Datasrc.CreateCommand(
                        $"UPDATE utilisateur SET addr = '{addr}' WHERE id = {id};");

                    update.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {   
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
            return false;

        }

        internal bool Pass(string addr, string pass)
        {
            if (CheckRightPasswd(addr,pass))
            {
                try
                {
                    using NpgsqlCommand update = Datasrc.CreateCommand(
                        $"UPDATE utilisateur SET passwd = '{pass}' WHERE addr = {addr};");

                    update.ExecuteNonQuery();

                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
            return false;

        }


        internal bool UpdatePass(int id,string addr,string passwd)
        {
            if (CheckMailExist(addr) && CheckRightPasswd(addr, passwd))
            {
                try
                {
                    using NpgsqlCommand update = Datasrc.CreateCommand(
                        $"UPDATE utilisateur SET passwd = '{passwd}' WHERE id = {id};");

                    update.ExecuteNonQuery ();

                    return true;

                }
                catch ( Exception ex )
                {
                    return false;
                }

            }
            return false;
            
        }

        public bool InsertFavspot(Spot s,User u)
        {
            char accessibility = 'N';
            char restauration = 'N';
            char publicaccess = 'N';


            if (s.AccessibiltyHandicap)
            {
                accessibility = 'O';
            }
            if (s.Public_access)
            {
                publicaccess = 'O';
            }
            if(s.Restauration)
            {
                restauration = 'O';
            }
            

            string sqlcmd = $"INSERT INTO Favspots VALUES({s.Numero},{u.Id},{s.Family},{s.NomCommune},{s.Adress},{s.PostalCode},{s.Dept},{s.Coord_x},{s.Coord_y},{accessibility},{restauration},{publicaccess})";
            try 
            {
                using NpgsqlCommand insertcmd = Datasrc.CreateCommand(sqlcmd);
                {
                    insertcmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        }




    }

    

