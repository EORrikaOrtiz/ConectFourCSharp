﻿

using System;
using System.Data.Common;

namespace ConectFour
{
    abstract class Player
    {
        public abstract char Symbol { get; set; }
        public abstract string playerName { get; set; }
    }

    class HumanPlayer : Player
    {
        public override char Symbol { get; set; }
        public override string playerName { get; set; }

        public HumanPlayer(char symbol, string name)
        {
            Symbol = symbol;
            playerName = name;
        }
    } 

    class GameException : Exception
    {
        public GameException(string message) : base(message) { }
    }

    class ColumnFullException : GameException
    {
        public ColumnFullException() : base("\nThis column is full! Please choose another column...") { }
    }

    class InvalidMoveException : GameException
    {
        public InvalidMoveException() : base("\nInvalid move! Try again...") { }
    }
    class ConnectFour
    {

        private int rows = 6;
        private int columns = 7;
        private char[,] board;
        private Player[] players;
        private int currentPlayerIndex;
        public string Name;

        public ConnectFour(Player player1, Player player2)
        {

            board = new char[rows, columns];
            players = new Player[] { player1, player2 };
            currentPlayerIndex = 0;
            Name = player1.playerName;
            Name = player2.playerName;
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
        }
        
      
        private int GetMove()
        {
            int column;
            while (true)
            {
                Console.WriteLine("\nChoose a column from 1 to 7 :\n ");
                if (int.TryParse(Console.ReadLine(), out column) && column >= 1 && column <= 7)
                {
                    break;
                }

                Console.WriteLine("\nInvalid input! Please enter a column number between 1 and 7...");
            }
            return column - 1;
        }


        private bool CheckWin(char symbol)
        {
            for (int row = 0; row < rows; row++)//horizontal
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

            for (int column = 0; column < columns; column++)//vertical
            {
                for (int row = 0; row <= rows - 4; row++)
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

            for (int row = 0; row <= rows - 4; row++)// diagonal down
            {
                for (int column = 0; column <= columns - 4; column++)
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

            for (int row = 3; row < rows; row++) // diagonal up 
            {
                for (int column = 0; column <= columns - 4; column++)
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


        private void PrintBoard(string Name)
        {

            Console.WriteLine();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    char cell = board[row, column] == '\0' ? ' ' : board[row, column];
                    Console.Write($"|_|{cell}");
                }
                
                Console.WriteLine("|");
            }
           
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   1   2   3   4   5   6   7  ");
            Console.WriteLine("");
        }

        public void PlayGame()
        {
            bool gameWon = false;   
            bool gameEnded = false;
            int turnCount = 0;
            int totalMoves = 0;
            string Name;
            

            while (!gameWon)
            { 

                Player currentPlayer = players[currentPlayerIndex];
                PrintBoard(currentPlayer.playerName);
                Console.WriteLine($"\n{currentPlayer.playerName}'s turn, your symbol is: {currentPlayer.Symbol}");
                int column = GetMove();

                try
                {
                    MakeMove(column, currentPlayer.Symbol);
                    totalMoves++;

                    if (CheckWin(currentPlayer.Symbol))
                    {
                        PrintBoard(currentPlayer.playerName);
                        Console.WriteLine($"\n{currentPlayer.playerName} you are the winner :) !");
                        gameWon = true;
                    }

                    if (totalMoves == 42) // Total number of cells in a 6x7 board
                        {
                            PrintBoard(currentPlayer.playerName);
                            Console.WriteLine("It's a draw! no one wins...");
                            return;
                        }
                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
                }
                catch (GameException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        static bool PrompRestart(string message)
        {
           Console.WriteLine(message);
            string input = Console.ReadLine().Trim().ToLower();

            return input == "yes"; //|| input == "no";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nFinal Project Conect Four by Erika Ortiz\n\nWelcome to the game!\n");
            do 
            {
                Console.WriteLine("Please enter your name:\n");
                string playerName1 = Console.ReadLine();

                Player player1 = new HumanPlayer('X', playerName1);
                Console.WriteLine($"\n{playerName1} you are player 1...\n");

                Console.Write("Please enter your name:\n");
                string playerName2 = Console.ReadLine();

                Player player2 = new HumanPlayer('O', playerName2);
                Console.WriteLine($"\n{playerName2} you are player 2...\n");

                ConnectFour game = new ConnectFour(player1, player2);
                game.PlayGame(); 

            } while (PrompRestart("Do you want to play again? (yes/no): "));
            

            Console.Write("\nThank you for playing Connect Four! Press any key to exit...");
            Console.ReadKey();
        }
    }
}