using RockPaperScissorsGame.Helper;
using RockPaperScissorsGame.Models;
using System;
using System.IO;
using static RockPaperScissorsGame.Models.GameAction;

namespace RockPaperScissorsGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            ExtensionHelper _helper = new ExtensionHelper();
            Player player1 = new Player() { Id = 1, Name = "Fred", PlayerAction = new PlayerAction() };
            Player player2 = new Player() { Id = 2, Name = "John", PlayerAction = new PlayerAction() };
            Console.WriteLine("Starting game");
            Console.WriteLine("...");
            var gameResults = _helper.RunGame(player1, player2);

            Console.WriteLine(

                "Game played {0} times, Winner is {1}, most used move {2}",                 
                gameResults.NumberOfPlays,
                gameResults.Winner.Name,
                gameResults.MostUsedMove
                );

            StreamWriter log = new StreamWriter("RockPaperScissorsGame" + DateTime.Now.ToString("ddMMyyhhmmss") + ".txt");
            using (log)
            {
                
                foreach (var game in gameResults.GamesPlayed)
                {
                    log.WriteLine(game.GameId);
                    foreach (var player in game.Players)
                    {
                        log.WriteLine(player.Name + " : " + player.PlayerAction);
                    }
                    if(game.Winner == null)log.WriteLine("Winner is Draw");
                    else log.WriteLine("Winner is {0}",  game.Winner.Name);
                    log.WriteLine("");

                }

            }
            Console.ReadLine();
        }
       

    }
}
