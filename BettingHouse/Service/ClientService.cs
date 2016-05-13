using BettingHouse.Helpers;
using BettingHouse.Models;
using BettingHouse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingHouse.Service
{
    public class ClientService: MenuHelper
    {

        internal Game inputGameBet;
        internal Team inputTeamBet;
        internal decimal inputAmountBet;
        internal decimal winCotaBet;
        private int teamIndex;

        public void PlaceBet(Customer client)
        {

        }

        public void ShowPlaceBetInterface(List<string> menu, Customer client)
        {
            decimal answer = 0;
            string winnerString;

            while (!isPharsed)
            {
                UIDecoration.Dialog("Select a game to place your bet on");
                isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a option with that index", 1, Data.Data.Games.Count + 1, out menuSelection);
            }
            inputGameBet = Data.Data.Games[menuSelection - 1];

            isPharsed = false;
            while (!isPharsed)
            {
                isPharsed = UIDecoration.Question("Insert bet Amount", "Error! Parse nok!", out answer);
            }
            inputAmountBet = answer;

            UIDecoration.Dialog("Insert Winner Team:");
            winnerString = Console.ReadLine().ToLower();
            inputTeamBet = Data.Data.Teams.Where(x => x.Name.ToLower() == winnerString).FirstOrDefault();

            teamIndex = Data.Data.Games[menuSelection - 1].Teams.FindIndex(x => x.Name.ToLower() == winnerString);
          
        }

    }
}
