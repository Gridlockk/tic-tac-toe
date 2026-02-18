using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class HumanVsHuman :IGame
    {
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

                }
                else
                {
                    Program.WriteToConsole("Player 2, choose your move (column and row): ");
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
                        Program.WriteToConsole("Its colum and row busy");
                        i--;
                    }
                }
                else
                {
                    Program.WriteToConsole("Invalid move. Try again.");
                    i--;
                }
                Console.Clear();
            }
            Program.WriteToConsole("Game End!");


        }
    }
}
