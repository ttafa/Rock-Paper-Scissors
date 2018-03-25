using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissorsGame.Models.GameAction;

namespace RockPaperScissorsGame.Models
{
    public class Game
    {       
        public Guid GameId { get; set; }
        public Player Winner { get; set; }
        public List<Player> Players { get; set; }        
            
    }
}
