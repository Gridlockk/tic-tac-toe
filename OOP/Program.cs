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

            WriteToConsole("Play With player 2 = 1 or With bot = 2");

            int choice = 0;
            choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    HumanVsHuman hvsh = new HumanVsHuman();
                    hvsh.play();
                    break;
                case 2:
                    HumanVsBot hvsb = new HumanVsBot();
                    hvsb.play();
                    break;
                default:
                    WriteToConsole("unknown choice");
                    break;
            }




        }
    }
}
