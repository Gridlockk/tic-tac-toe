using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WaterShip
{
    internal class NetworkManager
    {

        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;


        public NetworkManager(bool host)
        {

            Console.Write("Введите порт: ");
            int port = int.Parse(Console.ReadLine());


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
        public bool SendShot(int x, int y)
        {


            writer.WriteLine($"{x} {y}");
            bool isHit = bool.Parse(reader.ReadLine());
            if (isHit)
            {
                
                return true;

            }

            return false;
        }

        public (int x, int y) ReceiveShot()
        {

            string[] move = reader.ReadLine().Trim().Split(' ');

            int x = int.Parse(move[0]);
            int y = int.Parse(move[1]);

           

            return (x, y);
        }

        public void sentResult(bool isHit)
        {
            writer.WriteLine(isHit);
        }
    }
}
