using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace GameBot

{
    public class GameBot : Game.Game
    {

        public override void Play()
        {
            bool validInput;
            int choice;

            do
            {
                Console.Clear();
                DrawBoard();

                if (currentPlayer == 1)
                {
                    Console.WriteLine("Игрок 1, введите номер ячейки:");

                    validInput = int.TryParse(Console.ReadLine(), out choice)&& choice >= 1 && choice <= 9&& board[choice - 1] != 'X' && board[choice - 1] != 'O';

                    if (validInput)
                    {
                        board[choice - 1] = (currentPlayer == 1) ? 'X' : 'O';

                        if (CheckForWin())
                        {
                            Console.Clear();
                            DrawBoard();
                            Console.WriteLine($"Победил игрок {currentPlayer}!");
                            break;

                        }

                        if (CheckForDraw())
                        {
                            Console.Clear();
                            DrawBoard();
                            Console.WriteLine("Ничья!");
                            break;

                        }
                        currentPlayer = 2;
                    }
                    else
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
                else
                {
                    Random rand = new Random();
                    do
                    {
                        choice = rand.Next(1, 10);
                    }
                    while (board[choice - 1] == 'X' || board[choice - 1] == 'O');

                    board[choice - 1] = 'O';

                    if (CheckForWin())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Победил бот!");
                        break;
                    }

                    if (CheckForDraw())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Ничья!");
                        break;
                    }
                    currentPlayer = 1;
                }
            } while (true); 
        }
    }
}