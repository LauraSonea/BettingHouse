using System;
using System.Collections.Generic;
using BettingHouse.Models;

namespace BettingHouse.Data
{
    public static partial class Data
    {

        public static void Seeding()
        {
            
            InitCustomers();
            InitTeams();
            InitGames();
            InitBets();
            InitBetHouse();
        }
        public static void InitCustomers()
        {
            if (Customers == null)
            {
                Customers = new List<Customer>();
            }

            Customer newCustomer = new Customer() { Id = Guid.NewGuid(), Name = "admin", IsAdmin = true };
            Customers.Add(newCustomer);
            newCustomer = new Customer() { Id = Guid.NewGuid(), Name = "John", Balance = 5000m };
            Customers.Add(newCustomer);
        }
        public static void InitTeams()
        {
            if (Teams == null)
            {
                Teams = new List<Team>();
            }

            Team newTeam = new Team() { Id = Guid.NewGuid(), Name = "Asians", GameType = EnumType.GameType.PinPong };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "Europeans", GameType = EnumType.GameType.PinPong };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "BlackLuck", GameType = EnumType.GameType.HorseRace };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "Roibu", GameType = EnumType.GameType.HorseRace };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "8Ball", GameType = EnumType.GameType.HorseRace };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "Halep", GameType = EnumType.GameType.Tenis };
            Teams.Add(newTeam);
            newTeam = new Team() { Id = Guid.NewGuid(), Name = "Djokovic", GameType = EnumType.GameType.Tenis };
            Teams.Add(newTeam);

        }
        public static void InitGames()
        {
            if (Games == null)
            {
                Games = new List<Game>();
            }
        }
        public static void InitBets()
        {
            if (Bets == null)
            {
                Bets = new List<Bet>();
            }
        }
        public static void InitBetHouse()
        {
            if (House == null)
                {
                House = new BetHouse();
            }
            
            House.Name = "House777";
            House.Balance = 100000m;
            House.Treshhold = 0.5m;
           
        }
    }
}

