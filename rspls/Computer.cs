using System;
using System.Collections.Generic;
using System.Text;

namespace rspls
{
    class Computer : Player // Computer is a player
    {

        // Constructor; Computer's name will always be Computer
        public Computer()
        {
            name = "Computer";
            score = 0;
        }

        // GetChoice() override from Player parent class
        public override string GetChoice()
        {
            Random rand = new Random(); // init Random object
            int choice = rand.Next(1, 5); // get a random number from 1-5
            return Gestures[choice]; //Return the gesture from Gestures<T> where the index number == the random number
        }
    }
}
