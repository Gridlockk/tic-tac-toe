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
    internal class NetWorkBot : IPlayer
    {

        private bool myTurn;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        public NetWorkBot(bool host)
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

                move = RandomMove(FindMoves(field), field, side);
                writer.WriteLine(move);

            }
            else
            {
                Console.WriteLine("Ожидание хода противника...");
                move = int.Parse(reader.ReadLine());
            }
            this.myTurn = !myTurn;
            return move;
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
