using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    class Player: Character
    {
        //a child of the character class

        //attributes

        //constructor
        public Player()
        {

        }

        //methods from the Parent

        //moving (takes user input ('A' or 'D') and translates that to movement)
        public void Move(char input)
        {
            //no changes from the parent
        }

        //accelerating(depending on how long a key ('A' or 'D') is pressed will increase your speed)
        public void Accel(char input)
        {
            //no changes from the parent
        }

        //jumping(depending on user input ('W'), player position goes upwards)
        public void Jump(char input)
        {
            //no changes from the parent
        }

        //shooting(depending on user input ('Space Bar'?), a single projectile is fired from the player)
        public void Shoot(char input)
        {
            //no changes from the parent
        }

        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
        {
            //only real change is how much damage the player takes depending on each enemy
        }

        //methods not from the Parent
    }
}
