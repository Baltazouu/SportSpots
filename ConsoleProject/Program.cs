// See https://aka.ms/new-console-template for more information

using Model;
using Maui1;
using ConsoleProject;


MainProg mainProg = new MainProg();
await mainProg.Prog();

//TestConn t = new TestConn();

//TestAPI test = new();

/*
void SearchASpot()
{

    SportStub stub = new();
    //List<Sport> avaible = stub.Loadsport();
    int i = 1;

    Console.WriteLine("[Search a Spot]");
    Console.Write("Enter a City For Your Spot : ");
    string? city = Console.ReadLine();

    *//*foreach (Sport s in avaible)
    {
        Console.WriteLine($"{i} :,{s.Name}");
    }*//*



    Console.Write("Enter a Sport Your Spot : ");
    string? sport = Console.ReadLine();
*//*
    Sport s = new Sport(sport, true, true);

    Request r = new Request(city, s);

    List<Spot> res = await r.FindSpot();

    string res_st = await res;*//*

//}
*/


