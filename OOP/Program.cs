using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using GameHuman;

namespace Tik_tak_toe

{
    class TicTacToe
    {

        static void Main()
        {
            int mode;

            Console.WriteLine("Выбор режима[1/2]. 1. Игрок против игрока; 2. Игрок против бота");
            mode = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                GameHuman.GameHuman gameHuman = new GameHuman.GameHuman();
                gameHuman.Play();
            }
            else if (mode == 2)
            {
                GameBot.GameBot gameBot = new GameBot.GameBot();
                gameBot.Play();
            }
            else
            {
                Console.WriteLine("Не правильный выбор");
            }
            }
        }
    } 
