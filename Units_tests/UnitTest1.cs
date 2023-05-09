using Model;


namespace Units_tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            User u = new(1566, "bapt.14@hotmail.com", "");

            bool res = u.ChangePasswd("new");

            Assert.True(res);
        }
    }
}