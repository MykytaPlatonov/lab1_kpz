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
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter column (0, 1, 2): ");
                y = int.Parse(Console.ReadLine());

                if (x >= 0 && x < 3 && y >= 0 && y < 3 && board[x, y] == '\0')
                {
                    board.PlaceMarker(Marker, x, y);
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }
    }
}
