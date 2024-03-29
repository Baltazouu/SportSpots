﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class SpotStub
    {
        public static ObservableCollection<Spot> LoadSpots()
        {
            ObservableCollection<Spot> list = new ObservableCollection<Spot>();

            list.Add(new("1455", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("1475", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("11355", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("3455", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("1655", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("1355", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true, null));
            list.Add(new("1435", "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", "213313", "12122121", true, true, true,null));

            return list;

        }
    }
}
