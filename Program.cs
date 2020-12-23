using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
namespace Connent_Four
{
    class Program
    {
        static void Help()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.WriteLine("Connect Four Game");
            Console.WriteLine("");
            Console.WriteLine("-Both players must take");
            Console.WriteLine(" turns to put one of");
            Console.WriteLine(" their ownchess pieces");
            Console.WriteLine(" into the opening, so");
            Console.WriteLine(" that the pieces fall on");
            Console.WriteLine(" the bottom or other pieces");
            Console.WriteLine(" due to gravity");
            Console.WriteLine("");
            Console.WriteLine("-Win when your 4 chess pieces");
            Console.WriteLine(" are connected in a vertical,");
            Console.WriteLine(" horizontal and diagonal");
            Console.WriteLine(" direction");
            Console.WriteLine("");
            Console.WriteLine("-When the board is full, if");
            Console.WriteLine(" there is no 4 pieces in a");
            Console.WriteLine(" row, it will be a tie");
            Console.WriteLine("");
            Console.WriteLine("-Enter the number of the row");
            Console.WriteLine(" in order to place the piece");
            Console.WriteLine("****************************");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Info()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("****************************");
            Console.WriteLine("Programmed in C#");
            Console.WriteLine("281 lines of code");
            Console.WriteLine("100% by Kimi Lao");
            Console.WriteLine("Published in 2020/12/13");
            Console.WriteLine("****************************");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    switch (board[i, j])
                    {
                        case 0:
                            Console.Write("- ");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("o ");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("o ");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("1 2 3 4 5 6 7");
        }
        private static int CheckWin(int[,] board, int turn)//
        {
            int end = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == board[i, j+1] && board[i, j + 1] == board[i, j + 2] && board[i, j + 2] == board[i, j + 3] && board[i, j] != 0)
                    {
                        end = turn;
                        break;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == board[i + 1, j] && board[i + 1, j] == board[i + 2, j] && board[i + 2, j] == board[i + 3, j] && board[i, j] != 0)
                    {
                        end = turn;
                        break;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == board[i + 1, j + 1] && board[i + 1, j + 1] == board[i + 2, j + 2] && board[i + 2, j + 2] == board[i + 3, j + 3] && board[i, j] != 0)
                    {
                        end = turn;
                        break;
                    }
                }
            }
            for (int i = 5; i > 3; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] == board[i - 1, j + 1] && board[i - 1, j + 1] == board[i - 2, j + 2] && board[i - 2, j + 2] == board[i - 3, j + 3] && board[i, j] != 0)
                    {
                        end = turn;
                        break;
                    }
                }
            }
            if (end == 1)//red win
            {
                return 1;
            }
            if (end == 2)//blue win
            {
                return 2;
            }
            int space = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == 0)
                    {
                        space++;
                    }
                }
            }
            if (space == 0)
            {
                end = 3;
            }
            if (end == 3)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        static void Play(int[,] board)
        {
            Console.WriteLine("");
            Console.WriteLine("Red First!");
            Console.WriteLine("");
            PrintBoard(board);
            Console.WriteLine("");
            int turn = 1;
            while (true)
            {
                Console.WriteLine("");
                if (turn == 1)
                {
                    Console.Write("Red, your move: ");
                }
                else
                {
                    Console.Write("Blue, your move: ");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")
                {
                    int rowSpace = 6;
                    for (int i = 5; i > -1; i--)
                    {
                        if (board[i, Convert.ToInt32(input) - 1] == 0)
                        {
                            board[i, Convert.ToInt32(input) - 1] = turn;
                            break;
                        }
                        else
                        {
                            rowSpace--;
                        }
                    }
                    if (rowSpace == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Row is full.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        PrintBoard(board);
                        if (CheckWin(board, turn) == 1)
                        {
                            Console.WriteLine("Red WON!");
                            Console.WriteLine("");
                            break;
                        }
                        if (CheckWin(board, turn) == 2)
                        {
                            Console.WriteLine("Blue WON!");
                            Console.WriteLine("");
                            break;
                        }
                        if (CheckWin(board, turn) == 3)
                        {
                            Console.WriteLine("TIE");
                            Console.WriteLine("");
                            break;
                        }
                        if (turn == 1)
                        {
                            turn = 2;
                        }
                        else
                        {
                            turn = 1;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*******Connect Four Game*******");
            Console.WriteLine("-Enter \"play\" to play");
            Console.WriteLine("-Enter \"help\" for help");
            Console.WriteLine("-Enter \"info\" for more info");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                int[,] board = {
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0 }
                };
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (input == "help")
                {
                    Help();
                }
                if (input == "info")
                {
                    Info();
                } 
                if (input == "play")
                {
                    Play(board);
                }
            }
        }
   }
}
