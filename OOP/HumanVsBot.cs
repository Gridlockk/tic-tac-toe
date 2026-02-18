using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class HumanVsBot: IGame
    {
        public void RandomMove(List<(int colum, int row)> TrueCoords)
        {


                Random rnd = new Random();
                int index = rnd.Next(TrueCoords.Count);

                Console.WriteLine($"rowS = {TrueCoords[index].row}, colS = {TrueCoords[index].colum}");
                arr[TrueCoords[index].colum, TrueCoords[index].row] = 'X';


        }

        public List<(int colum, int row)> FindMoves()
        {
            List<(int colum, int row)> TrueCoords = new();

            for (int i = 0; i < arr.GetLength(0); i++)
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

        public void RandomMoves()
        {
            List<(int colum, int row)> Cords = new (FindMoves());  
        }

        public override void play()
        {
            bool ifwin = false;
            int colum = 0;
            int row = 0;

            for (int i = 0; ifwin == false; i++)
            {
                WriteField(arr);



                if (i % 2 == 0)
                {
                    Program.WriteToConsole("Player 1, choose your move (column and row): ");
                    colum = Int32.Parse(Console.ReadLine()) - 1;
                    row = Int32.Parse(Console.ReadLine()) - 1;




                    if (colum >= 0 && colum <= 3 && row >= 0 && row <= 3)
                    {
                        if (arr[colum, row] == '.')
                        {
                          
                             arr[colum, row] = 'O';
                             ifwin = CheckToWin(arr);

                            

                        }
                        else
                        {
                            Program.WriteToConsole("Its colum and row busy");
                            i--;
                        }
                    }
                    else
                    {
                        Program.WriteToConsole("Invalid move. Try again.");
                        i--;
                    }
                }
                else
                {

                    Program.WriteToConsole("Bot Move... ");
                    RandomMove(FindMoves());
                    ifwin = CheckToWin(arr);
                }


            }
            Program.WriteToConsole("Game End!");
            WriteField(arr);

        }
    }
}
