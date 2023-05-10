using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static System.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class DataContractJson : IDataManager
    {

        /*static string JsonString;

        static JsonSerializer serializer;*/

       /* public List<User> LoadUser()
        {
            List<User> users = new();

            DataContractJsonSerializer jsonSerializer = new (typeof(User));

            using (StreamReader reader = new("Users.json"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(reader.ReadToEnd());
            }

            
                return users;
        }

        public void SaveUser(List<User> users)
        {
            DataContractJsonSerializer jsonSerializer = new(typeof(User));

            MemoryStream memorystream = new();


            JsonConvert.SerializeObject<User>
            jsonSerializer.WriteObject(memorystream, users);
            using (FileStream stream = File.Create("Users.json"))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(

                        stream,
                        System.Text.Encoding.UTF8,
                        false,
                        true))
                {
                    jsonSerializer.WriteObject(writer,users);
                }
            }
        }
*/

        public void SaveUser(List<User> users)
        {

            string JsonString = JsonConvert.SerializeObject(users,Formatting.Indented);
            Console.WriteLine(JsonString);
            using (StreamWriter streamWriter = new("Users.json"))
            {
                using(JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new();
                    serializer.Serialize(jsonWriter, users);

                }
            }
        }

        public List<User> LoadUser()
        {
            List<User> users = new List<User>();
            using (StreamReader streamReader = new StreamReader("Users.json"))
            {
                using (JsonTextReader jreader = new JsonTextReader(streamReader))
                {
                   //JObject fileValue = JObject.Read(jreader);

                  //  Console.WriteLine(fileValue);
                }
            }
            return users;
        }
    }
}
