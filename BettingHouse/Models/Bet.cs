using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BettingHouse.Models.EnumType;

namespace BettingHouse.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Game Game { get; set; }
        public Team Team { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateSubmited { get; set; }
        public DateTime DateDue { get; set; }
        public GameOutcome GameOutcome { get; set; }
        public bool IsWinner { get; set; }
        public decimal Cota { get; set; }
        public decimal PotentialOutcome { get; set; }
        public bool IsValidated { get; set; }
    }
  
}
