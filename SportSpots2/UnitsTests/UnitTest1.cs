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
            List<User> users = UserStub.LoadUser();

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
            List<User> users = UserStub.LoadUser();

            Assert.False(users.Count != 5);
        }

        [Fact]
        public void TestJson()
        {
            List<User> users = UserStub.LoadUser();

            DataContractJson dt = new();



            Assert.True(dt.SaveUser(users));
        }
      



    }
}