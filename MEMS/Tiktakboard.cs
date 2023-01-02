using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMS
{
    public class Tiktakboard
    {
        private List<string> board;
        public Tiktakboard()
        {
            board = new List<string>();
            InitializeTikBoard();
        }
        private void InitializeTikBoard()
        {
            var square = 1;
            while (board.Count < 9)
            {
                board.Add(square.ToString());
                square++;

            }

            return;
        }
        public void Print()
        {
            for (int i = 0; i < board.Count; i++)
            {
                Console.Write("\t");
                Console.Write(board[i]);
                Console.Write("\t");
                Console.Write('|');

                if(i == 2 || i == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("__________________________________________________________");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void Choosespot(int chosenSpot)
        {
            board[chosenSpot-1] = "X"; 
            return;

        }
        public bool ValidateChooseSpot(int chosenSpot)
        {
            if(chosenSpot < 1 || chosenSpot > 9)
            {
                return false;
            }
            if (board[chosenSpot-1] == "X" || board[chosenSpot-1] == "O")
            {
                return false;
            }
            return true;
        }
        public bool checkIfGameOver()
        {
            if (board[0] == board[1] && board[1] == board[2]) // top cross
            {
                return true;
            }
            if (board[0] == board[4] && board[4] == board[8])//left corner diagnol
            {
                return true;
            }
            if (board[0] == board[3] && board[3] == board[6]) //left down
            {
                return true;
            }
            if (board[1] == board[4] && board[4] == board[7])// middle down
            {
                return true;
            }
            if (board[2] == board[5] && board[5] == board[8])//right down
            {
                return true;
            }

            if (board[3] == board[4] && board[4] == board[5])//middle cross
            {
                return true;
            }
            if (board[6] == board[7] && board[7] == board[8])//bottom cross
            {
                return true;
            }
            if (board[2] == board[4] && board[4] == board[6])//right corner diagnol
            {
                return true;
            }
            return false;
        }


    }
}
