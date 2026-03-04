using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace GameHuman
    
{
    public class GameHuman : Game.Game
    {
        public override void Play()
        {
            bool validInput;
            int choice;

            do
            {
                Console.Clear();
                DrawBoard();

                Console.WriteLine($"Игрок {currentPlayer}, введите номер ячейки:");

                validInput = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';

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

                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                }
                else
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            } while (true);
        }
    }
}