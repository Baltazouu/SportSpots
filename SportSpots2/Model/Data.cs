using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Model
{
    /// <summary>
    /// Class Data To Manage Datapersistence
    /// </summary>
    public class Data
    {
        /// <summary>
        /// This Method takes as input an Implemented Interface IDataManager and a list of Users to save
        /// </summary>
        /// <param name="DtManager">IDataManager Implemented</param>
        /// <param name="users">List of users to save</param>
        public void SaveData(IDataManager DtManager,List<User> users)
        {
            DtManager.SaveUser(users);
        }

        /// <summary>
        /// This Method is make to Load a list of users Taking 
        /// in entry an implemented interface IDataManager and return a tuple
        /// bool if the Load Load Successfully and a list of User newly Loaded
        /// </summary>
        /// <param name="Dtmanager">IDataManager Implemented</param>
        /// <returns></returns>
        public (bool,List<User>) LoadData(IDataManager Dtmanager)
        {
            return Dtmanager.LoadUser();
        }

        /// <summary>
        /// This Method Search in the list of users presents if the User.Mail field is existing
        /// </summary>
        /// <param name="mail">mail to search</param>
        /// <param name="u">list of users to search into</param>
        /// <returns>boolean : true if the mail exists or false</returns>
        public bool CheckMailExist(string mail, List<User> u)
        {
            if(u==null || u.Count==0) return false;
            foreach (var user in u)
            {
                Debug.WriteLine(user.Mail);
                if (user.Mail == mail)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// This Method Check if 
        /// </summary>
        /// <param name="mail">mail id</param>
        /// <param name="pass">pass corresponding to mail</param>
        /// <param name="u">list of users to find</param>
        /// <returns>true if the mail exist and if the pass is associate to this mail</returns>
        public bool CheckRightPass(string mail, string pass, List<User> u)
        {
            //User find;
            if(u==null || u.Count==0) { return false; }
            try
            {
                //find = u.Where(n => n.Mail == mail && n.Passwd == pass).First();
                foreach(var user in u)
                {
                    if (user.Mail == mail && user.Passwd == pass) 
                       return true;
                    
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// This Method Can find and return a user by passing mail and password user attributes in parameters
        /// </summary>
        /// <param name="mail">Mail To Find</param>
        /// <param name="pass">Pass to Find associate to Mail</param>
        /// <param name="all">List of user to find into</param>
        /// <returns>User or null if not find</returns>
        public User? FindUser(string mail,string pass,List<User> all)
        {
            User u;
            if (all.Count>0)
            {
                u = all.Where(n => n.Mail.Equals(mail) && n.Passwd.Equals(pass)).First();

                Debug.WriteLine("U.Favspots.count : {0} ",u.FavSpots.Count);
                Debug.WriteLine("U.Favspots.History : {0} ", u.History.Count);
                Debug.WriteLine("U.Favspots.Favsports : {0} ", u.Favsports.Count);
                return u;
            }
            return null;
        }

        /// <summary>
        /// This Method find the greater User number and return it+1
        /// if no users in the list to search return 101
        /// </summary>
        /// <param name="all">List of users</param>
        /// <returns>int : new user id</returns>
        public int GetNewUserId(List<User> all)
        {
            
            int max = 100;
            foreach (var user in all)
                if(user.Id > max)
                    max = user.Id;
            return max+1;
            //int val =  all.Max(user =>user.Id)+ 1;
            //return val;
        }

        /// <summary>
        /// Return The Greater User id present in the List of all users
        /// </summary>
        /// <param name="all">list of all users</param>
        /// <returns>int : greater user number</returns>
        public int GetMaxId(List<User> all)
        {
            return all.Max(u =>  u.Id);
        }
    }
   
}


