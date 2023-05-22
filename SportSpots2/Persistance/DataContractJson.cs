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
                string JsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
                //Console.WriteLine(JsonString);

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
                DataContractJsonSerializer jsonSerializer = new(typeof(User));

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

        /* public List<User> LoadUser()
         {
             List<User> users = new List<User>();
            using (StreamReader streamReader = new StreamReader(UserFile))
             {
                 using (JsonTextReader jreader = new JsonTextReader(streamReader))
                 {
                     //JObject fileValue = JObject.Read(jreader);

                     //  Console.WriteLine(fileValue);
                     //string json = jreader.ReadToEnd();


                     users = JsonConvert.DeserializeObject<List<User>>(jreader);

                 }
              }*/

        /*
        string json = File.ReadAllText(UserFile);

         Console.WriteLine("[Json fichier : ]");
         Console.WriteLine(json);

         JObject jsonObject = JObject.Parse(json);
         users = jsonObject["Users"].Children.To

        */
        //return users;
    }
    }
