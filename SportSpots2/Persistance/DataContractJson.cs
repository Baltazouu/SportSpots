using Model;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Diagnostics;

namespace Persistance
{
    /// <summary>
    /// DataContractJson Implement IDataManager Interface from model
    /// This class use Newtonsoft.Json Package
    /// </summary>
    public class DataContractJson : IDataManager
    {
        /// <summary>
        /// Path file to save and load
        /// </summary>
        static string UserFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Users.json");


        /// <summary>
        /// Explained Into IdataManger commentary's
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool SaveUser(List<User> users)
        {
            try
            {
                // Test
                Debug.WriteLine("Test user all");
                foreach (var user in users)
                {
                    Debug.WriteLine(user);
                }

                using (StreamWriter streamWriter = new StreamWriter(UserFile))
                {
                    using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonWriter.Formatting = Formatting.Indented;
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, users);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        
        /// <returns></returns>
        /// <summary>
        /// Explained Into IdataManger commentary's
        /// </summary>
        /// <returns></returns>
        public (bool, List<User>?) LoadUser()
        {
            List<User>? users = new List<User>();
            try
            {
                using (StreamReader reader = new StreamReader(UserFile))
                {
                    string json = reader.ReadToEnd();
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            catch (Exception)
            {
                return (false, users);
            }

            if(users == null ) { users = new List<User>(); }

            Debug.WriteLine("TESTS USERS LOAD");

            foreach (var user in users)
            {
                Debug.WriteLine(user);
            }    

            return (true, users);
        }

    }
 }
