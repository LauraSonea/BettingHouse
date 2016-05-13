using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettingHouse.Models;
using static BettingHouse.Models.EnumType;

namespace BettingHouse.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GameType GameType { get; set; }
    }
}
