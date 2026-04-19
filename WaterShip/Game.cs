using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WaterShip
{
    internal class Game
    {
        Player player;
        bool myTurn;
        private NetworkManager NetworkManager = null;
        bool isGameOver = false;
        int myTotalhits = 0;
        int enemyTotalHits = 0;
        int hitsToWin = 20;



        public Game(Player player, bool isHost)
        {
            this.player = player;
            this.myTurn = isHost;
            NetworkManager = new NetworkManager(isHost);
        }





        public void StartGame()
        {
            while (myTotalhits < hitsToWin && enemyTotalHits < hitsToWin)
            {
                Console.Clear();
                Console.WriteLine("\nМое поле\n");
                player.printField();

                Console.WriteLine("\nПоле врага\n");
                player.printEnemyField();

                if (myTurn)
                {
                    Console.WriteLine("\nВведите координаты в формате (A5):");
                    string coordinates = Console.ReadLine().ToUpper();


                    int x = coordinates[0] - 'A';
                    int y = int.Parse(coordinates.Substring(1)) - 1;


                    if (NetworkManager.SendShot(x, y))
                    {
                        Console.WriteLine($"\nПопал - мой ход следующий");

                        player.MarkShotOnEnemyField(x, y, true);
                    }
                    else
                    {
                        Console.WriteLine($"\nПромах - следующий ход противника");
                        player.MarkShotOnEnemyField(x, y, false);
                        myTurn = false;
                    }



                }
                else
                {
                    // Wait for the enemy's turn
                    int x, y;
                    var move = NetworkManager.ReceiveShot();
                    Console.WriteLine($"\nПолучил ход");

                    x = move.x;
                    y = move.y;

                    bool isHit = player.DidEnemyHitMyShip(x, y);
                    if (!isHit)
                    {
                        Console.WriteLine($"\nПротивник промахнулся, мой ход");
                        player.MarkShotOnMyField(x, y, false);
                        myTurn = true;
                    }
                    else
                    {
                        Console.WriteLine($"\nПротивник попал, его ход следующий");
                        player.MarkShotOnMyField(x, y, true);
                    }

                    NetworkManager.sentResult(isHit);
                }
            }

            if (myTotalhits >= hitsToWin)
            {
                Console.WriteLine("\nВы выиграли!");
            }
            else
            {
                Console.WriteLine("\nВы проиграли");
            }

        }
    }
}
