using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Game

{
    abstract public class Game
    {
        public char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public int currentPlayer = 1;


        abstract public void Play();

        public void DrawBoard()
        {
            Console.WriteLine("┌───┬───┬───┐");
            Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} |");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} |");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} |");
            Console.WriteLine("└───┴───┴───┘");
        }

        public bool CheckForWin()
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                (board[3] == board[4] && board[4] == board[5]) ||
                (board[6] == board[7] && board[7] == board[8]) ||
                (board[0] == board[3] && board[3] == board[6]) ||
                (board[1] == board[4] && board[4] == board[7]) ||
                (board[2] == board[5] && board[5] == board[8]) ||
                (board[0] == board[4] && board[4] == board[8]) ||
                (board[2] == board[4] && board[4] == board[6]);
        }

        public bool CheckForDraw()
        {

            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }

        public void WinOrDraw()
        {

        }

    }
}