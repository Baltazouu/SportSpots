using ConsoleProject;
using Model;
using Persistance;

/*MainProg mainProg = new MainProg();
await mainProg.Prog();*/


DataContractJson dt = new();

List<User> users = UserStub.LoadUser();

/*

Console.WriteLine("[Users :]");
foreach (User user in users)
    Console.WriteLine(user.ToString());

Console.WriteLine("SAVE USERS : ");
dt.SaveUser(users);
*//*Console.WriteLine("SAVE OK");
List<User> l = dt.LoadUser();
foreach (User user in l)
    Console.WriteLine(user);*/

Console.WriteLine("Load :");
List<User> u = dt.LoadUser();

foreach (var user in users)
{
    Console.WriteLine(user.ToString());
    foreach(Spot s in user.FavSpots)
    { Console.WriteLine(s.ToString()); }
}
    