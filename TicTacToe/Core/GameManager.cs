using System;

namespace TicTacToe.Core
{
    public class GameManager
    {
        // Приватне статичне поле для Singleton
        private static GameManager _instance;
        
        // Публічна властивість для доступу (опціонально можна зробити тільки метод)
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

        // Додано: Публічний метод для скидання інстансу (виправлення Issue #3)
        public static void ResetInstanceForTesting()
        {
            _instance = null;
        }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Board GameBoard { get; private set; }
        public Player CurrentPlayer { get; private set; }

        // Конструктор залишається приватним
        private GameManager()
        {
            GameBoard = new Board();
        }

        public void InitializeGame(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = Player1;
        }

        public void PlayTurn(int x, int y)
        {
            if (GameBoard.PlaceMarker(CurrentPlayer.Marker, x, y))
            {
                if (GameBoard.CheckForWin(CurrentPlayer.Marker))
                {
                    Console.WriteLine($"{CurrentPlayer.Name} wins!");
                }
                else if (GameBoard.IsFull())
                {
                    Console.WriteLine("It's a draw!");
                }
                else
                {
                    SwitchPlayer();
                }
            }
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public void ResetGame()
        {
            Console.Clear();
            GameBoard = new Board();
            CurrentPlayer = Player1;
        }
    }
}
