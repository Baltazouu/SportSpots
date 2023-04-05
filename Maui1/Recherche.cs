using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace Maui1;

internal class Recherche
{
    string Town { get; set; }
    string Activity { get; set; }

    List<Spot> finded = new List<Spot>();

    HttpClient client = new HttpClient();
    
    static async Task getjson(HttpClient client,string url,string town,string act)
    {
        var json = await client.GetStringAsync(
            $"https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es&q=commune:{town}&famille:{act}");

        // a finir
        

        Console.Write(json);
    }
}
