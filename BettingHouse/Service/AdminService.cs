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
    class AdminService : MenuHelper
    {
        internal EnumType.GameType InputGameType;
        internal List<Team> horses = new List<Team>();
        internal MenuListString menuList = new MenuListString() { };
        internal List<decimal> cote = new List<decimal>();
        internal List<Team> InputTeams = new List<Team>();
        public MenuListString ShowTeamList()
        {
            string bufferString = "";

            foreach (Team team in Data.Data.Teams)
            {
                bufferString = $"{team.GameType.ToString()} {team.Name}";

                menuList.ListStringObjects.Add(bufferString);
            }
            return menuList;
        }

        public MenuListString ShowTeamList(EnumType.GameType inputGameType)
        {
            menuList.ListStringObjects = new List<string>();
            string bufferString = "";

            foreach (Team team in Data.Data.Teams.Where(n => n.GameType == inputGameType))
            {

                bufferString = $"{team.GameType.ToString()} {team.Name}";
                menuList.ListStringObjects.Add(bufferString);
            }
            return menuList;
        }

        public void InsertGameAdmin(Customer admin)
        {
            ShowCustomers forList = new ShowCustomers();
            //Customer loged = forList.SelectedCustomer;
            Game newGame = new Game();
            newGame.Cote = new List<decimal>();
            newGame.Teams = new List<Team>();
            newGame.Id = Guid.NewGuid();
            newGame.GameType = InputGameType;

            foreach (Team horse in InputTeams)
            {
                newGame.Teams.Add(horse);
            }

            newGame.Winner = null;
            foreach (decimal cota in cote)
            {
                newGame.Cote.Add(cota);
            }
            //newGame.PlayDate = DateTime.Now;

            Data.Data.Games.Add(newGame);
            Data.Data.WriteXML();
            Data.Data.WriteJson();
            forList.ShowAvailableGames(admin);
        }

        public void InsertTeams(EnumType.GameType inputGameType, string inputName)
        {
            Team newTeam = new Team();
            newTeam.Id = Guid.NewGuid();
            newTeam.GameType = inputGameType;
            newTeam.Name = inputName;
        }

        public void ShowAllBets()
        {
            string bufferString = "";
            menuList.ListStringObjects = new List<string>();

            foreach (Bet bet in Data.Data.Bets)
            {
                bufferString = $"{bet.Game.GameType.ToString()} {bet.Team.Name} {bet.Cota.ToString()} {bet.Amount} {bet.IsValidated}";
                menuList.ListStringObjects.Add(bufferString);
            }
            UIDecoration.List(menuList.ListStringObjects);
        }

        //public void ShowAllGames()
        //{
        //    string bufferString = "";
        //    menuList.ListStringObjects = new List<string>();
        //    foreach (Game game in Data.Data.Games)
        //    {
        //        bufferString = $"{game.GameType.ToString()} {game.Teams.ToString()} {game.Cote} {game.PlayDate}";
        //        menuList.ListStringObjects.Add(bufferString);
        //    }
        //    //return menuList;
        //    clearMenuOptions();
        //    foreach (string objLList in menuList.ListStringObjects)
        //    {
        //        menu.Add(objLList);
        //    }

        //    UIDecoration.List(menu);
        //    Console.ReadLine();
        //}
        public void ShowInsertGameInterface(Customer admin)
        {
            int answer = 0;
            isPharsed = false;
            while (!isPharsed)
            {
                isPharsed = UIDecoration.Question("Insert Game Type (Tenis = 1 / PingPong = 2 / HorseRace = 3)", "Error! Please insert 1, 2 or 3!", out answer);
            }
            //gameType
            InputGameType = (EnumType.GameType)Enum.Parse(typeof(EnumType.GameType), answer.ToString());

            //Teams list for the gameType selected
            clearMenuOptions();

            List<string> ListGameforTypes = ShowTeamList(InputGameType).ListStringObjects;
            foreach (string team in ListGameforTypes)
            {
                menu.Add(team);
            }

            UIDecoration.List(menu);

            if (answer == 1 || answer == 2)
            {
                string selection = "";
                // 2 team

                for (int i = 0; i <= 1; i++)
                {
                    UIDecoration.Dialog($"Insert team name {i + 1}:");
                    selection = Console.ReadLine();
                    foreach (Team team in Data.Data.Teams.Where(x => x.Name == selection))
                    {
                        InputTeams.Add(team);
                    }

                    decimal cotaTeam = 0;
                    isPharsed = false;
                    while (!isPharsed)
                    {
                        isPharsed = UIDecoration.Question($"Insert Cota for Player { InputTeams[i].Name}:", "error! Parse nok!", out cotaTeam);
                    }
                    cote.Add(cotaTeam);
                }
                //insert cote

                decimal cotaDraw = 0;
                isPharsed = false;
                while (!isPharsed)
                {
                    isPharsed = UIDecoration.Question("Insert Cota for Draw:", "error! Parse nok!", out cotaDraw);
                }
                cote.Add(cotaDraw);
            }
            else
            {
                string selection = "";
                //5 horses
                for (int i = 0; i <= 4; i++)
                {
                    UIDecoration.Dialog($"Insert horse name {i + 1}:");
                    selection = Console.ReadLine();
                    foreach (Team team in Data.Data.Teams.Where(x => x.Name == selection))
                    {
                        InputTeams.Add(team);
                    }

                    //insert cote
                    decimal cotaHorse = 0;
                    isPharsed = false;
                    while (!isPharsed)
                    {
                        isPharsed = UIDecoration.Question($"Insert Cota for { InputTeams[i].Name }:", "error! Parse nok!", out cotaHorse);
                    }
                    cote.Add(cotaHorse);
                }
            }
            InsertGameAdmin(admin);
        }
        public void ChangeHouseTreshhold()
        {
            decimal newTresh = 0;
            UIDecoration.Dialog($"Current House Trashhold: {Data.Data.House.Treshhold}");

            isPharsed = false;
            while (!isPharsed)
            {
                isPharsed = UIDecoration.Question("Insert new House Treshhold:", "Error! Parse error!", out newTresh);
            }
            Data.Data.House.Treshhold = newTresh;
        }

        public void ValidateGames()
        {
            string winnerTeam;
            List<Game> gameToValidate = Data.Data.ListGamesForBet();
            if (gameToValidate.Count == 0)
            {
                UIDecoration.Dialog("No games for validation");
                Console.ReadKey();
                //return menu
            }
            else
            {
               //showgames
                clearMenuOptions();
                foreach (Game game in gameToValidate)
                {                   
                    if (game.GameType == EnumType.GameType.HorseRace)
                    {
                        int index = 0;
                        while (index < game.Teams.Count)
                        {
                            menu.Add($"{game.GameType} : {game.Teams[index].Name} {game.Cote[index].ToString()}");
                            index++;
                        }
                    }
                    else
                    {
                        menu.Add($"{game.GameType} : {game.Teams[0].Name} VS. {game.Teams[1].Name} with Odds: {game.Cote[0].ToString()} x  {game.Cote[1].ToString()} x Draw:  {game.Cote[2].ToString()}");
                    }
                }
                UIDecoration.Dialog("Select Game to set Winner!");
                while (!isPharsed)
                {
                    isPharsed = UIDecoration.Menu(menu, "Wrong value", 1, gameToValidate.Count + 1, out menuSelection);
                }
                UIDecoration.Dialog("Set winner team/horse:");

                winnerTeam = Console.ReadLine();


                Data.Data.Games[menuSelection - 1].Winner = Data.Data.Teams.Where(x => x.Name.ToLower() == winnerTeam.ToLower()).FirstOrDefault();
                Data.Data.Games[menuSelection - 1].isFinish = true;
                Data.Data.Games[menuSelection - 1].isValidated = true;
                ValidateBets(Data.Data.Games[menuSelection - 1]);
                
            }
        }

        private void ValidateBets(Game finishedGame)
        {
            Guid idCustomer;
            foreach (Bet validBet in Data.Data.Bets.Where(x => x.IsValidated == false && x.Game.Id == finishedGame.Id))
            {
                idCustomer = validBet.CustomerId;
                if (validBet.Team == finishedGame.Winner)
                {
                    Data.Data.Customers.Where(x => x.Id == idCustomer).FirstOrDefault().Balance += validBet.PotentialOutcome;
                    Data.Data.House.Balance -= validBet.PotentialOutcome;
                    validBet.IsValidated = true;
                }
                else
                {
                    Data.Data.House.Balance -= validBet.PotentialOutcome;
                    validBet.IsValidated = true;
                }
            }
        }
        private void RecalculateHouseBalance()
        {
            //Data.Data.House.Balance = Data.Data.Bets.Where(x => x.IsValidated)
        }
    }
}
