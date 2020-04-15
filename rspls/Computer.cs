using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Computer : Player
    {

        public Computer()
        {
            name = "Computer";
            score = 0;
        }

        public override string GetChoice()
        {
            Random rand = new Random();
            return rand.Next(1, 5).ToString();
        }
    }
}
