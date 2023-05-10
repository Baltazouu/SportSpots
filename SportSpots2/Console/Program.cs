using ConsoleProject;
using Model;
using System.Runtime.Serialization.DataContracts;

/*MainProg mainProg = new MainProg();
await mainProg.Prog();*/


DataContractJson dt = new();

List<User> users = UserStub.LoadUser();


dt.SaveUser(users);
Console.WriteLine("SAVE OK");
List<User> l = dt.LoadUser();
foreach (User user in l)
    Console.WriteLine(user);