using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingHouse.Models
{
    public class EnumType
    {
        public enum GameType
        {
            Tenis = 1,
            PinPong = 2,
            HorseRace = 3
        }
        public enum GameOutcome
        {
            Win = 1,
            Lose = 0,
            Draw = 3
        }

       
    }
}
