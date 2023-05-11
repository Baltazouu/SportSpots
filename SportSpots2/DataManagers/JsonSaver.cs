using Model;

namespace Persistance
{
    public class JsonSaver : DataContractJson
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
