﻿using MEMS;
using MEMS;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

public class Program
{
   

    public static int GetIntInput()
    {
        var input = Console.ReadLine();
        var result = int.Parse(input);
        return result;
    }
    public static string GetStringInput()
    {
        var result = Console.ReadLine();
        return result;
    }


    public static void Main()
    {
        PlayConnect();
        //PlayTikTakToe();
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

    public static void PlayMems()
    {
        try
        {
            MemoryBoard memoryBoard = new MemoryBoard(8);
           // List<int> playerScore = new List<int>();
            List<Player> players = new List<Player>();
            // var x = new Player();
            // x.Name = "Billy";
            // players.Add(x);
            Console.WriteLine("How Many Players?");
            int numberOfPlayers = GetIntInput();
            for (int i = 0; i < numberOfPlayers; i++)
            {
               // playerScore.Add(0);
               Console.WriteLine($"Player{i} Please Enter Your Name.");
                var name = GetStringInput();
                
                var x = new Player(name);
                //x.Name = i.ToString();
                players.Add(x);
            }

            //Printplayerscore(players);

            int playerTurn = 0;
            while (!memoryBoard.IsBoardEmpty()) //Same as != True
            {
                Printplayerscore(players);
                memoryBoard.Print('%');
                Console.WriteLine($"Player {players[playerTurn].Name} choose a card");
                int guess1 = GetIntInput();
                Console.WriteLine($"Player {players[playerTurn].Name} choose another card");
                int guess2 = GetIntInput();
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
                    //playerScore[playerTurn]++;
                    
                    //var currentPlayer = players[playerTurn];
                    //currentPlayer.Point++;

                    players[playerTurn].Point++;
                }
                else
                {
                    memoryBoard.CloseAll();
                    Console.WriteLine("Didn't Match");
                    playerTurn++;
                    playerTurn %= numberOfPlayers;
                }


                System.Threading.Thread.Sleep(3000);
                Console.Clear();

            }

            Printplayerscore(players);
            Console.WriteLine("GAME");
            // players example: [{"john", 5}, {"billy", 3}, {"josh", 5}]
            int winnerScore = players.Select(p => p.Point).Max(); // e.g. 5
            //var winningIndexes = playerScore.FindAll(_ => _ == winnerScore);
            var winningPlayers = players.FindAll(p => p.Point == winnerScore);

            for (int i = 0; i < winningPlayers.Count; i++)
            {
                Console.WriteLine($"winner is {winningPlayers[i].Name}");
            }
            //foreach(var winningplayer in winningPlayers )
            //{
            //    Console.WriteLine($"winner is {winningplayer.Name}");
            //}
            //// players:         [{"john", 5}, {"billy", 3}, {"josh", 5}]
            //// winning indeces: [0, 2]

            //for (int i = 0; i < winningPlayers.Count; i++)
            //{
            //    Console.WriteLine($"winner is {players[winningPlayers[i]].Name}");
            //}
        }
        catch (Exception x)
        {

        }
        
    }
    
    public static void PlayTikTakToe()
    {
        List<Player> players = new List<Player>();
        Tiktakboard tiktakboard = new Tiktakboard();
        Console.WriteLine("Welcome to Billy's TIKTAKTOE. First to get 3 in a row wins.");
        tiktakboard.Print();
        int numberOfPlayers = 2;
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Console.WriteLine($"Player{i} Please Enter Your Name.");
            var name = GetStringInput();

            var x = new Player(name);
            players.Add(x);
        }


        int playerTurn = 0;
        while (!tiktakboard.checkForWinner())
        {
           
            Console.WriteLine($"Player {players[playerTurn].Name} Pick A Spot.");
            int playerChoice = GetIntInput();
            if (!tiktakboard.ValidateChooseSpot(playerChoice))
            {
                Console.WriteLine("Invalid Choice.");
                continue;
            }
            
            if(playerTurn == 0)
            {
                tiktakboard.Choosespot(playerChoice, "X");
            }
            else
            {
                tiktakboard.Choosespot(playerChoice, "O");
            }
            tiktakboard.Print();
            var isWinner = tiktakboard.checkForWinner();
            if(isWinner == true)
            {
                Console.WriteLine($"winner is {players[playerTurn].Name}");
                break;
            }
            var spotAvailable = tiktakboard.IsAnySpaceAvailable();
            if(!spotAvailable)
            {
                Console.WriteLine("no contest");
                break;
            }
            playerTurn++;
            playerTurn %= numberOfPlayers;


        }


        
    }
    public static void PlayConnect()
    {
        Connect4Board connect4Board= new Connect4Board();
        connect4Board.Print();
        for( int i = 0; i <10; i++ )
        {
            Console.WriteLine("Enter a Column ");
            var input = GetIntInput();
            connect4Board.ChooseColumn(input , "X");
            Console.WriteLine("\n\n\n\n");
            connect4Board.Print();
        }
    }
}