using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Human : Player
    {

        public Human(string name)
        {
            this.name = name;
            score = 0;
        }

        public override string GetChoice()
        {
            Console.Write("What will {0} choose?: ", this.name);
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
