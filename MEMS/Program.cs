using MEMS;
using System;
using System.Collections;
using System.ComponentModel;

public class Program
{
    /*public static void Main1()
    {
        //int player1 = 0;
        //int player2 = 0;

        //ArrayList arrayList = new ArrayList();
        Console.WriteLine("Welcome to Billy's guess that number game choose a number");

        Random random = new Random();
        int randomNumber = random.Next(1, 11);
        int numberOfGuesses = 3;
        bool gameOver = false;
        int guess;


        while(gameOver == false)
        {
            guess = Convert.ToInt32(Console.ReadLine());
            numberOfGuesses--;

            if(guess != randomNumber && numberOfGuesses == 0)
            {
                Console.WriteLine("You Lose GG");
                gameOver = true;
            }
            else if(guess == randomNumber)
            {
                Console.WriteLine("You Win");
                gameOver = true;
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Too Much!");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("Too Small");
            }

        }
        Console.ReadLine();

    }
    */
    public static int Getinput()
    {
        var input = Console.ReadLine();
        var result = int.Parse(input);
        return result;
    }

    public static void PrintArray(ArrayList ar)
    {
        int array_Size = ar.Count;
        int last_position = array_Size - 1;
        Console.Write("Cards: ");
        for (int i = 0; i <= last_position; i++)
        {
            Console.Write(ar[i]); // Print out the content of the arraylist at position i.
            if (i != last_position) // If I am not at the last position, print a " " space to separate the numbers.
            {
                Console.Write("  ");
            }
        }
    }

    public static void Print_MaskedArray(ArrayList ar)
    {
        int array_Size = ar.Count;
        int last_position = array_Size - 1;
        Console.Write("Cards: ");
        for (int i = 0; i <= last_position; i++)
        {
            Console.Write("*"); // Print out the content of the arraylist at position i.
            if (i != last_position) // If I am not at the last position, print a " " space to separate the numbers.
            {
                Console.Write("  ");
            }
        }
    }

    public static void Print_SelectedCards(ArrayList ar, int pos1, int pos2)
    {
        int array_Size = ar.Count;
        int last_position = array_Size - 1;
        Console.Write("Cards: ");
        for (int i = 0; i <= last_position; i++)
        {
            if (i == pos1 || i == pos2) // If I am the selected cards, un-mask them and show.
            {
                Console.Write(ar[i]);
            }
            else
            {
                Console.Write("*"); // Mask the card content.
            }

            if (i != last_position) // If I am not at the last position, print a " " space to separate the numbers.
            {
                Console.Write("  ");
            }
        }
    }

    static void ShuffleCards(ArrayList arr)
    {
        // Creating a object
        // for Random class
        Random r = new Random();
        int array_Size = arr.Count;
        int last_position = array_Size - 1;
        // Start from the last element and
        // swap one by one. We don't need to
        // run for the first element
        // that's why i > 0
        for (int i = 0; i <= last_position; i++)                                              
        {

            // Pick a random index
            // from 0 to i
            int j = r.Next(0, i + 1);

            // Swap arr[i] with the
            // element at random index
            int temp = (int)arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            // PrintArray(arr);
            //Console.WriteLine();
        }
    }

    public static void Main()
    {
        try
        {
            /*  Console.WriteLine("Welcome to Billy's Memory Game Match The Following Numbers");
              int player1 = 0;
              int player2 = 0;
              bool gameOver = false;
              bool player1turn = false;
              bool player2turn = false;

              ArrayList arrlist = new();
              const int ARRAY_SIZE = 18;
              int card_num = 1;

              for (int i = 0; i < ARRAY_SIZE; i += 2)
              {
                  arrlist.Add(card_num);
                  arrlist.Add(card_num);
                  card_num++;
              }
              ShuffleCards(arrlist);
              Print_MaskedArray(arrlist);
              Console.WriteLine("Player 1's turn. please select 2 guesses");





                  int guess1 = Getinput();
                  int guess2 = Getinput();

              while (!gameOver)
              { 
                  if (guess1 < 0 || guess1 > 19)
                  {
                      Console.WriteLine("Please choose numbers between 0 - 18");
                      guess1 = Getinput;

                  }
                  if (guess2 < 0 || guess2 > 19)
                  {
                      Console.WriteLine("Please choose numbers between 0 - 18");
                      guess2 = Getinput;
                  }
              }





              //PrintArray(arrlist);

              Print_SelectedCards(arrlist, guess1-1, guess2-1);
              // Console.Clear(); // Clear the screen, basically a refresh

              */
            
            MemoryBoard memoryBoard = new MemoryBoard(10);
           
            
            while(!memoryBoard.IsBoardEmpty()) //Same as != True
            {
                memoryBoard.Print('%');
                Console.WriteLine("Player 1 choose a card");
                int guess1 = Getinput();
                Console.WriteLine("Player 1 choose another card");
                int guess2 = Getinput();
                bool playerOneTurn = true;
                memoryBoard.Open(guess1, guess2);
                memoryBoard.Print('%');
                
                bool checkingIsMatch = memoryBoard.IsMatch(guess1, guess2);
                if (checkingIsMatch == true)
                {
                    Console.WriteLine("Match!!!");
                    memoryBoard.Remove(guess1, guess2);
                }
                else
                {
                    memoryBoard.CloseAll();
                    Console.WriteLine("Didn't Match");
                }
                System.Threading.Thread.Sleep(3000);
                Console.Clear();
                
            }

            //memoryBoard.OpenAll();
            ////memoryBoard.PrintMaasked('$');
            //memoryBoard.Print('*');
            //memoryBoard.Open(3, 7);//lets pretend the player elects to open the index 3
            //memoryBoard.Open(10, 12); 
            //memoryBoard.Print('*');
            //memoryBoard.CloseAll();
            //memoryBoard.Print('*');
            //memoryBoard.Open(5, 8);
            //memoryBoard.Print('*');
            //var ismatch = memoryBoard.IsMatch(9, 9);
            //Console.WriteLine(ismatch);
            Console.WriteLine("GAME");
        }
        catch (Exception x)
        {

        }
    }
}