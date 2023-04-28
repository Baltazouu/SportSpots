using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Request
    {

        /// <summary>
        /// Classe Request
        /// Cette classe permet de gerer la partie connexion avec l'api data-es
        /// </summary>

        private HttpClient _httpclient = new HttpClient();

        JsonSerializerOptions _serializerOptions;

        const string dblink = "Host=localhost;Username=postgres;Password=14010;Database=test;";

        static string ApiLink { get; set; }

        public string Town { get; init; }

        public Sport Sport { get; init; }

        public List<Spot> Res { get; set; }

        public Request(string town, Sport s)
        {
            Sport = s;
            Town = town;
            ApiLink = $"https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es&q=commune%3A{town}%26typequipement%3A{s.TypeEquipement}";

        }
        

        /// <summary>
        /// Methode Asynchrone permettant de retourner une liste de spots trouves en fonction de
        /// l'url de l'api
        /// </summary>
        /// <returns></returns>
        public async Task<List<Spot>> FindSpot()
        {
            List<Spot> res = new List<Spot>();
            try
            {
                //Console.WriteLine("Requete : {0}", ApiLink);

                string s = await _httpclient.GetStringAsync(ApiLink);
                //HttpResponseMessage response = await _httpclient.GetAsync(ApiLink);
                //  Console.WriteLine(s);

                JObject apires = JObject.Parse(s);

                // apires["parameters"]["nhits"].Value<int>();
                int nbRecords = apires["nhits"].Value<int>();

                //Console.WriteLine("Nombre de rows :{0}", nbRecords);

                for (int i = 0; i < nbRecords; i++)
                {
                    // access handicap caract 3
                    // restauration carct 9
                    // access libre = caract25
                    string access_handicap = (string)apires["records"][i]["fields"]["carct3"];
                    string restauraton = (string)apires["records"][i]["fields"]["carct9"];
                    string acces_free = (string)apires["records"][i]["fields"]["caract25"];

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

                    int codeInsee = apires["records"][i]["fields"]["codeinsee"].Value<int>();

                    bool code_Present = false;
                    foreach(Spot sp in res)
                    {
                        if(sp.Numero == codeInsee)
                        { code_Present = true; break; }
                    }
                    if (code_Present)
                        continue;

                    res.Insert(i, new Spot(apires["records"][i]["fields"]["codeinsee"].Value<int>(),
                                           apires["records"][i]["fields"]["nom_commune"].Value<string>(),
                                           apires["records"][i]["fields"]["nominstallation"].Value<string>(),
                                           apires["records"][i]["fields"]["famille"].Value<string>(),
                                           apires["records"][i]["fields"]["adresse"].Value<string>(),
                                           apires["records"][i]["fields"]["codepostal"].Value<int>(),
                                           apires["records"][i]["fields"]["nom_dept"].Value<string>(),
                                           apires["records"][i]["fields"]["coordonnees"][0].Value<double>(),
                                           apires["records"][i]["fields"]["coordonnees"][1].Value<double>(),
                                           ac_handic,
                                           ac_restauration,
                                           ac_free));
                    
                }
                return res;
            }
            catch (Exception e)
            {   
                Console.WriteLine("error 1", e.Message);
                return res;
            }
        }

        /// <summary>
        /// Methode permettant de charger les donnes en fonction de la classe stub
        /// qui simule une requete API
        /// </summary>
        /// <returns></returns>


        /*
        public List<Spot> FindHubSpot()
       {
            SpotsStub s = new SpotsStub();
            List<Spot> res = s.LoadSpots();

        return res;


       }*/




    }
}