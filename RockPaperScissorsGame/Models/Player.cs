using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RockPaperScissorsGame.Models.GameAction;

namespace RockPaperScissorsGame.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerAction PlayerAction { get; set; }
        
    }
}
