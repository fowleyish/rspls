using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Game
    {
        // Member vars

        // Two Players
        public Player playerOne;
        public Player playerTwo;

        // Round count per this Game
        public int roundCount;

        // Winning score can be adjusted at the Game constructor level
        public int winningScore;

        // Constructor
        public Game()
        {
            this.roundCount = 1;
            this.winningScore = 3;
        }

        // Member methods

        // Method to start a new game; called from Program.cs
        public void StartGame()
        {
            Console.WriteLine("Please select if this game is 2-player (Enter 1) or against the computer (Enter 2):");
            Console.WriteLine("1. 2-player");
            Console.WriteLine("2. Against the computer");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "2")
            {
                GetPlayerOne();
                GetPlayerTwo(choice); // choice argument determines whether the person is playing against a computer or a person
                Scoreboard();
            }
            else { Console.WriteLine("Please select a valid number from the menu."); StartGame(); }
        }

        // Creates playerOne object as human
        public void GetPlayerOne()
        {
            Console.WriteLine("Enter a name for Player 1: ");
            string name = Console.ReadLine();
            playerOne = new Human(name);
        }

        // Creates playerTwo object as either a Human or Computer depending on parameter
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

        // Controls game flow; while no one has yet won, start a round
        public void Scoreboard()
        {
            while (playerOne.score < winningScore && playerTwo.score < winningScore)
            {
                LineBreak(3);
                Round();
            }
            DeclareWinner(); // Declare the winner when it is finished
        }

        // Controls steps in each round in a Game
        public void Round()
        {
            // Write round name
            Console.WriteLine("Round " + roundCount);
            // Write all options for gestures
            PromptGesture();
            // use .GetChoice() method on Player objects; convert to lower to prevent case issues
            string p1Choice = playerOne.GetChoice().ToLower();
            string p2Choice = playerTwo.GetChoice().ToLower();
            // Input validation; see method
            ValidateInput(p1Choice, p2Choice);
            // Perform game logic against player selections
            GetRoundWinner(p1Choice, p2Choice);
            // Print current score
            PrintScores();
            // Increment round
            roundCount++;
        }

        // Validates user input per round against available options
        public void ValidateInput(string p1c, string p2c)
        {
            // counter variable to track valid responses
            int validCount = 0;
            foreach (string choice in playerOne.Gestures)
            {
                if (choice.ToLower() == p1c) { validCount++; } // Items in Gestures<T> converted to lowercase
                if (choice.ToLower() == p2c) { validCount++; }
            }
            if (validCount != 2) // if validCount counter variable is not equal to 2, the input was invalid
            {
                Console.WriteLine("One of these gestures is not valid. Please try again.");
                Scoreboard(); // ...so start over
            }
        }

        // Displays all available gestures
        public void PromptGesture()
        {
            Console.WriteLine("Select a gesture: "); 
            for (int i = 0; i < playerOne.Gestures.Count; i++)
            {
                Console.WriteLine(playerOne.Gestures[i]);
            }
        }

        // Round logic
        public void GetRoundWinner(string p1c, string p2c)
        {
            LineBreak(1);
            // Display what each player chose
            Console.WriteLine($"{playerOne.name} chose {p1c}");
            Console.WriteLine($"{playerTwo.name} chose {p2c}");
            // roundWinner for use in later printing round winner
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
            if (roundWinner != "") // roundWinner needs a value; otherwise, there was a tie
            {
                LineBreak(1);
                Console.WriteLine(roundWinner + " won this round!");
            }
        }

        // Prints current scores; invoked at the end of each Round()
        public void PrintScores()
        {
            Console.WriteLine("{0}'s score: {1}", playerOne.name, playerOne.score);
            Console.WriteLine("{0}'s score: {1}", playerTwo.name, playerTwo.score);
        }

        // Runs after one of the Players' scores reaches 3
        public void DeclareWinner()
        {
            LineBreak(3);
            if (playerOne.score > playerTwo.score)
            {
                Console.WriteLine($"{playerOne.name.ToUpper()} WINS!");
            }
            else
            {
                Console.WriteLine($"{playerTwo.name.ToUpper()} WINS!");
            }
            LineBreak(6);
            // Logic to handle playing again
            Console.WriteLine("Enter 1 to play again or anything else to close the application.");
            string r = Console.ReadLine();
            if (r == "1")
            {
                roundCount = 1;
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        // I like making LineBreak methods in console apps :)
        public void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }

    }
}
