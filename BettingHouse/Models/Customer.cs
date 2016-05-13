using System;
using System.Collections.Generic;

namespace BettingHouse.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdmin { get; set; }
        public List<Bet> BetHistory { get; set; }
    }
}
