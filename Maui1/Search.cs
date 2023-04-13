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

public class Search
{
    public string town;
    public string Town { get;set;    }

    public string Activity { get; set; }

    public Search(string town,string act)
    {
        Town = town;
        Activity = act;
    }

    List<Spot> finded = new List<Spot>();

   
    
    public static async Task GetJson(string Town,string Activity)
    {
        HttpClient client = new HttpClient();
       
        var json = await client.GetStringAsync(
            $"https://equipements.sports.gouv.fr/api/records/1.0/search/?dataset=data-es&q=commune:{Town}&famille:{ Activity}");

        // a finir

        Console.Write(json);
    }

    public override string ToString()
    {
        return "Ville : " + Town + " Activite : " + Activity;
    }
}
