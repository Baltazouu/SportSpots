using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Search
    {
        
        /// <summary>
        /// Cette classe permet de gerer la recherche de spots 
        /// Une recherche contient une ville de recherche
        /// Elle contient egalement une liste de sports a rechercher
        /// Pour la ville specifiee
        /// </summary>


        string Town { get; init; }
        List<Sport> SportsToFind { get; init; }

        public int PostalCode { get; init;  }

        public Search(string town, List<Sport> sports,int cp)
        {
            Town = town;
            SportsToFind = sports;
            PostalCode = cp;

        }

        public Search(string town,List<Sport>sports)
        {
            Town = town;
            SportsToFind = sports;
        }
        /// <summary>
        /// Charger les spots trouves 
        /// Selon chaque sport specifie
        /// </summary>
        /// <returns>retourne la liste des spots trouves</returns>
        public async Task<List<Spot>> ExecuteSearch()
        {
            List<Spot> result = new List<Spot>();

            foreach (Sport sport in SportsToFind)
            {
                List<Spot> spots = null;
                if (PostalCode > 0 && PostalCode <= 99)
                {
                    Request r = new Request(Town, sport, PostalCode);
                    spots = await r.FindSpot();
                }
                else
                {
                    Request r = new Request(Town, sport);
                    spots = await r.FindSpot();
                }

                //Console.WriteLine("Spot 0 : {0}",spots[0]);
                Debug.WriteLine("\"Spot 0 : {0}\",spots[0])");
                foreach (Spot spot in spots)
                {
                    /*
                    int find = 0;
                    // méthode pour éviter les doublons à revoir
                    foreach(Spot sp in spots)
                    {
                        if (sp.Numero == spot.Numero)
                            find += 1;
                    }
                    
                    if (find < 2)
                    {        
                        spot.ImgLink = sport.ImgLink;
                        result.Add(spot);
                    }*/
                    spot.ImgLink = sport.ImgLink;
                    result.Add(spot);
                }
                                
            }
            return result;
        }
    }
}
