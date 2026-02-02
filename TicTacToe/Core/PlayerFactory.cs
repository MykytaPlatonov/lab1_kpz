using System;

namespace TicTacToe.Core
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(string type, string name, char marker)
        {
            if (type == "Human")
            {
                return new HumanPlayer(name, marker);
            }
            else if (type == "Computer")
            {
                return new ComputerPlayer(name, marker);
            }
            throw new ArgumentException("Invalid player type.");
        }
    }
}
