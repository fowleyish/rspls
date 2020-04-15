using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    abstract class Player
    {
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

        public abstract string GetChoice();
    }
}
