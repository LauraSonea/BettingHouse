using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingHouse.Models
{
    public class BetHouse
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Treshhold { get; set; }
        public decimal MoneyAvailable{ get; set; }
        public decimal ValueOfActiveBets { get; set; }
    }
}
