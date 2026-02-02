using System;
using TicTacToe.Core;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[ MISTERIOUS GAME ]");

            bool playAgain = true;

            while (playAgain)
            {
                var player1 = PlayerFactory.CreatePlayer("Human", "Mykyta", 'X');
                var player2 = PlayerFactory.CreatePlayer("Computer", "Computer", 'O');

                var gameManager = GameManager.Instance;
                gameManager.InitializeGame(player1, player2);

                var boardObserver = new ConsoleBoardObserver(gameManager.GameBoard);

                bool gameWon = false;

                while (true)
                {
                    gameManager.CurrentPlayer.MakeMove(gameManager.GameBoard);
                    if (gameManager.GameBoard.CheckForWin(gameManager.CurrentPlayer.Marker))
                    {
                        Console.WriteLine($"{gameManager.CurrentPlayer.Name} wins!");
                        gameWon = true;
                        break;
                    }
                    else if (gameManager.GameBoard.IsFull())
                    {
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                    gameManager.SwitchPlayer();
                }

                if (gameWon || gameManager.GameBoard.IsFull())
                {
                    Console.WriteLine("Game over!");
                }

                Console.WriteLine("Do you want to play again? (y/n): ");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    playAgain = false;
                }

                gameManager.ResetGame();
            }
        }
    }
}
