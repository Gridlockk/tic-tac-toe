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

            WriteToConsole("Play With player = 1 \n Bot VS Bot = 2 \n Player VS Bot = 3  \n NetWorkGame HOST Game = 4 \n NetWorkGame Join Game = 5 \n NetWorkGame HOST Game(Bot) = 6 \n NetWorkGame Join Game(Bot) = 7");

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
                    WriteToConsole("First player — X, second player — O");
                    break;
                case 2:

                    playerX = new ConsoleBot();
                    playerO = new ConsoleBot();
                    break;
                case 3:
                    WriteToConsole("Choose your side: X = 1, O = 2");
                    int sideChoice = Int32.Parse(Console.ReadLine());

                    if (sideChoice == 2)
                    {
                        playerX = new ConsoleBot();
                        playerO = new ConsolePlayer();
                        WriteToConsole("You play as O (Bot goes first)");
                    }
                    else
                    {
                        playerX = new ConsolePlayer();
                        playerO = new ConsoleBot();
                        WriteToConsole("You play as X");
                    }
                    break;          

                case 4:
                    //isHost: true
                    NetWorkAdapter network4 = new NetWorkAdapter(true, new ConsolePlayer());
                    playerX = network4;
                    playerO = network4;
                    break;
                case 5:
                    NetWorkAdapter network5 = new NetWorkAdapter(false, new ConsolePlayer());
                    playerX = network5;
                    playerO = network5;
                    break;
                case 6:
                    NetWorkAdapter network6 = new NetWorkAdapter(true, new ConsoleBot());
                    playerX = network6;
                    playerO = network6;
                    break;
                case 7:
                    NetWorkAdapter network7 = new NetWorkAdapter(false, new ConsoleBot());
                    playerX = network7;
                    playerO = network7;
                    break;


                default:
                    WriteToConsole("unknown choice");
                    break;
            }
            while (true)
            {
                
               // Console.Clear();

                int turn = playerX.Move(field, true);
                field[turn] = 'X';
                WriteToConsole("Ход игрока X");
                WriteField(field);
                if (CheckToWin(field, 'X'))
                {
                    WriteToConsole("Выиграл X");
                    return;
                }
                turn = playerO.Move(field, false);
                field[turn] = 'O';
                WriteToConsole("Ход игрока O");
                WriteField(field);
                if (CheckToWin(field, 'O'))
                {
                    WriteToConsole("Выиграл O");

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
