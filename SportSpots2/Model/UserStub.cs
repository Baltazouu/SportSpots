using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserStub : IDataManager
    {
        public (bool,List<User>) LoadUser()
        {
            List<User> users = new();

            List<Spot> sp = SpotStub.LoadSpots();

            List<Sport> sports = SportStub.Loadsport();

            List<string> passes = new();

            passes.Add(Hash.HashPassword("motdepasse"));
            passes.Add(Hash.HashPassword("motdepasse2"));
            passes.Add(Hash.HashPassword("motdepasse3"));
            passes.Add(Hash.HashPassword("motdepasse4"));
            passes.Add(Hash.HashPassword("motdepasse5"));

            List<string> mails = new();
            mails.Add("mail.test@coefef1");
            mails.Add("mail.test@coefef2");
            mails.Add("mail.test@coefef3");
            mails.Add("mail.test@coefef4");
            mails.Add("mail.test@coefef5");
            int x  = 0;
            for (int i = 150;i<155;i++)
            {
                users.Add(new(i, mails[x], passes[x], sp, sports));
                x++;
            }
            
            return (true,users);
        }


        public bool SaveUser(List<User> all)
        {
            throw new NotImplementedException("Error Not Possible to save in userStub");
        }
        

    }


   
}
