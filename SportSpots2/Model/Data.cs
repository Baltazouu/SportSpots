using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Data
    {
        public void SaveData(IDataManager DtManager,List<User> users)
        {
            DtManager.SaveUser(users);
        }

        public (bool,List<User>?) LoadData(IDataManager Dtmanager)
        {
            return Dtmanager.LoadUser();
        }
        public bool CheckMailExist(string mail, List<User> u)
        {
            if(u==null || u.Count==0) return false;
            foreach (var user in u)
            {
                if (user.Mail == mail)
                    return true;
            }
            return false;
        }

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


        public User? FindUser(string mail,string pass,List<User> all)
        {
            User u;
            if (all.Count>0)
            {
                u = all.Where(n => n.Mail.Equals(mail) && n.Passwd.Equals(pass)).First();
                return u;
            }
            return null;
        }

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

        public int GetMaxId(List<User> all)
        {
            return all.Max(u =>  u.Id);
        }
    }
}
