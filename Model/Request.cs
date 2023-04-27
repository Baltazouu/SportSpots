using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Request
    {
        private HttpClient _httpclient = new HttpClient();

        JsonSerializerOptions _serializerOptions;

        const string dblink = "Host=localhost;Username=postgres;Password=14010;Database=test;";

        static string ApiLink { get; set; }

        public string Town { get; init; }

        public Sport Sport { get; init; }

        public List<Spot> Res { get; set; }

        public Request(string town,Sport s)
        {   
            Sport = s;
            Town = town;
            ApiLink = $"https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es&commune:{town}&famille:{s.Name}";
        }

        /*public async Task<string> FindSpots()
        {   
            //Console.WriteLine(ApiLink);

            //List<Spot> res = new List<Spot>();
            try
            {


                string s = await _httpclient.GetStringAsync(ApiLink);
                //HttpResponseMessage response = await _httpclient.GetAsync(ApiLink);
                //  Console.WriteLine(s);

                JObject apires = JObject.Parse(s);

                //Console.WriteLine(apires.ToString());
                //Console.WriteLine(apires["records"]);

               var records = apires["records"];

                //Console.WriteLine(records);

                //Console.WriteLine(records["fields"].Children());

       

                //Console.WriteLine("api res : ", apires["records"]["coordonnees"].Children().ToString());



                return s;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }*/
        
           public List<Spot> findSpot()
           {
                SpotsStub s = new SpotsStub();
                List<Spot> res = s.LoadSpots();

            return res;

                
           }

        
    }
}