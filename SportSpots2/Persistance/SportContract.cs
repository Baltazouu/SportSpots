using Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Persistance
{
    public class SportContract : IDataSport
    {

        
        string SportFile = Path.Combine(Directory.GetCurrentDirectory(), "../Data/Sports.json");
        

        public List<Sport> LoadSports()
        {
            List<Sport>? Sports = new List<Sport>();
            try
            {
                using (StreamReader reader = new StreamReader(SportFile))
                {
                    string json = reader.ReadToEnd();
                    Sports = JsonConvert.DeserializeObject<List<Sport>>(json);
                    if (Sports == null) { Sports = new List<Sport>(); }
                    return Sports;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);

                if (Sports == null) { Sports = new List<Sport>(); }
                return Sports;
            }

           
        }

        public void SaveSports(List<Sport> sports)
        {
            try
            {
                // Test
                Debug.WriteLine("Test user all");
                foreach (var Sport in sports)
                {
                    Debug.WriteLine(sports);
                }

                using (StreamWriter streamWriter = new StreamWriter(SportFile))
                {
                    using (JsonTextWriter jsonWriter = new JsonTextWriter(streamWriter))
                    {
                        jsonWriter.Formatting = Formatting.Indented;
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jsonWriter, sports);
                    }
                }
            }

            catch (Exception)
            {
                return;
            }
            return;
        }
    }
}
