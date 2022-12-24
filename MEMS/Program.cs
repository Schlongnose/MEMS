using MEMS;
using System;
using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

public class Program
{
   
    public static int Getinput()
    {
        var input = Console.ReadLine();
        var result = int.Parse(input);
        return result;
    }

    

   

    public static void PrintScoreBoard(List<int> Scores)
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            Console.WriteLine($"Player {i} Score is {Scores[i]}");
        }
    }
    public static void Printplayerscore(List<Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            Console.WriteLine($"Player {player.Name} Score is {player.Point}");
        }
    }

    public static void Main()
    {
        try
        {
            
            MemoryBoard memoryBoard = new MemoryBoard(8);
            List<int> playerScore;
            List<Player> players = new List<Player>();
           // var x = new Player();
           // x.Name = "Billy";
           // players.Add(x);
            playerScore = new List<int>();
            int numberOfPlayers = 2;
            int playerTurn = 0;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                playerScore.Add(0);
                var x = new Player();
                x.Name = i.ToString();
                players.Add(x);
            }

            //Printplayerscore(players);

            while (!memoryBoard.IsBoardEmpty()) //Same as != True
            {
                PrintScoreBoard(playerScore);
                memoryBoard.Print('%');
                Console.WriteLine($"Player {playerTurn} choose a card");
                int guess1 = Getinput();
                Console.WriteLine($"Player {playerTurn} choose another card");
                int guess2 = Getinput();
                bool playerOneTurn = true;
                bool isGuessesValid = memoryBoard.ValidateGuesses(guess1, guess2);
                if (!isGuessesValid)
                {
                    Console.WriteLine("Invalid Guess");
                    continue;
                }
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
               
                if (checkingIsMatch == false)
                {
                    playerTurn++;
                    playerTurn %= numberOfPlayers;
                }
                else
                {
                    playerScore[playerTurn]++;
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
            int winnerScore = playerScore.Max();
            var winningIndexes = playerScore.FindAll(_ => _ == winnerScore);
            for (int i = 0; i < winningIndexes.Count; i++)
            {
                Console.WriteLine($"winner is {i}");
            }
        }
        catch (Exception x)
        {

        }
    }
}