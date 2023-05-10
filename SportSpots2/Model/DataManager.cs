using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataManager : DataContractJson
    {

        public List<User>? LoadUserJson()
        {
            List<User>?users = null;
            try
            {
                users = LoadUser();
            }
            catch 
            {
                return users;
            }
            return users;
        }

        public bool SaveUserJson(List<User> users)
        {
            try
            {
                SaveUser(users);
            }
            catch 
            {
                return false;
            }
            return true;
        }

    }
}
