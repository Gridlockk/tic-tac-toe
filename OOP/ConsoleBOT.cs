using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class ConsoleBot : IPlayer
    {
        public int Move(char[] field, bool side)
        {
            return RandomMove(FindMoves(field), field, side);
        }


        public int RandomMove(List<int> TrueCoords, char[] field, bool side)
        {


            Random rnd = new Random();
            int index = rnd.Next(TrueCoords.Count);

           if (side)
            {
                field[TrueCoords[index]] = 'X';

            }
            else 
            {
                field[TrueCoords[index]] = 'O';

            }
            return index;

        }

        public List<int> FindMoves(char[] field)
        {
            List<int> TrueCoords = new();

        

                for (int i = 0; i < field.Length; i++)
                {

                    if (field[i] != 'X' || field[i] != 'O')
                    {
                        TrueCoords.Add(i);
                    }

                }

            
            return TrueCoords;
        }

       
    }
}
