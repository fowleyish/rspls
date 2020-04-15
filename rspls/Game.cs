using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Game
    {
        public List<string> Gestures;
        public Player playerOne;
        public Player playerTwo;
        public int roundCount;

        public Game()
        {
            Gestures = new List<string>()
            {
                "Rock",
                "Paper",
                "Scissors",
                "Lizard",
                "Spock"
            };
            this.roundCount = 1;
        }

        public void StartGame()
        {
            Console.WriteLine("Please select if this game is 2-player (Enter 1) or against the computer (Enter 2):");
            Console.WriteLine("1. 2-player");
            Console.WriteLine("2. Against the computer");
            string choice = Console.ReadLine();
            GetPlayerOne();
            GetPlayerTwo(choice);
            Round();
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
            while (playerOne.score < 3 && playerTwo.score < 3)
            {
                Round();
            }
            DeclareWinner();
        }

        public void Round()
        {
            Console.WriteLine("Round " + roundCount);
            PromptGesture();
            string p1Choice = playerOne.GetChoice();
            string p2Choice = playerTwo.GetChoice();
            Console.WriteLine($"{playerOne.name} chose {p1Choice}");
            Console.WriteLine($"{playerTwo.name} chose {p2Choice}");
            GetRoundWinner(p1Choice, p2Choice);
            roundCount++;
        }

        public void PromptGesture()
        {
            Console.WriteLine("Select a number corresponding to your choice: "); 
            for (int i = 0; i < Gestures.Count; i++)
            {
                Console.WriteLine($"{i}: {Gestures[i]}");
            }
        }

        public void GetRoundWinner(string p1c, string p2c)
        {

        }

        public void DeclareWinner()
        {
            if (playerOne.score > playerTwo.score)
            {
                Console.WriteLine($"{playerOne.name} wins!");
            }
            else
            {
                Console.WriteLine($"{playerTwo.name} wins!");
            }
        }

    }
}
