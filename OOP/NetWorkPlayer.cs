using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class NetWorkPlayer : IPlayer
    {
        private string ipAddress;
        private char symbol { get; }
        private bool host;
        private bool myTurn;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        public NetWorkPlayer(bool host) 
        {
            if(host)
            {
                symbol = 'X';
                myTurn = true;
                //not my code

                Console.WriteLine("Введите порт");

                int port = int.Parse(Console.ReadLine());
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Waiting for connection...");
                client = listener.AcceptTcpClient();
                Console.WriteLine("Player connected!");
            }
            else
            {
                symbol = 'O';
                myTurn = false;

                Console.WriteLine("Введите порт");
                int port = int.Parse(Console.ReadLine());
                client = new TcpClient();
                Console.Write("Enter host IP: ");
                string ip = Console.ReadLine();
                client.Connect(IPAddress.Parse(ip), port);
                Console.WriteLine("Connected to host!");
            }

            var stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };

        }
        public int Move(char[] field, bool side)
        {
            int move;

            if (myTurn)
            {
                // ход локального игрока
                Console.WriteLine($"Your turn ({symbol}). Enter cell number:");
                while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || field[move - 1] == 'X' || field[move - 1] == 'O')
                {
                    Console.WriteLine("Invalid move. Try again:");
                }

                move -= 1; // индекс массива
                           // отправляем ход противнику
                writer.WriteLine(move);

                myTurn = false; // очередь противника
            }
            else
            {
                Console.WriteLine("Waiting for opponent move...");
                string data = reader.ReadLine();
                move = int.Parse(data);
                myTurn = true; // теперь твоя очередь
            }

            return move;
        }
    }
}
