using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterShip
{
    internal class Player
    {
      



        private char[,] field;
        private char[,] enemyField;
        private readonly int SIZE;
        private readonly char SHIP_SYMBOL;
        int[] ships = { 0, 4, 3, 2, 1 };

        public Player(int SIZE, char SHIP_SYMBOL)
        {



            this.field = new char[SIZE, SIZE];
            this.SIZE = SIZE;
            this.SHIP_SYMBOL = SHIP_SYMBOL;
            initField(this.field, SIZE);
            this.enemyField = new char[SIZE, SIZE];
            initField(this.enemyField, SIZE);

            Console.WriteLine("1 - Расставить корабли случайным образом \n 2 - Расставить корабли вручную");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    randomPlaceShips(this.field, SIZE, SHIP_SYMBOL);
                    printField();
                    break;
                case 2:
                    choiseShip();
                    break;
                default:
                    Console.WriteLine("Неверный выбор -  расставляем корабли случайным образом");
                    randomPlaceShips(this.field, SIZE, SHIP_SYMBOL);
                    printField();
                    break;
            }
        }



        private void colorPrint(char symbol)
        {
            switch (symbol)
            {
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case '■':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '-':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ResetColor();
                    break;

            }

            Console.Write(symbol + " ");
            Console.ResetColor();
        }


        void randomPlaceShips(char[,] field, int SIZE, char SHIP_SYMBOL)
        {
            Random rand = new Random();
            for (int weight = 4; weight >= 1; weight--)
            {
                for (int count = 0; count < ships[weight];)
                {
                    int x = rand.Next(SIZE);
                    int y = rand.Next(SIZE);
                    bool isHorizontal = rand.Next(2) == 0;
                    if (canPlaceShip(field, x, y, weight, isHorizontal))
                    {
                        placeShip(field, x, y, weight, isHorizontal);
                        count++;
                    }
                }
            }
        }
        void placeShip(char[,] field, int x, int y, int weight, bool isHorizontal)
        {
            for (int i = 0; i < weight; i++)
            {
                field[y, x] = SHIP_SYMBOL;



                if (isHorizontal)
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }

        }
        void initField(char[,] field, int SIZE)
        {

            for (int i = 0; i < SIZE; i++)
            {

                for (int j = 0; j < SIZE; j++)
                {
                    field[i, j] = '~';
                }
            }
        }


        public void printField()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < SIZE; i++)
            {
                if (i == SIZE - 1)
                {
                    Console.Write($"{i + 1} ");
                }
                else
                {
                    Console.Write($" {i + 1} ");
                }

                for (int j = 0; j < SIZE; j++)
                {
                    colorPrint(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void printEnemyField()
        {
            Console.WriteLine("   A B C D E F G H I J");
            for (int i = 0; i < SIZE; i++)
            {
                if (i == SIZE - 1)
                {
                    Console.Write($"{i + 1} ");
                }
                else
                {
                    Console.Write($" {i + 1} ");
                }

                for (int j = 0; j < SIZE; j++)
                {
                    colorPrint(enemyField[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void MarkShotOnEnemyField(int x, int y, bool isHit)
        {
            if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            { 
                if (isHit)
                {
                  
                    enemyField[y, x] = 'X';
                }
                else
                {
                  
                    enemyField[y, x] = '-';
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates for marking shot miss.");
            }
            return;
        }

        public void MarkShotOnMyField(int x, int y, bool isHit)
        {
            if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            {
                if (isHit)
                {

                    field[y, x] = 'X';
                }
                else
                {

                    field[y, x] = '-';
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates for marking shot miss.");
            }
            return;
        }

        public bool DidEnemyHitMyShip(int x, int y)
        {
            if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            {
                if (field[y, x] == SHIP_SYMBOL)
                {

                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Invalid coordinates (DidEnemyHitMyShip) {y} - {x}");
            }
            return false;
        }


        public void MarkEnemyShotOnMyField(int x, int y, bool isHit)
        {
            if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
            {
                if (isHit)
                {

                    field[y, x] = 'X';
                }
                else
                {

                    field[y, x] = '•';
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates for marking shot miss.");
            }
            return;
        }

        bool canPlaceShip(char[,] field, int x, int y, int weight, bool isHorizontal)
        {

            for (int i = 0; i < weight; i++)
            {
                int currentX;
                int currentY;

                if (isHorizontal == true)
                {
                    currentX = x + i;
                    currentY = y;
                }
                else
                {
                    currentX = x;
                    currentY = y + i;
                }

                if (currentX < 0 || currentX >= 10 || currentY < 0 || currentY >= 10)
                {
                    return false;
                }

                if (field[currentY, currentX] != '~')
                {
                    return false;
                }

                for (int ix = -1; ix <= 1; ix++)
                {
                    for (int jy = -1; jy <= 1; jy++)
                    {
                        int checkX = currentX + ix;
                        int checkY = currentY + jy;

                        if (checkX >= 0 && checkX < 10 && checkY >= 0 && checkY < 10)
                        {
                            if (field[checkY, checkX] == SHIP_SYMBOL)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;

        }

        void choiseShip()
        {
            while (ships[1] > 0 || ships[2] > 0 || ships[3] > 0 || ships[4] > 0)
            {
                Console.WriteLine("Enter the weight of the ship:");
                int weight = int.Parse(Console.ReadLine());

                if (weight < 1 || weight > 4)
                {
                    Console.WriteLine("Invalid ship weight.");
                    continue;
                }

                if (ships[weight] <= 0)
                {
                    Console.WriteLine($"No {weight}-deck ships left.");
                    continue;
                }

                Console.WriteLine("Ship horizontal or no (input 1 or any symbol)");
                bool isHorizontal = Console.ReadLine() == "1";

                Console.WriteLine("Enter coordinates (A5):");
                string coordinates = Console.ReadLine().ToUpper();

                int x = coordinates[0] - 'A';
                int y = int.Parse(coordinates.Substring(1)) - 1;

                if (canPlaceShip(field, x, y, weight, isHorizontal))
                {
                    placeShip(field, x, y, weight, isHorizontal);
                    ships[weight]--;
                }
                else
                {
                    Console.WriteLine("Cannot place the ship.");
                }

                Console.Clear();
                printField();

                Console.WriteLine($"■■■■: {ships[4]}");
                Console.WriteLine($"■■■ : {ships[3]}");
                Console.WriteLine($"■■  : {ships[2]}");
                Console.WriteLine($"■   : {ships[1]}");
            }
        }

    }
}
