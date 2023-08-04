using System;

namespace TicTacToe
{
    public class Game
    {
        private char[,] board;
        private int size;
        public char player;
        public bool isGameOver;

        public Game(int n)
        {
            size = n;
            board = new char[size, size];
            player = 'X';
            isGameOver = false;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void PrintBoard()
        {
            var s = "";
            for (int i = 0; i < size; ++i)
            {
                s += "----";
            }
            Console.WriteLine(s);
            for (int i = 0; i < size; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j] + " | ");
                }
                Console.WriteLine("\n" + s);
            }
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool IsWin(int row, int col)
        {
            bool IsRowWin = true;
            for (int i = 0; i < size; i++)
            {
                if (board[row, i] != player)
                {
                    IsRowWin = false;
                    break;
                }
            }

            if (IsRowWin) return true;

            bool IsColWin = true;
            for (int i = 0; i < size; i++)
            {
                if (board[i, col] != player)
                {
                    IsColWin = false;
                    break;
                }
            }

            if (IsColWin) return true;

            if (row == col)
            {
                bool IsMainDiagonalWin = true;
                for (int i = 0; i < size; i++)
                {
                    if (board[i, i] != player)
                    {
                        IsMainDiagonalWin = false;
                        break;
                    }
                }
                if (IsMainDiagonalWin) return true;
            }

            if (row + col == size - 1)
            {
                bool IsSecondaryDiagonalWin = true;
                for (int i = 0; i < size; i++)
                {
                    if (board[i, size - 1 - i] != player)
                    {
                        IsSecondaryDiagonalWin = false;
                        break;
                    }
                }
                if (IsSecondaryDiagonalWin) return true;
            }

            return false;
        }


        public void Play(int row, int col)
        {
            if (!isGameOver && board[row, col] == ' ')
            {
                board[row, col] = player;

                if (IsWin(row, col))
                {
                    isGameOver = true;
                    Console.WriteLine($"Player {player} wins!");
                }
                else if (IsBoardFull())
                {
                    isGameOver = true;
                    Console.WriteLine("It's a draw!");
                }
                else
                {
                    player = (player == 'X') ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the size of the Tic Tac Toe game board: ");
            int size = Convert.ToInt32(Console.ReadLine());

            Game game = new Game(size);

            while (!game.isGameOver)
            {
                game.PrintBoard();
                Console.WriteLine($"Player {game.player}'s turn:");
                Console.Write("Enter row: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter column: ");
                int col = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                game.Play(row, col);
            }

            game.PrintBoard();
        }
    }
}
