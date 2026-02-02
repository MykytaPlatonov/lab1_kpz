using System;

namespace TicTacToe.Core
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char marker) : base(name, marker) { }

        public override void MakeMove(Board board)
        {
            int x, y;
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine($"{Name}'s turn. Enter row (0, 1, 2): ");
                string inputX = Console.ReadLine();
                
                // Використання TryParse замість Parse (виправлення Issue #2)
                if (!int.TryParse(inputX, out x))
                {
                    Console.WriteLine("Invalid input. Please enter a number 0, 1, or 2.");
                    continue;
                }

                Console.WriteLine("Enter column (0, 1, 2): ");
                string inputY = Console.ReadLine();
                
                if (!int.TryParse(inputY, out y))
                {
                    Console.WriteLine("Invalid input. Please enter a number 0, 1, or 2.");
                    continue;
                }

                // Використання константи BoardSize замість магічного числа 3
                if (x >= 0 && x < Board.BoardSize && y >= 0 && y < Board.BoardSize && board[x, y] == '\0')
                {
                    board.PlaceMarker(Marker, x, y);
                    validMove = true;
                }
                else
                {
                    Console.WriteLine($"Invalid move. Cell ({x}, {y}) is occupied or out of bounds. Try again.");
                }
            }
        }
    }
}
