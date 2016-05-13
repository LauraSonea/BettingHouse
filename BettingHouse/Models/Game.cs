using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BettingHouse.Models.EnumType;

namespace BettingHouse.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public GameType GameType { get; set; }
        public List<Team> Teams { get; set; }
        public Team Winner { get; set; }
        public List<decimal> Cote { get; set; }        
        public DateTime PlayDate { get; set; }

        
    }

}
