using Model;
using Persistance;

namespace UnitsTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        { 
            List<Sport> avaible = new();
            avaible = SportStub.Loadsport();

            Assert.NotNull(avaible);
            Assert.False(avaible.Count==0);
        }

        [Fact]
        public void TestStubUser()
        {
            Data dt = new();
            
            List<User> users = dt.LoadData(new UserStub()).Item2;

            Assert.False(users.Count != 5);
        }

        [Fact]
        public void TestStubSpot()
        {
            List<Spot> spots = SpotStub.LoadSpots();

            Assert.False(spots.Count == 0);
        }

        [Fact]
        public void TestStub()
        {
            Data dt = new();
            List<User> users = dt.LoadData(new UserStub()).Item2;

            Assert.False(users.Count != 5);
        }

        [Fact]
        public void TestJson()
        {
            Data dtstub = new();
            List<User> users = dtstub.LoadData(new UserStub()).Item2; 

            DataContractJson dt = new();

            Assert.True(dt.SaveUser(users));
        }
      



    }
}