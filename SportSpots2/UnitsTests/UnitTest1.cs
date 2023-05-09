namespace UnitsTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        { 
            List<Sport> avaible = new();
            avaible = SportStub.Loadsport();

            Assert.Empty(avaible);
        }
    }
}