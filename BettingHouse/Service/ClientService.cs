using BettingHouse.Helpers;
using BettingHouse.Models;
using BettingHouse.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BettingHouse.Models.EnumType;

namespace BettingHouse.Service
{
    public class ClientService: MenuHelper
    {

        internal Game inputGameBet;
        internal Team inputTeamBet;
        internal decimal inputAmountBet;
        internal decimal winCotaBet;
        internal decimal inputCota;
        private int teamIndex;


        public void ShowPlaceBetInterface(int menuSelection, Customer client)
        {
            decimal answer = 0;
            string winnerString;
            int teamSelection = 0;
            decimal calcPotentialOutcome;
            Bet newBet = new Bet();
            //while (!isPharsed)
            //{
            //    UIDecoration.Dialog("Select a game to place your bet on");
            //    isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a option with that index", 1, Data.Data.Games.Count + 1, out menuSelection);
            //}
            newBet.Id = Guid.NewGuid();
            newBet.CustomerId = client.Id;

            inputGameBet = Data.Data.Games[menuSelection - 1];
            newBet.Game = inputGameBet;

            UIDecoration.Dialog("Insert Winner Team:");

            clearMenuOptions();
            foreach (Team teamsGame in inputGameBet.Teams)
            {
                menu.Add(teamsGame.Name);
            }

            if (inputGameBet.GameType == GameType.Tenis || inputGameBet.GameType == GameType.PinPong)
            {
                menu.Add("Draw");
            }
            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Wrong value", 1, inputGameBet.Teams.Count + 1, out teamSelection);

            //inputTeamBet = Data.Data.Teams.Where(x => x.Name.ToLower() == winnerString).FirstOrDefault();
            //teamIndex = Data.Data.Games[menuSelection - 1].Teams.FindIndex(x => x.Name.ToLower() == winnerString);
            if (inputGameBet.GameType != GameType.HorseRace && teamSelection == 3)
            {
                inputTeamBet = null;             
            }
            else
            {
                inputTeamBet = inputGameBet.Teams[teamSelection - 1];
            }
           
            newBet.Team = inputTeamBet;

            inputCota = inputGameBet.Cote[teamSelection - 1];
            newBet.Cota = inputCota;

           

            //plateste 
            isPharsed = false;
            while (!isPharsed)
            {
                isPharsed = UIDecoration.Question("Insert bet Amount", "Error! Parse nok!", out answer);
            }
            inputAmountBet = answer;

            calcPotentialOutcome =inputCota * inputAmountBet;
            newBet.PotentialOutcome = calcPotentialOutcome;
            if (client.Balance < inputAmountBet)
            {
                UIDecoration.Error("Error! Your balance is not covering the ammount!");
                ShowPlaceBetInterface(menuSelection, client);
            }

            if (Data.Data.House.MoneyAvailable < calcPotentialOutcome)
            {
                UIDecoration.Error($"Error! The House has a bet limit of {Data.Data.House.MoneyAvailable}!");
                ShowPlaceBetInterface(menuSelection, client);
            }

                newBet.Amount = inputAmountBet;
                 
            //adauga in lista beturilor si scade balanta clientului
            client.BetHistory.Add(newBet);
            client.Balance -= inputAmountBet;
            Data.Data.House.Balance += inputAmountBet;
            UIDecoration.Dialog($"Bet was Placed!. Potential win $ {calcPotentialOutcome}");
        }
        
    }
}
