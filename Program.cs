﻿using System;

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
        public void PlayGame()
        {
            bool gameWon = false;
            while (!gameWon)
            {
                PrintBoard();
                Player currentPlayer = players[currentPlayerIndex];
                Console.WriteLine($"{currentPlayer.Name}'s turn (Symbol: {currentPlayer.Symbol})");
                int column = GetMove();
                try
                {
                    MakeMove(column, currentPlayer.Symbol);
                    if (CheckWin(currentPlayer.Symbol))
                    {
                        PrintBoard();
                        Console.WriteLine($"{currentPlayer.Name} wins!");
                        gameWon = true;
                    }
                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
                }
                catch (GameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void MakeMove(int column, char symbol)
        {
            if (column < 0 || column >= columns)
            {
                throw new InvalidMoveException();
            }

            for (int row = rows - 1; row >= 0; row--)
            {
                if (board[row, column] == '\0')
                {
                    board[row, column] = symbol;
                    return;
                }
            }

            throw new ColumnFullException();


            static void Main(string[] args)
        {
            Console.WriteLine("Hello Mahbub, for this activity I will work alone, sincerely Erika Ortiz ID 456980, and by the way this only one advance about my code statement");
        }
    }
}