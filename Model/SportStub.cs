using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// load data

namespace Model
{   
    /// <summary>
    /// Load Sports
    /// </summary>
    public class SportStub
    {
        public SportStub() { }

        public List<Sport> Loadsport()
        {
            List<Sport> sport = new List<Sport>();

            sport.Insert(0, new Sport("Terrain de Pétanque", "Terrain de pétanque", true, true));
            sport.Insert(1, new Sport("Terrain de Football", "Terrain de Football", true, true));
            sport.Insert(2, new Sport("Salle de musculation", "Salle de musculation/cardiotraining", false, false));
            sport.Insert(3, new Sport("Terrain de Tennis", "Court de tennis", true, true));
            sport.Insert(4, new Sport("Piste d'athlétisme", "Piste d'athlétisme isolée", true, true));
            sport.Insert(5, new Sport("Terrain de Rugby", "Terrain de rugby", true, true));
            sport.Insert(6, new Sport("Terrain de Basket", "Terrain de basket-ball", true, true));
            sport.Insert(7, new Sport("Site de Voile", "Site d'activités aquatiques et nautiques", true, false));
            sport.Insert(8, new Sport("CityStades ", "Plateau EPS/Multisports/city-stades", true, false));

            return sport;
        }

    }


    


}
