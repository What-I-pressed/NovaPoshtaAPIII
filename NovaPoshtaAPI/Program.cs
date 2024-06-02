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

        //string apiKey = "917287e88b0a212026f65478f71ffcdb";

    }
}