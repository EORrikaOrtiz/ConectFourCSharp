using System;

namespace ConectFour
{
    using System;

    abstract class Player
    {
        public abstract char Symbol { get; }
        public abstract string Name { get; }
    }

    class HumanPlayer : Player
    {
        private char symbol;
        private string name;

        public HumanPlayer(char symbol, string name)
        {
            this.symbol = symbol;
            this.name = name;
        }

        public override char Symbol => symbol;
        public override string Name => name;
    }

    class AIPlayer : Player
    {
        private char symbol;
        private string name;

        public AIPlayer(char symbol, string name)
        {
            this.symbol = symbol;
            this.name = name;
        }

        public override char Symbol => symbol;
        public override string Name => name;
    }

    class GameException : Exception
    {
        public GameException(string message) : base(message) { }
    }

    class ColumnFullException : GameException
    {
        public ColumnFullException() : base("This column is full. Choose another column.") { }
    }

    class InvalidMoveException : GameException
    {
        public InvalidMoveException() : base("Invalid move. Try again.") { }
    }
    class ConnectFour
    {
        private char[,] board;
        private int rows = 6;
        private int columns = 7;
        private Player[] players;
        private int currentPlayerIndex;

        public ConnectFour(Player player1, Player player2)
        {
            board = new char[rows, columns];
            players = new Player[] { player1, player2 };
            currentPlayerIndex = 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mahbub, for this activity I will work alone, sincerely Erika Ortiz ID 456980, and by the way this only one advance about my code statement");
        }
    }
}