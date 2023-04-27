using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class SpotsStub
    {

        List<Spot> spots;

        public SpotsStub() 
        
        {
            


        }


        public List<Spot> LoadSpots()
        {
            List<Spot> res = new List<Spot>();

            for (int i = 0; i < 10; ++i)
            {
                res.Insert(i, new Spot(155,
                                       "Stade Cezeaux",
                                       "athlétisme",
                                       "stade",
                                       "8 rue des cezeaux",
                                       63000,
                                       45.758040,
                                       3.106278,
                                       false,
                                       false,
                                       false));

                res.Insert(i, new Spot(155, "Stade Marcombes", "athlétisme", "stade","8 rue philippe marcomnes",  63000, 45.760510, 3.083539, false, false, false));

                res.Insert(i, new Spot(155, "Stade Marcombes", "tennis", "stade", 63000, 45.758040, 3.106278, false, false, false));

                res.Insert(i, new Spot(155, "AUBIERE TENNIS CLUB", "tennis", "club tennis", 63000, "45.758085", "3.115960", false, false, false));


                res.Insert(i, new Spot(155, "Stade Cezeaux", "athlétisme", "stade", 63000, "45.758040", "3.106278", false, false, false));

                res.Insert(i, new Spot(155, "Stade Cezeaux", "athlétisme", "stade", 63000, "45.758040", "3.106278", false, false, false));

                res.Insert(i, new Spot(155, "Stade Cezeaux", "athlétisme", "stade", 63000, "45.758040", "3.106278", false, false, false));

                res.Insert(i, new Spot(155, "Stade Cezeaux", "athlétisme", "stade", 63000, "45.758040", "3.106278", false, false, false));
                    
            }




            return res;




        }


    }
}
