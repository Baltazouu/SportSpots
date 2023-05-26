using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Model
{
    public class Request
    {

        /// <summary>
        /// Classe Request
        /// Cette classe permet de gerer la partie connexion avec l'api data-es
        /// </summary>

        private readonly HttpClient _httpclient = new HttpClient();

        string ApiLink { get; set; }

        public string Town { get; init; }

        public Sport Sport { get; init; }

        public List<Spot> Res { get; set; }

        public Request(string town, Sport s)
        {
            Sport = s;
            Res = new List<Spot>();
            Town = town;
            ApiLink = $"https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es&q=commune%3A{town}%26famille%3A{s.TypeEquipement}&rows=15";
        }
        

        /// <summary>
        /// Methode Asynchrone permettant de retourner une liste de spots trouves en fonction de
        /// l'url de l'api
        /// </summary>
        /// <returns></returns>
        public async Task<List<Spot>> FindSpot()
        {
            List<Spot> res = new List<Spot>();
            Debug.WriteLine(ApiLink);
            try
            {
                Debug.WriteLine("Requete : {0}", ApiLink);

                Debug.WriteLine("Link API {0}", ApiLink);


                _httpclient.Timeout = TimeSpan.FromMinutes(2);
                string s = await _httpclient.GetStringAsync(ApiLink);
                
                //HttpResponseMessage response = await _httpclient.GetAsync(ApiLink);
                //  Console.WriteLine(s);

                JObject apires = JObject.Parse(s);

              
                int ? nbRecords = apires?["parameters"]?["rows"]?.Value<int>();
                
                Debug.WriteLine("Nombre de rows :{0}", nbRecords);

                for (int i = 0; i < nbRecords; i++)
                {
                    Debug.WriteLine("Passage {0}", i);
                    // access handicap caract 3
                    // restauration carct 9
                    // access libre = caract25
                    string? access_handicap = (string?)apires?["records"]?[i]?["fields"]?["carct3"];
                    string? restauraton = (string?)apires?["records"]?[i]?["fields"]?["carct9"];
                    string?  acces_free = (string?)apires?["records"]?[i]?["fields"]?["caract25"];

                   // if(access_handicap == null || restauraton == null || acces_free == null)
                    //    continue;

                    bool ac_handic; // default values false
                    bool ac_free;
                    bool ac_restauration;

                    if (access_handicap == "" || access_handicap == null)
                    {
                        ac_handic = false;
                    }
                    else ac_handic = true;


                    if (acces_free != "" || acces_free != null)
                    {
                        ac_free = false;
                    }
                    else ac_free = true;

                    if (restauraton != "" || restauraton != null)
                    {
                        ac_restauration = false;
                    }
                    else ac_restauration = true;

                    Debug.WriteLine("Code Insee {0}",apires?["records"]?[i]?["fields"]?["codeinsee"]?.Value<int>());
                    Debug.WriteLine("Nom commune : {0}",apires?["records"]?[i]?["fields"]?["nom_commune"]?.Value<string>());

                    int? codeInsee = apires?["records"]?[i]?["fields"]?["codeinsee"]?.Value<int>();
                    string? nomCommune = apires?["records"]?[i]?["fields"]?["nom_commune"]?.Value<string>();
                    string? nomInstall = apires?["records"]?[i]?["fields"]?["nominstallation"]?.Value<string>();
                    string? family = apires?["records"]?[i]?["fields"]?["famille"]?.Value<string>();
                    string? address = apires?["records"]?[i]?["fields"]?["adresse"]?.Value<string>();
                    int? codePostal = apires?["records"]?[i]?["fields"]?["codepostal"]?.Value<int>();
                    string? dept = apires?["records"]?[i]?["fields"]?["nom_dept"]?.Value<string>();
                    double? coord_x = apires?["records"]?[i]?["fields"]?["coordonnees"]?[0]?.Value<double>();
                    double? coord_y = apires?["records"]?[i]?["fields"]?["coordonnees"]?[1]?.Value<double>();

                    res.Insert(i, new Spot(codeInsee,
                                           nomCommune,
                                           nomInstall,
                                           family,
                                           address,
                                           codePostal,
                                           dept,
                                           coord_x,
                                           coord_y,
                                           ac_handic,
                                           ac_restauration,
                                           ac_free));


                    Debug.WriteLine(res[i].ToString());
                }

                
                return res;
            }
            catch (Exception e)
            {
                //Console.WriteLine("on est dans l'exception");
                //Console.WriteLine("error {0}", e.Message);
                Debug.WriteLine(e.Message);
                return res;
            }
        }
    }
}