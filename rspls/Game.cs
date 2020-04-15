using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Game
    {
        public Player playerOne;
        public Player playerTwo;
        public int roundCount;
        public int winningScore;

        public Game()
        {
            
            this.roundCount = 1;
            this.winningScore = 3;
        }

        public void StartGame()
        {
            Console.WriteLine("Please select if this game is 2-player (Enter 1) or against the computer (Enter 2):");
            Console.WriteLine("1. 2-player");
            Console.WriteLine("2. Against the computer");
            string choice = Console.ReadLine();
            GetPlayerOne();
            GetPlayerTwo(choice);
            Scoreboard();
        }

        public void GetPlayerOne()
        {
            Console.WriteLine("Enter a name for Player 1: ");
            string name = Console.ReadLine();
            playerOne = new Human(name);
        }

        public void GetPlayerTwo(string choice)
        {
            if (choice == "1")
            {
                Console.WriteLine("Enter a name for Player 2: ");
                string name = Console.ReadLine();
                playerTwo = new Human(name);
            }
            else if (choice == "2")
            {
                playerTwo = new Computer();
            }
        }

        public void Scoreboard()
        {
            while (playerOne.score < winningScore && playerTwo.score < winningScore)
            {
                LineBreak(3);
                Round();
            }
            DeclareWinner();
        }

        public void Round()
        {
            Console.WriteLine("Round " + roundCount);
            PromptGesture();
            string p1Choice = playerOne.GetChoice().ToLower();
            string p2Choice = playerTwo.GetChoice().ToLower();
            ValidateInput(p1Choice, p2Choice);
            GetRoundWinner(p1Choice, p2Choice);
            PrintScores();
            roundCount++;
        }

        public void ValidateInput(string p1c, string p2c)
        {
            int validCount = 0;
            foreach (string choice in playerOne.Gestures)
            {
                if (choice.ToLower() == p1c) { validCount++; }
                if (choice.ToLower() == p2c) { validCount++; }
            }
            if (validCount != 2)
            {
                Console.WriteLine("One of these gestures is not valid. Please try again.");
                Scoreboard();
            }
        }

        public void PromptGesture()
        {
            Console.WriteLine("Select a gesture: "); 
            for (int i = 0; i < playerOne.Gestures.Count; i++)
            {
                Console.WriteLine(playerOne.Gestures[i]);
            }
        }

        public void GetRoundWinner(string p1c, string p2c)
        {
            LineBreak(1);
            Console.WriteLine($"{playerOne.name} chose {p1c}");
            Console.WriteLine($"{playerTwo.name} chose {p2c}");
            string roundWinner = "";
            switch (p1c) {
                case "rock":
                    if (p2c == "paper" || p2c == "spock")
                    {
                        playerTwo.score++;
                        roundWinner = playerTwo.name;
                    }
                    else if (p2c == "lizard" || p2c == "scissors")
                    {
                        playerOne.score++;
                        roundWinner = playerOne.name;
                    }
                    else
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    break;
                case "paper":
                    if (p2c == "scissors" || p2c == "lizard")
                    {
                        playerTwo.score++;
                        roundWinner = playerTwo.name;
                    }
                    else if (p2c == "spock" || p2c == "rock")
                    {
                        playerOne.score++;
                        roundWinner = playerOne.name;
                    }
                    else
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    break;
                case "scissors":
                    if (p2c == "rock" || p2c == "spock")
                    {
                        playerTwo.score++;
                        roundWinner = playerTwo.name;
                    }
                    else if (p2c == "paper" || p2c == "lizard")
                    {
                        playerOne.score++;
                        roundWinner = playerOne.name;
                    }
                    else
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    break;
                case "lizard":
                    if (p2c == "paper" || p2c == "spock")
                    {
                        playerTwo.score++;
                        roundWinner = playerTwo.name;
                    }
                    else if (p2c == "lizard" || p2c == "scissors")
                    {
                        playerOne.score++;
                        roundWinner = playerOne.name;
                    }
                    else
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    break;
                case "spock":
                    if (p2c == "paper" || p2c == "lizard")
                    {
                        playerTwo.score++;
                        roundWinner = playerTwo.name;
                    }
                    else if (p2c == "rock" || p2c == "scissors")
                    {
                        playerOne.score++;
                        roundWinner = playerOne.name;
                    }
                    else
                    {
                        Console.WriteLine("There was a tie!");
                    }
                    break;
            }
            if (roundWinner != "")
            {
                LineBreak(1);
                Console.WriteLine(roundWinner + " won this round!");
            }
        }

        public void PrintScores()
        {
            Console.WriteLine("{0}'s score: {1}", playerOne.name, playerOne.score);
            Console.WriteLine("{0}'s score: {1}", playerTwo.name, playerTwo.score);
        }

        public void DeclareWinner()
        {
            if (playerOne.score > playerTwo.score)
            {
                Console.WriteLine($"{playerOne.name.ToUpper()} WINS!");
            }
            else
            {
                Console.WriteLine($"{playerTwo.name.ToUpper()} WINS!");
            }
            LineBreak(6);
            Console.WriteLine("Enter 1 to play again or anything else to close the application.");
            string r = Console.ReadLine();
            if (r == "1")
            {
                roundCount = 0;
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }

    }
}
