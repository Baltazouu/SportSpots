using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsTests
{
    [Fact]
    public void UserTests()
    {
        List<User> s = new();
        s = UserStub.LoadUser();

        Assert.NotNull(s);

    }

   
}
