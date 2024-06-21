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

         private bool CheckWin(char symbol)
 {
     for (int row = 0; row < rows; row++)
     {
         for (int column = 0; column <= columns - 4; column++)
         {
             if (board[row, column] == symbol &&
                 board[row, column + 1] == symbol &&
                 board[row, column + 2] == symbol &&
                 board[row, column + 3] == symbol)
             {
                 return true;
             }
         }

     }

     for (int row = 0; row < rows - 4; row++)
     {
         for (int column = 0; column < columns; column++)
         {
             if (board[row, column] == symbol &&
                 board[row + 1, column] == symbol &&
                 board[row + 2, column] == symbol &&
                 board[row + 3, column] == symbol)
             {
                 return true;
             }
         }

     }

     for (int row = 0; row <= rows - 4; row++)
     {
         for (int column = 0; column <= column - 4; column++)
         {
             if (board[row, column] == symbol &&
                 board[row + 1, column + 1] == symbol &&
                 board[row + 2, column + 2] == symbol &&
                 board[row + 3, column + 3] == symbol)
             {
                 return true;
             }
         }

     }

     for (int row = 3; row <rows; row++)
     {
         for (int column = 0; column <= column - 4; column++)
         {
             if (board[row, column] == symbol &&
                 board[row - 1, column + 1] == symbol &&
                 board[row - 2, column + 2] == symbol &&
                 board[row - 3, column + 3] == symbol)
             {
                 return true;
             }
         }

     }

     return false;

 }
    }
}