using System;

namespace TicTacToe.Core
{
    public class ComputerPlayer : Player
    {
        private static Random _random = new Random();

        public ComputerPlayer(string name, char marker) : base(name, marker) { }

        public override void MakeMove(Board board)
        {
            int x = 0, y = 0; 
            bool validMove = false;

            while (!validMove)
            {
                x = _random.Next(0, 3);
                y = _random.Next(0, 3);

                if (board[x, y] == '\0')
                {
                    board.PlaceMarker(Marker, x, y);
                    validMove = true;
                }
            }

            Console.WriteLine($"{Name} placed {Marker} at ({x}, {y})");
        }
    }
}
