using RockPaperScissorsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static RockPaperScissorsGame.Models.GameAction;

namespace RockPaperScissorsGame.Helper
{
    public class ExtensionHelper
    {
        private PlayerAction GenerateRandomAction()
        {
            var rnd = new Random();
            return (PlayerAction)rnd.Next(Enum.GetNames(typeof(PlayerAction)).Length);
        }


        private Player PlayMatch(Player player1, Player player2)
        {
            if (player1.PlayerAction == player2.PlayerAction)
                return null;
            else if
            (player1.PlayerAction == PlayerAction.Rock && player2.PlayerAction == PlayerAction.Scissors)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Paper && player2.PlayerAction == PlayerAction.Rock)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Scissors && player2.PlayerAction == PlayerAction.Paper)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Lizard && player2.PlayerAction == PlayerAction.Spock)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Spock && player2.PlayerAction == PlayerAction.Scissors)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Scissors && player2.PlayerAction == PlayerAction.Lizard)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Lizard && player2.PlayerAction == PlayerAction.Paper)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Paper && player2.PlayerAction == PlayerAction.Spock)
                return player1;
            else if
           (player1.PlayerAction == PlayerAction.Spock && player2.PlayerAction == PlayerAction.Rock)

                return player1;
            else


                return player2;
        }

        private GameResultBlock FormatResult(List<Game> trackedResults)
        {
            GameResultBlock result = new GameResultBlock();
            result.NumberOfPlays = trackedResults.Count();
            result.MostUsedMove = (from c in trackedResults.SelectMany(x => x.Players).Select(x => x.PlayerAction)
                                   group c by c into g
                                   orderby g.Count() descending
                                   select g.Key).FirstOrDefault();
            result.Winner = trackedResults.Max(x => x.Winner);
            var players = trackedResults.Select(x => x.Players);
            result.GamesPlayed = trackedResults;

            return result;
        }

        public GameResultBlock RunGame(Player player1, Player player2)
        {
            List<Game> tracker = new List<Game>();
            player1.PlayerAction = GenerateRandomAction();
            Thread.Sleep(10); //pausing random generation
            player2.PlayerAction = GenerateRandomAction();
            Player winner = PlayMatch(player1, player2);
            Game game = new Game()
            {
                GameId = Guid.NewGuid(),
                Winner = winner,
                Players = new List<Player>() { player1, player2 }
            };

            tracker.Add(game);

            if (winner != null) return FormatResult(tracker);

            //continue playing if a draw
            while (winner == null)
            {
                player1.PlayerAction = GenerateRandomAction();
                Thread.Sleep(10); //pausing random generation
                player2.PlayerAction = GenerateRandomAction();
                winner = PlayMatch(player1, player2);

                tracker.Add(new Game()
                {
                    GameId = Guid.NewGuid(),
                    Winner = winner,
                    Players = new List<Player>() { player1, player2 }
                });
            }

            return FormatResult(tracker);
        }

    }
}
