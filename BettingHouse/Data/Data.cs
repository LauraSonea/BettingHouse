using System;
using System.Collections.Generic;
using BettingHouse.Models;


namespace BettingHouse.Data
{
    public static partial class Data
    {
        public static List<Customer> Customers { get; set; }
        public static List<Team> Teams { get; set; }
        public static List<Game> Games { get; set; }
        public static List<Bet> Bets { get; set; }

        public static void LoadJson()
        {
            Customers = ReadJsonFile.ReadFromJsonFile<List<Customer>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Customers.JSON");
            Teams = ReadJsonFile.ReadFromJsonFile<List<Team>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Teams.JSON");
            Games = ReadJsonFile.ReadFromJsonFile<List<Game>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Games.JSON");
            Bets = ReadJsonFile.ReadFromJsonFile<List<Bet>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Bets.JSON");
        }
        public static void LoadXML()
        {
            Customers = ReadXMLFile.ReadFromXmlFile<List<Customer>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Customers.XML");
            Teams = ReadXMLFile.ReadFromXmlFile<List<Team>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Teams.XML");
            Games = ReadXMLFile.ReadFromXmlFile<List<Game>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Games.XML");
            Bets = ReadXMLFile.ReadFromXmlFile<List<Bet>>("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Bets.XML");
        }
        public static void WriteJson()
        {
            WriteJsonFile.WriteToJsonFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Customers.JSON", Customers);
            WriteJsonFile.WriteToJsonFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Teams.JSON", Teams);
            WriteJsonFile.WriteToJsonFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Games.JSON", Games);
            WriteJsonFile.WriteToJsonFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Bets.JSON", Bets);

        }
        public static void WriteXML()
        {
            WriteXMLFile.WriteToXmlFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Customers.XML", Customers);
            WriteXMLFile.WriteToXmlFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Teams.XML", Teams);
            WriteXMLFile.WriteToXmlFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Games.XML", Games);
            WriteXMLFile.WriteToXmlFile("C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\Bets.XML", Bets);

        }
    }
}


