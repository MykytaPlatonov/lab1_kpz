namespace TicTacToe.Core
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char Marker { get; set; }

        protected Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
        }

        public abstract void MakeMove(Board board);
    }
}
