using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace Tic_tac
{
    internal class Program
    {
        static void WriteField(char[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                WriteToConsole("");
            }
            WriteToConsole("\n");
            return;
        }

        static void WriteToConsole(string text)
        {

            Console.WriteLine(text);

        }

        static bool CheckToWin(char[,] arr)
        {
            // horizontal check
            for (int i = 0; i < 3; i++)
            {
                if (arr[i, 0] != '.' && arr[i, 0] == arr[i, 1] && arr[i, 1] == arr[i, 2])
                    return true;
            }

            // vertical check
            for (int j = 0; j < 3; j++)
            {
                if (arr[0, j] != '.' && arr[0, j] == arr[1, j] && arr[1, j] == arr[2, j])
                    return true;
            }

            // diagonal check
            if (arr[0, 0] != '.' && arr[0, 0] == arr[1, 1] && arr[1, 1] == arr[2, 2])
                return true;

            // mirror diagonal chck
            if (arr[0, 2] != '.' && arr[0, 2] == arr[1, 1] && arr[1, 1] == arr[2, 0])
                return true;

            return false;
        }


        static List<(int colum, int row) > FindMoves(char[,] arr)
        {
            List <(int colum, int row)> TrueCoords = new();

            for (int i = 0; i < arr.GetLength(0) ; i++)
            {
                for (int t = 0; t < arr.GetLength(1); t++)
                {
                    if (arr[i, t] == '.')
                    {
                        TrueCoords.Add((i, t));
                    }
                }
            }
            return TrueCoords;
        }
        static void PlayWithBot(char[,] arr)
        {
            bool ifwin = false;
            int colum = 0;
            int row = 0;



            for (int i = 0; ifwin == false; i++)
            {
                WriteField(arr);
                
                //test
                WriteToConsole("Choice Hard Mode 1 - easy 2 - normal");

                if (i % 2 == 0)
                {
                    WriteToConsole("Player 1, choose your move (column and row): ");
                    colum = Int32.Parse(Console.ReadLine()) - 1;
                    row = Int32.Parse(Console.ReadLine()) - 1;


                    if (colum >= 0 && colum <= 3 && row >= 0 && row <= 3)
                    {
                        if (arr[colum, row] == '.')
                        {

                            
                                arr[colum, row] = 'X';
                                ifwin = CheckToWin(arr);
                            

                        }
                        else
                        {
                            WriteToConsole("Its colum and row busy");
                            i--;
                        }
                    }
                    else
                    {
                        WriteToConsole("Invalid move. Try again.");
                        i--;
                    }

                }
                else
                {
                    //bot ходит
                    BotMove(FindMoves(arr), arr);

                }


               
            }
            WriteToConsole("Game End!");
        }
        static void PlayWithPlayer(char[,] arr)
        {
            bool ifwin = false;
            int colum = 0;
            int row = 0;

            for (int i = 0; ifwin == false; i++)
            {
                WriteField(arr);



                if (i % 2 == 0)
                {
                    WriteToConsole("Player 1, choose your move (column and row): ");
                    colum = Int32.Parse(Console.ReadLine()) - 1;
                    row = Int32.Parse(Console.ReadLine()) - 1;

                }
                else
                {
                    WriteToConsole("Player 2, choose your move (column and row): ");
                    colum = Int32.Parse(Console.ReadLine()) - 1;
                    row = Int32.Parse(Console.ReadLine()) - 1;

                }


                if (colum >= 0 && colum <= 3 && row >= 0 && row <= 3)
                {
                    if (arr[colum, row] == '.')
                    {
                        if (i % 2 == 0)
                        {
                            arr[colum, row] = 'X';
                            ifwin = CheckToWin(arr);
                        }
                        else
                        {
                            arr[colum, row] = 'O';
                            ifwin = CheckToWin(arr);
                        }
                    }
                    else
                    {
                        WriteToConsole("Its colum and row busy");
                        i--;
                    }
                }
                else
                {
                    WriteToConsole("Invalid move. Try again.");
                    i--;
                }
            }
            WriteToConsole("Game End!");

        
        }


        static void BotMove(List<(int colum, int row)> TrueCoords, char[,] arr)
        {
            foreach (var move in TrueCoords)
            {
                Console.WriteLine($"row = {move.row}, col = {move.colum}");

                Random rnd = new Random();
                int index = rnd.Next(TrueCoords.Count);

                Console.WriteLine($"rowS = {TrueCoords[index].row}, colS = {TrueCoords[index].colum}");

            }
        }
        static void Main(string[] args)
        {
            char[,] arr =
             {
                    { '.', '.', '.' },
                    { '.', '.', '.' },
                    { '.', '.', '.' }
             };
         
            



            WriteToConsole("Play With player 2 = 1 or With bot = 2");

            int choice = 0;
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    PlayWithPlayer(arr);
                    break;
                case 2:
                    PlayWithBot(arr);
                    break;
                default:
                    Console.WriteLine("unknown choice");
                    break;
            }



        }
    }
}
