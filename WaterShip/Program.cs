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
            Console.WriteLine("My Field: ~ Sea | ■ Ship | X Your ship was hit | • Enemy missed\nEnemy Field: ~ Unknown | • Miss | X Hit");


            Console.WriteLine("Choise game Mode: 1 Host server \n 2 Join server");
            int choise = int.Parse(Console.ReadLine());


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
            }

            game.StartGame();






        }
    }
}