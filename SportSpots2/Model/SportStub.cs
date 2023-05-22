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
    public static class SportStub
    { 
        public static List<Sport> Loadsport()
        {
            List<Sport> sport = new List<Sport>();

            sport.Insert(0, new Sport(1, "Terrain de Pétanque", "Terrain de pétanque", true, true,""));
            sport.Insert(1, new Sport(2, "Terrain de Football", "Terrain de Football", true, true, ""));
            sport.Insert(2, new Sport(3, "Salle de musculation", "Salle de musculation/cardiotraining", false, false,""));
            sport.Insert(3, new Sport(4, "Terrain de Tennis", "Court de tennis", true, true,""));
            sport.Insert(4, new Sport(5, "Piste d'athlétisme", "Piste d'athlétisme isolée", true, true,""));
            sport.Insert(5, new Sport(6, "Terrain de Rugby", "Terrain de rugby", true, true,""));
            sport.Insert(6, new Sport(7, "Terrain de Basket", "Terrain de basket-ball", true, true,""));
            sport.Insert(7, new Sport(8, "Site de Voile", "Site d'activités aquatiques et nautiques", true, false,""));
            sport.Insert(8, new Sport(9, "CityStades ", "Plateau EPS/Multisports/city-stades", true, false,""));

            return sport;
        }

    }





}
