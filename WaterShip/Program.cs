using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaterShip
{


    internal class Program
    {
        
        static void Main(string[] args)
        {
            while (true)

            {

                Console.WriteLine("=================================\n Опозначения символов: \n\n ~ пустая клетка \n ■ Корабль \n X поврежденная часть корабля \n - Враг выстрелил по этой клетке но там нет корабля\n =================================\n");


                Console.WriteLine("Выберите режим игры: \n 1 - Сервер(к тебе подключается оппонент) \n 2 - Присоединиться к игроку");
                int choise = int.Parse(Console.ReadLine());
                Console.Clear();

               Player player = new Player(10, '■');
                Game game = null;

                switch (choise)
                {
                    case 1:
                        game = new Game(player, true);
                        break;

                    case 2:
                        game = new Game(player, false);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1 или 2");
                        continue;
                }

                game.StartGame();

            }




        }
    }
}