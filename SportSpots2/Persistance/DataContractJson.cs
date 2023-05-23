using Model;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace Persistance
{
    public class DataContractJson : IDataManager
    {

        static string UserFile = "Users.json";

        public bool SaveUser(List<User> users)
        {
            try
            {
                //Debug.WriteLine(JsonString);

                using (StreamWriter streamWriter = new(UserFile))
                {
                    using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonWriter.Formatting = Formatting.Indented;
                        JsonSerializer serializer = new();
                        serializer.Serialize(jsonWriter, users);
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public (bool,List<User>?) LoadUser()
        {
            List<User>? users = new();
            try
            {
                using (StreamReader reader = new("Users.json"))
                {
                    users = JsonConvert.DeserializeObject<List<User>>(reader.ReadToEnd());
                }
            }
            catch(Exception)
            {
                return (false,users);
            }

            return (true,users);
        }
        
    }
 }
