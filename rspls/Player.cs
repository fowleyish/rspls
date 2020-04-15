using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    abstract class Player
    {
        public int score;
        public string name;

        public Player()
        {

        }

        public abstract string GetChoice();
    }
}
