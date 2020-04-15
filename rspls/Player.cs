using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    abstract class Player
    {
        // Member variables: all players will have a score, a name, and access to Gestures from constructor
        public int score;
        public string name;
        public List<string> Gestures;

        public Player()
        {
            Gestures = new List<string>()
            {
                "Rock",
                "Paper",
                "Scissors",
                "Lizard",
                "Spock"
            };
        }

        // GetChoice abstract method; overriden in child classes as Humans and Computers get their choices differently
        public abstract string GetChoice();
    }
}
