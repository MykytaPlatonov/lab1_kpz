using System;

namespace TicTacToe.Core
{
    public class ConsoleBoardObserver : IObserver
    {
        private Board _board;

        public ConsoleBoardObserver(Board board)
        {
            _board = board;
            _board.RegisterObserver(this);
        }

        public void Update()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j] == '\0' ? '.' : _board[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
