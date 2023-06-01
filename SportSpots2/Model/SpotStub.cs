using System;
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

            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));
            list.Add(new(1455, "Paris", "terrain de Foot", "Terrains de Football", "8 rue des champeux", 78000, "Paris", 213313, 12122121, true, true, true));

            return list;

        }
    }
}
