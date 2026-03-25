using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class NetWorkPlayer : IPlayer
    {

        private bool myTurn;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        public NetWorkPlayer(bool host) 
        {

            Console.Write("Введите порт: ");
            int port = int.Parse(Console.ReadLine());
            this.myTurn = host;
            if (host)
            {


                var listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Console.WriteLine("Ждём подключения...");
                client = listener.AcceptTcpClient();
                Console.WriteLine("Игрок подключился!");
            }
            else
            {
                Console.Write("Введите IP хоста: ");
                string ip = Console.ReadLine();
                client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);
                Console.WriteLine("Успешно подключились!");
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
                
                while (true)
                {
                    Console.Write("Ваш ход (1-9): ");
                    move = int.Parse(Console.ReadLine()) - 1;
                    if (move >= 0 && move <= 8 && field[move] != 'X' && field[move] != 'O')
                        break;
                    Console.WriteLine("Клетка занята или номер неверный, повторите.");
                }
                writer.WriteLine(move);
                
            }
            else
            {
                Console.WriteLine("Ожидание хода противника...");
                move =  int.Parse(reader.ReadLine());
            }
            this.myTurn = !myTurn;
            return move;
        }
    }
}
