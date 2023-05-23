﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ReadOnlyCollection<Sport> SportCollection { get; private set; }

        public SportStub()
        {
            SportCollection = new ReadOnlyCollection<Sport>(Loadsport());
        }

        public static List<Sport> Loadsport()
        {
            List<Sport> sport = new List<Sport>();

            sport.Insert(0, new Sport(1, "Terrain de Pétanque", "Terrain de pétanque", true, true,"petanque.png"));
            sport.Insert(1, new Sport(2, "Terrain de Football", "Terrain de Football", true, true, "foot.png"));
            sport.Insert(2, new Sport(3, "Salle de musculation", "Salle de musculation/cardiotraining", false, false, "muscu.png"));
            sport.Insert(3, new Sport(4, "Terrain de Tennis", "Court de tennis", true, true, "tennis.png"));
            sport.Insert(4, new Sport(5, "Piste d'athlétisme", "Piste d'athlétisme isolée", true, true, "run.png"));
            sport.Insert(5, new Sport(6, "Terrain de Rugby", "Terrain de rugby", true, true, "rugby.png"));
            sport.Insert(6, new Sport(7, "Terrain de Basket", "Terrain de basket-ball", true, true, "basket.png"));
            sport.Insert(7, new Sport(8, "Site de Voile", "Site d'activités aquatiques et nautiques", true, false, "piscine.png"));
            sport.Insert(8, new Sport(9, "CityStades ", "Plateau EPS/Multisports/city-stades", true, false, "city.png"));

            return sport;
        }

    }





}
