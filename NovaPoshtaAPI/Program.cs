using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using NovaPoshtaApi;
using NovaPoshtaAPIBleBla;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Gukee");
        NovaPostService nps = new NovaPostService();
        nps.GetAreas();
        nps.GetSettlements();

        Console.WriteLine("#########Areas###########\n");
        nps.ShowArea();
        Thread.Sleep(10000);
        Console.WriteLine("\n#########Settlements#########\n");             //Список занадто великий і консоль не може його вмістити
        nps.ShowSettlements();
        //string apiKey = "917287e88b0a212026f65478f71ffcdb";

    }
}