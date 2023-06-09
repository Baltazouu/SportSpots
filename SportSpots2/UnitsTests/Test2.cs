using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitsTests
{
    public class Test2
    {


        [Fact]

        void TestAjoutFav()
        {

            Spot s = new Spot("1444", "Paris", "Spot", "Terrain de foot", "rue des champeaux", 7800, "Paris", "", "", false, false, false, "Spot");

            UserStub stub = new UserStub();

            List<User> listeuser = stub.LoadUser().Item2;

            User u = listeuser[0];

            u.AddToFavSpot(s);

            Assert.False(u.AddToFavSpot(s));

        }

        [Fact]
        void TestAjoutHistory()
        {


            ObservableCollection<Sport> l = SportStub.Loadsport();

            Sport s = l[0];

            UserStub stub = new UserStub();

            List<User> listeuser = stub.LoadUser().Item2;

            User u = listeuser[0];

            u.AddSToFavSport(s);

            Assert.False(u.AddSToFavSport(s));

        }

        /// <summary>
        /// Tests Resultats api
        /// </summary>
        /// <param name="town">Vile cible</param>
        /// <param name="n">sport stub cible</param>
        [Theory]
        [InlineData("Paris", 0)]
        [InlineData("Paris", 1)]
        [InlineData("Paris", 2)]
        [InlineData("Paris", 3)]
        [InlineData("Paris", 4)]
        [InlineData("Paris", 5)]
        [InlineData("Paris", 6)]
        public async void TestRequest(string town, int n)
        {

            ObservableCollection<Sport> l = SportStub.Loadsport();
            Request r = new(town, l[n]);

            await r.FindSpot();

            Assert.True(r.Res.Count > 1);


        }
    }
}
