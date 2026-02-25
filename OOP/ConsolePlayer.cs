using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class ConsolePlayer : IPlayer
    {
        public int Move(char[] field, bool side)
        {
            while (true) 
            {
                Console.WriteLine("Введите ход от 1 до 9!");
                int point = int.Parse(Console.ReadLine());
                if (1 <= point && point <= 9)
                {
                    if (field[point - 1] != 'X' && field[point - 1] != 'O')
                    {
                        return point - 1;
                    }
                    else 
                    {
                        Console.WriteLine("Поле уже занято!");

                    }

                }
                else
                {
                    Console.WriteLine("НЕправильный выбор!");

                }
            }


        }
    }
}
