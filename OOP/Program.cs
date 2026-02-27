namespace OOP
{

    internal class Program
    {
        public static void WriteToConsole(string text)
        {

            Console.WriteLine(text);

        }

        static void Main(string[] args)
        {

            WriteToConsole("Play With player = 1 \n Bot VS Bot = 2 \n Player VS Bot = 3  \n NetWorkGame HOST Game = 4 \n NetWorkGame Join Game = 5");

            int choice = 0;
            choice = Int32.Parse(Console.ReadLine());

            IPlayer playerX = null;
            IPlayer playerO = null;



            char[] field = "123456789".ToCharArray();


            switch (choice)
            {
                case 1:
                    playerX = new ConsolePlayer();
                    playerO = new ConsolePlayer();
                    break;
                case 2:

                    playerX = new ConsoleBot();
                    playerO = new ConsoleBot();
                    break;
                case 3:
                    playerX = new ConsolePlayer();
                    playerO = new ConsoleBot();
                    break;
                case 4:
                    playerX = new NetWorkPlayer(true);
                    playerO = new ConsolePlayer();
                    break;
                case 5:
                    playerX = new ConsolePlayer();
                    playerO = new NetWorkPlayer(false);
                    break;

                default:
                    WriteToConsole("unknown choice");
                    break;
            }
            while (true)
            {
                //Console.Clear();

                int turn = playerX.Move(field, true);
                field[turn] = 'X';
                WriteField(field);
                if (CheckToWin(field, 'X'))
                {
                    return;
                }
                turn = playerO.Move(field, false);
                field[turn] = 'O';
                WriteField(field);
                if (CheckToWin(field, 'O'))
                {
                    return;
                }
            }


        }

        private static void WriteField(char[] arr)
        {
            Program.WriteToConsole($"╔═╦═╦═╗\n║{arr[0]}║{arr[1]}║{arr[2]}║\n╠═╬═╬═╣\n║{arr[3]}║{arr[4]}║{arr[5]}║\n╠═╬═╬═╣\n║{arr[6]}║{arr[7]}║{arr[8]}║\n╚═╩═╩═╝");
            return;
        }

        private static bool CheckToWin(char[] arr, char choice)
        {
            // horizontal check
            for (int i = 0; i < 9; i+=3)
            {
                if ( arr[i] == choice && arr[i] == arr[i+1] && arr[i + 1] == arr[i+2])
                    return true;
            }

            // vertical check
            for (int j = 0; j < 3; j++)
            {
                if ( arr[j] == choice && arr[j] == arr[j+3] && arr[j+3] == arr[j+6])
                    return true;
            }

            // diagonal check
            if (choice == arr[0] && arr[0] == arr[4] && arr[4] == arr[8])
                return true;

            // mirror diagonal chck
            if (choice == arr[2] && arr[2] == arr[4] && arr[4] == arr[6])
                return true;

            return false;
        }
    }
}
