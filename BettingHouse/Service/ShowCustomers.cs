using System;
using System.Collections.Generic;
using BettingHouse.Models;
using BettingHouse.Views;
using BettingHouse.Helpers;
using System.Linq;
using BettingHouse.Service;


namespace BettingHouse.Service
{
    public class ShowCustomers : MenuHelper
    {
        public Customer SelectedCustomer;
        public void ShowCustomersList()
        {
            // Customer selectedCustomer;

            clearMenuOptions();
            UIDecoration.Title("Select your CustomerName:");

            foreach (Customer customer in Data.Data.Customers)
            {
                menu.Add(customer.Name);
            }
            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a customer with that index", 1, Data.Data.Customers.Count + 1, out menuSelection);

            SelectedCustomer = Data.Data.Customers[menuSelection - 1];

            if (!SelectedCustomer.IsAdmin)
            {
                ShowCustomerMenu(SelectedCustomer);
            }
            else
            {
                ShowAdminMenu(SelectedCustomer);
            }
        }

        private void ShowCustomerMenu(Customer clientLogged)
        {
            clearMenuOptions();
            UIDecoration.Title($"Hello {clientLogged.Name}. Please select one option");

            menu.Add("Available Games");
            menu.Add("Your History Bets");
            menu.Add("Back to Customer Lists");

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a option with that index", 1, 3, out menuSelection);

            switch (menuSelection)
            {
                case 1:
                    ShowAvailableGames(clientLogged);
                    break;
                case 2:
                    //ShowCustomerHistoryBets();
                    break;
                case 3:
                    ShowCustomersList();
                    break;
            }
        }

        public void ShowAvailableGames(Customer clientLogged)
        {
            ClientService clientService = new ClientService();
            string gameType = "";
            string gameTeamsString = "";
            string gameCotaString = "";
            clearMenuOptions();

            foreach (Game game in Data.Data.Games)
            {
                gameType = game.GameType.ToString();
                foreach (Team team in game.Teams)
                {
                    gameTeamsString += team.Name + '-';
                }
                foreach (decimal cota in game.Cote)
                {
                    gameCotaString += cota + "/";
                }
                menu.Add($"GameType: {gameType} Players: {gameTeamsString} Cote: {gameCotaString}");
            }

            if (clientLogged.IsAdmin)
            {
                UIDecoration.List(menu);
                ShowAdminMenu(clientLogged);
            }
            else
            {
                while (!isPharsed)
                {
                    UIDecoration.Dialog("Select a game to place your bet on");
                    isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a option with that index", 1, Data.Data.Games.Count + 1, out menuSelection);
                }
                clientService.ShowPlaceBetInterface(menuSelection, clientLogged);
            }
        }
        private void ShowAdminMenu(Customer admin)
        {
            AdminService adminService = new AdminService();
            clearMenuOptions();
            UIDecoration.Title($"Hello {admin.Name}. Please select one option");

            menu.Add("Insert Games");
            menu.Add("List All Customers Bets");
            menu.Add("Change the House Trashhold");
            menu.Add("Validate game result");
            menu.Add("Back to Customer Lists");

            while (!isPharsed)
                isPharsed = UIDecoration.Menu(menu, "Sorry you don't have a option with that index", 1, 4, out menuSelection);

            switch (menuSelection)
            {
                case 1:
                    adminService.ShowInsertGameInterface(admin);
                    break;
                case 2:
                    adminService.ShowAllBets();
                    break;
                case 3:
                    adminService.ChangeHouseTreshhold();
                    break;
                case 4:
                    adminService.ValidateGames();
                    break;
                case 5:
                    ShowCustomersList();
                    break;
            }
        }

    }
}