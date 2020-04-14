using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Game
    {
        public List<string> Gestures;

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
        }
    }
}
