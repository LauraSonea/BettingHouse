using System;
using System.Collections.Generic;
using BettingHouse.Data;
using BettingHouse.Service;

namespace BettingHouse
{
    public class Program
    {
        static void Main(string[] args)
        {

            Data.Data.Seeding();

            Data.Data.WriteJson();
            Data.Data.WriteXML();

            Data.Data.LoadJson();
            Data.Data.LoadXML();
            Data.Data.WriteXML();

            ShowCustomers sc = new ShowCustomers();
            sc.ShowCustomersList();
            Data.Data.WriteJson();
            Data.Data.WriteXML();
        }

    }
}
