using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class TestAPI
    {
        public async Task Test()
        { 
            string ville = "Deauville";
            Sport s = new Sport(4, "Terrain de Tennis", "Court de tennis", true, true);

            List<Sport> lsport = new List<Sport>();

            lsport.Add(s);

            Search res = new(ville, lsport);
            

            List<Spot> spots= await res.ExecuteSearch();

            foreach(Spot spot in spots)
            {
                Console.WriteLine(spot);
            }

        }



    }
}
