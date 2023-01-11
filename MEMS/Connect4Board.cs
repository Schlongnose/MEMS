using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMS
{
    internal class Connect4Board
    {
        private List<List<string>> board;
       
        public Connect4Board()
        {
            
            InitializeConnectBoard();
            
        }
        private void InitializeConnectBoard()
        {
            board = new List<List<string>>();
            
            for (int i = 0; i < 6; i++)
            {
                var smallboard = new List<string>();
                for (int j = 0; j < 7; j++)
                {
                    smallboard.Add("L");
                }
                board.Add(smallboard);
            }

            return;
        }
        public void Print()
        {
            foreach (var row in board)
            {
                
                Console.WriteLine("\n");
                
                foreach (var item in row)
                {
                    Console.Write(item);
                    Console.Write("\t");
                }
                Console.WriteLine("\n");
                Console.WriteLine("____________________________________________________");

            }
            
        }
        public void ChooseColumn(int chosenColumnIndex, string playerSymbol)
        {
            var rowIndex = FindAvailableRowIndex(chosenColumnIndex);
            board[rowIndex][chosenColumnIndex] = playerSymbol;
            return;

        }
        public bool ValidateChoosenColumn(int chosenColumnIndex)
        {
            if (chosenColumnIndex >= board[0].Count)
            {
                return false;
            }
            if (chosenColumnIndex < 0)
            {
                return false;
            }
            //if (board[0][chosenColumnIndex] == "X" || board[0][chosenColumnIndex] == "O")
            if(!IsCellOpen(chosenColumnIndex, 0))
            {
                return false;
            }
            return true;
        }
        public int FindAvailableRowIndex(int columnIndex)
        {
            
            for (var lastRowIndex = board.Count - 1; lastRowIndex >= 0; lastRowIndex--)
            {
                if (IsCellOpen(columnIndex, lastRowIndex))
                {
                    return lastRowIndex;
                }
            }
            return -1;
        }
        public bool IsCellOpen(int columnIndex, int rowIndex)
        {
            if (board[rowIndex][columnIndex] == "X" || board[rowIndex][columnIndex] == "O")
            {
                return false;
            }
            return true;
        }
        //public bool checkForWinner()
        //{
        //    if (board[0] == board[1] && board[1] == board[2]) // top cross
        //    {
        //        return true;
        //    }
        //    if (board[0] == board[4] && board[4] == board[8])//left corner diagnol
        //    {
        //        return true;
        //    }
        //    if (board[0] == board[3] && board[3] == board[6]) //left down
        //    {
        //        return true;
        //    }
        //    if (board[1] == board[4] && board[4] == board[7])// middle down
        //    {
        //        return true;
        //    }
        //    if (board[2] == board[5] && board[5] == board[8])//right down
        //    {
        //        return true;
        //    }

        //    if (board[3] == board[4] && board[4] == board[5])//middle cross
        //    {
        //        return true;
        //    }
        //    if (board[6] == board[7] && board[7] == board[8])//bottom cross
        //    {
        //        return true;
        //    }
        //    if (board[2] == board[4] && board[4] == board[6])//right corner diagnol
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //public bool isanyspaceavailable()
        //{
        //    foreach (var item in board)
        //    {
        //        if (item != "x" && item != "o")
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
