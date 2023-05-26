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
                Request r = new Request(Town, sport);
                List<Spot> spots = await r.FindSpot();
                //Console.WriteLine("Spot 0 : {0}",spots[0]);
                Debug.WriteLine("\"Spot 0 : {0}\",spots[0])");
                foreach (Spot spot in spots)
                {
                    result.Add(spot);
                }

                
            }
            return result;
        }
    }
}
