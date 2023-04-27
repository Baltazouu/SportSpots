// See https://aka.ms/new-console-template for more information

using Maui1;
using Model;
/*
Console.WriteLine("Welcome to SportSpots Console APP");

Connection conn = new Connection();
*/
//conn.adduser();



Sport s = new Sport("Tennis", true, true);

Request r = new Request("Paris",s);

Task<string> res = r.FindSpots();

string res_st = await res;

//Console.WriteLine("res : {0}",res_st);

// Console.WriteLine("On est arrives jusque la");
