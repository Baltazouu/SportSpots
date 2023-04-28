// See https://aka.ms/new-console-template for more information

using Model;
using Maui1;
/*
Console.WriteLine("Welcome to SportSpots Console APP");

Connection conn = new Connection();
*/
//conn.adduser();

while(true)
{
    Console.Write("Enter The City Of Your Search : ");
    string Town = Console.ReadLine();

    List<Sport> SportList = new List<Sport>();

    Console.WriteLine("Searchs Sports : ");
    Menue m = new Menue();
    Sport s = m.MenueRech();

    SportList.Insert(0, s);

    Search recherche  = new Search(Town,SportList);

    var res = await recherche.ExecuteSearch();

    foreach (Spot sp in res)
    {
        Console.WriteLine(sp);
    }
}


/*
while(true)
{
    Console.WriteLine("[Search a Spot]");
    Console.Write("Enter a City For Your Spot : ");
    string city = Console.ReadLine();

    Console.Write("Enter a Spot Your Spot : ");
    string sport = Console.ReadLine();

    Sport s = new Sport(sport, true, true);

    Request r = new Request(city, s);

    List<Spot> res = await r.FindSpot();

    //string res_st = await res;

    //Console.WriteLine("res : {0}",res_st);

    // Console.WriteLine("On est arrives jusque la");

    foreach (Spot sp in res)
    {
        Console.WriteLine(sp);
    }
}*/
