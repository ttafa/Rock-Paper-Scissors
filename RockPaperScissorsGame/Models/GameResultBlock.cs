using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissorsGame.Models.GameAction;

namespace RockPaperScissorsGame.Models
{
    public class GameResultBlock
    {    
        public int NumberOfPlays { get; set; }
        public Player Winner { get; set; }

        public List<Game> GamesPlayed { get; set; }

        public  PlayerAction MostUsedMove { get; set; }
    }
}
