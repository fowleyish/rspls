using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Human : Player // Human is a Player
    {

        // Human constructor; sets name from user input in Game() class
        public Human(string name)
        {
            this.name = name;
            score = 0;
        }

        // GetChoice() override from Player parent
        public override string GetChoice()
        {
            // Prompt for input
            Console.Write("What will {0} choose?: ", this.name);
            string choice = "";
            // Use a popular method for obscuring passwords to prevent the other player from seeing this player's input
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter) // All keys except for Backspace and Enter
                {
                    choice += key.KeyChar; // Add the keystroke to the choice input...
                    Console.Write(" "); // ...but output a blank space in the console
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && choice.Length > 0)
                    {
                        choice = choice.Substring(0, (choice.Length - 1));
                        Console.Write("\b \b"); // Used to backspace if there is a character in the previous index position
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break; // Complete choice value editing when the Enter key is struck; break out of loop
                    }
                }
            } while (true);
            Console.WriteLine();
            return choice; // Return obfuscated input to Game()
        }
    }
}
