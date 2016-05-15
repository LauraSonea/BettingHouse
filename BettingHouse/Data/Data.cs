using System;
using System.Collections.Generic;
using BettingHouse.Models;
using System.Linq;

namespace BettingHouse.Data
{
    
    public static partial class Data
    {
        

        public static List<Customer> Customers { get; set; }
        public static List<Team> Teams { get; set; }
        public static List<Game> Games { get; set; }
        public static List<Bet> Bets { get; set; }
        public static BetHouse House { get; set; }

       


        public static void LoadJson()
        {

            string pathWork = "C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\";
            string pathHome = "D:\\development\\BettingHouse\\BettingHouse\\DATAFILES";

            Customers = ReadJsonFile.ReadFromJsonFile<List<Customer>>(pathHome + "Customers.JSON");
            Teams = ReadJsonFile.ReadFromJsonFile<List<Team>>(pathHome + "Teams.JSON");
            Games = ReadJsonFile.ReadFromJsonFile<List<Game>>(pathHome + "Games.JSON");
            Bets = ReadJsonFile.ReadFromJsonFile<List<Bet>>(pathHome + "Bets.JSON");
        }
        public static void LoadXML()
        {
            string pathWork = "C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\";
            string pathHome = "D:\\development\\BettingHouse\\BettingHouse\\DATAFILES";

            Customers = ReadXMLFile.ReadFromXmlFile<List<Customer>>(pathHome + "Customers.XML");
            Teams = ReadXMLFile.ReadFromXmlFile<List<Team>>(pathHome + "Teams.XML");
            Games = ReadXMLFile.ReadFromXmlFile<List<Game>>(pathHome + "Games.XML");
            Bets = ReadXMLFile.ReadFromXmlFile<List<Bet>>(pathHome + "Bets.XML");
        }
        public static void WriteJson()
        {
            string pathWork = "C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\";
            string pathHome = "D:\\development\\BettingHouse\\BettingHouse\\DATAFILES";

            WriteJsonFile.WriteToJsonFile(pathHome + "Customers.JSON", Customers);
            WriteJsonFile.WriteToJsonFile(pathHome + "Teams.JSON", Teams);
            WriteJsonFile.WriteToJsonFile(pathHome + "Games.JSON", Games);
            WriteJsonFile.WriteToJsonFile(pathHome + "Bets.JSON", Bets);

        }
        public static void WriteXML()
        {
            string pathWork = "C:\\!Work\\BettingHouse\\BettingHouse\\BettingHouse\\DATAFILES\\";
            string pathHome = "D:\\development\\BettingHouse\\BettingHouse\\DATAFILES";

            WriteXMLFile.WriteToXmlFile(pathHome + "Customers.XML", Customers);
            WriteXMLFile.WriteToXmlFile(pathHome + "Teams.XML", Teams);
            WriteXMLFile.WriteToXmlFile(pathHome + "Games.XML", Games);
            WriteXMLFile.WriteToXmlFile(pathHome + "Bets.XML", Bets);

        }
        public static List<Game> ListGamesForBet()
        {
            List<Game> gamesForBet = new List<Game>();

            gamesForBet = Games.Where(x => x.isFinish == false).ToList();
            return gamesForBet;
        }

      
    }
}


