using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal abstract class IGame
    {
        public char[,] arr =
             {
                    { '.', '.', '.' },
                    { '.', '.', '.' },
                    { '.', '.', '.' }
             };


       

        public abstract  void play();// абстрактное потому что без него нельзя определить пустое свойство класса
        public void WriteField(char[,] arr)
        {
            Program.WriteToConsole($"╔═╦═╦═╗\n║{arr[0,0]}║{arr[0, 1]}║{arr[0, 2]}║\n╠═╬═╬═╣\n║{arr[1, 0]}║{arr[1, 1]}║{arr[1, 2]}║\n╠═╬═╬═╣\n║{arr[2, 0]}║{arr[2, 1]}║{arr[2, 2]}║\n╚═╩═╩═╝");
            return;
        }
        public bool CheckToWin(char[,] arr)
        {
            // horizontal check
            for (int i = 0; i < 3; i++)
            {
                if (arr[i, 0] != '.' && arr[i, 0] == arr[i, 1] && arr[i, 1] == arr[i, 2])
                    return true;
            }

            // vertical check
            for (int j = 0; j < 3; j++)
            {
                if (arr[0, j] != '.' && arr[0, j] == arr[1, j] && arr[1, j] == arr[2, j])
                    return true;
            }

            // diagonal check
            if (arr[0, 0] != '.' && arr[0, 0] == arr[1, 1] && arr[1, 1] == arr[2, 2])
                return true;

            // mirror diagonal chck
            if (arr[0, 2] != '.' && arr[0, 2] == arr[1, 1] && arr[1, 1] == arr[2, 0])
                return true;

            return false;
        }
    }
}
