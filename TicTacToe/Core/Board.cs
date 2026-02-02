using System;
using System.Collections.Generic;

namespace TicTacToe.Core
{
    public class Board
    {
        private char[,] _board;
        private List<IObserver> _observers;

        public Board()
        {
            _board = new char[3, 3];
            _observers = new List<IObserver>();
        }

        public char this[int x, int y]
        {
            get { return _board[x, y]; }
            set { _board[x, y] = value; }
        }

        public bool PlaceMarker(char marker, int x, int y)
        {
            if (_board[x, y] == '\0')
            {
                _board[x, y] = marker;
                NotifyObservers();
                return true;
            }
            return false;
        }

        public bool CheckForWin(char marker)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == marker && _board[i, 1] == marker && _board[i, 2] == marker)
                    return true;

                if (_board[0, i] == marker && _board[1, i] == marker && _board[2, i] == marker)
                    return true;
            }

            if (_board[0, 0] == marker && _board[1, 1] == marker && _board[2, 2] == marker)
                return true;
            if (_board[0, 2] == marker && _board[1, 1] == marker && _board[2, 0] == marker)
                return true;

            return false;
        }

        public bool IsFull()
        {
            foreach (var spot in _board)
            {
                if (spot == '\0') return false;
            }
            return true;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
