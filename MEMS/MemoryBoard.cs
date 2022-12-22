using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEMS
{
    // constructor:
    //  * create the board with cards in order
    //  * shuffle the cards
    // ability (function) to print board (all unmasked)
    // ability (function) to print board (all masked)
    public class MemoryBoard
    {
        private int _iNumOfCards;

        private List<int> board;
        private List<bool> facedown;

        public MemoryBoard(int iNumOfCards)
        {
            ValidateBoardSize(iNumOfCards);

            board = new List<int>();
            _iNumOfCards = iNumOfCards;
            facedown = new List<bool>();
            InitializeBoard();


            Shuffle();
        }

        private void ValidateBoardSize(int iNumOfCards)
        {
            if (iNumOfCards <= 9)
            {
                throw new Exception("Memory Board must have at least 10 cards");
            }

            if (iNumOfCards > 52)
            {
                throw new Exception("Memory Board must have less 52 cards");
            }

            // if iNumOfCards is an odd number, error or throw exception
            if (iNumOfCards % 2 == 1)
            {
                throw new Exception("Memory Board must have even number of cards");
            }
        }
        public bool ValidateGuesses(int guess1, int guess2)
        {
            if (guess1 < 0)
            {
                return false;
            }
            if (guess1 >= board.Count)
            {
                return false;
            }

            if(guess1 == guess2)
            {
                return false;
            }
            if (guess2 < 0)
            {
                return false;
            }
            if (guess2 >= board.Count)
            {
                return false;
            }
            return true;

        }
    

        private void InitializeBoard()
        {
            var card_num = 1;
            while (board.Count < _iNumOfCards)
            {
                board.Add(card_num);
                facedown.Add(true);
                board.Add(card_num);
                facedown.Add(true);
                card_num++;                 
            }
           
            return;
        }

        private void Shuffle()
        {
            // Creating a object
            // for Random class
            Random random = new Random();
            int last_position = board.Count - 1;
            // Start from the last element and
            // swap one by one. We don't need to
            // run for the first element
            // that's why i > 0
            for (int i = 0; i <= last_position; i++)
            {

                // Pick a random index
                // from 0 to i
                int j = random.Next(0, i + 1);

                // Swap arr[i] with the
                // element at random index
                int temp = (int)board[i];
                board[i] = board[j];
                board[j] = temp;
                // PrintArray(arr);
                //Console.WriteLine();
            }
        }

        //public void Open(int position)
        //{
        //    facedown[position] = false;
        //}
        public void Remove(int position, int position2)
        {
            int maxPosition =Math.Max(position, position2);
            int minPosition =Math.Min(position, position2);
            board.RemoveAt(maxPosition);
            board.RemoveAt(minPosition);
            facedown.RemoveAt(maxPosition);
            facedown.RemoveAt(minPosition);
        }

        public void Open(int position, int position2)
        {
            facedown[position] = false;
            facedown[position2] = false;
        }
        public bool IsMatch(int position, int position2)
        {
           var result = (board[position] == board[position2]);
            return result;
        }
        public bool IsBoardEmpty()
        {
            var result = board.Count == 0;
            return result;
        }
        //fix when to print value vs when to print maskchar in the for loop
        public void Print(char maskchar)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (((bool)facedown[i]) == true)
                {
                    Console.Write(maskchar);
                }

                if (((bool)facedown[i]) == false)
                {
                    Console.Write(board[i]);
                }

                //Console.Write(board[i]);
                //Console.Write(facedown[i]);
                //if (i != _iNumOfCards)
                //{
                Console.Write("  ");

           

                //}
            }
            Console.WriteLine();
            Console.WriteLine();

            
        }

        public void CloseAll()
        {
            for(int i = 0; i < facedown.Count; i++)
            {
                facedown[i] = true;
            }
        }

        public void OpenAll()
        {
            for (int i = 0; i < facedown.Count; i++)
            {
                facedown[i] = false;
            }
        }
    }
}
