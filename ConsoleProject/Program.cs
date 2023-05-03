// See https://aka.ms/new-console-template for more information

using Model;
using Maui1;
using ConsoleProject;

//TestConn t = new TestConn();

string? Choice;

ReadPasswd r = new();

Console.WriteLine("SportSpots App !");

Console.WriteLine("1. Connexion\n2.Inscription ");
Console.Write("Enter Your Choice : ");
Choice = Console.ReadLine();

while (Choice != "1" && Choice != "2")
{
    Console.WriteLine("Please Choose between 1 or 2 !");
    Console.WriteLine("1. Connexion\n2.Inscription");
    Console.Write("Enter Your Choice : ");
    Choice = Console.ReadLine();
}
Console.Write("Enter Your Email Adress : ");
string? mail = Console.ReadLine();

Console.Write("Enter Your Password : ");

string pass = r.ReadPassword();

Connexion conn = new(mail, pass);

/*while(!conn.InternetAvaible())
{
    Console.WriteLine("[Network Error]\n Check Your Network Connection And Retry...");
    Console.ReadLine();
}

while(!conn.SqlServerAvaible())
{
    Console.WriteLine("[SeverError]\n Sorry Our Server is actually down...");
    Console.ReadLine();
}
*/
if (Choice == "1")
    Connection();

if (Choice == "2")
    Inscription();

void Inscription()
{
    while (conn.CheckMailExist(mail))
    {
        Console.WriteLine("This mail is already taken !");
        if (pass == "" || pass.Length < 6)
        {
            Console.WriteLine("The password need at least 6 chars !");
        }
        Console.Write("Enter Your Email Adress : ");
        mail = Console.ReadLine();

        Console.Write("Enter Your Password : ");
        pass = r.ReadPassword();
        conn = new(mail, pass);
    }
    conn.InsertNewUser(mail, pass);
    Console.WriteLine("[Success Inscription !]");
    UserActions u = new(conn.GetUserID(mail),mail,pass);
    u.ChooseAction();
}

void Connection()
{
    while (!conn.CheckMailExist(mail) || !conn.CheckRightPasswd(mail, pass))
    {
        Console.WriteLine("Invalid Mail Or Password !");
        Console.Write("Enter Your Email Adress : ");
        mail = Console.ReadLine();

        Console.WriteLine("Enter Your Password : ");
        pass = r.ReadPassword();
        conn = new(mail, pass);
    }
    Console.WriteLine("[Success Connection !]");
    UserActions u = new(conn.GetUserID(mail),mail,pass);
    u.ChooseAction();
}



/*

void SearchASpot()
{

    SportStub stub = new();
    List<Sport> avaible = stub.Loadsport();
    int i = 1;

    Console.WriteLine("[Search a Spot]");
    Console.Write("Enter a City For Your Spot : ");
    string? city = Console.ReadLine();

    foreach (Sport s in avaible)
    {
        Console.WriteLine($"{i} :,{s.Name}");
    }



    Console.Write("Enter a Spot Your Spot : ");
    string? sport = Console.ReadLine();

    //Sport s = new Sport(sport, true, true);

//Request r = new Request(city, s);

//List<Spot> res = await r.FindSpot();

//string res_st = await res;

//}

*/

