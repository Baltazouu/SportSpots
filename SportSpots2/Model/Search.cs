using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class Search To Manage the Link With the request class
    /// The difference with this class is that this one 
    /// allow to search several Sports this class can find spots for different sport
    /// </summary>
    public class Search
    {
        

        /// <summary>
        /// Target Town
        /// </summary>
        string Town { get; init; }

        /// <summary>
        /// list of sports to find
        /// </summary>
        List<Sport> SportsToFind { get; init; }

        /// <summary>
        /// PostalCode (optionnal)
        /// </summary>
        public int PostalCode { get; init;  }

        public Search(string town, List<Sport> sports,int cp)
        {
            Town = town;
            SportsToFind = sports;
            PostalCode = cp;

        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="town">target</param>
        /// <param name="sports">List of sports to find</param>
        public Search(string town,List<Sport>sports)
        {
            Town = town;
            SportsToFind = sports;
        }


        /// <summary>
        /// Load Sports
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
