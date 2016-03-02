using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
    Class: Character
    Purpose: creates character and all movement required for it
*/

namespace blank_canvas
{
    class Character
    {
        //parent to the enemy and the player

        //attributes (more to come)
        double health;

        //constructor
        public Character()
        {
            health = 10;
        }

        //moving (takes user input ('A' or 'D') and translates that to movement)
        public void Move(char input)
        {
            //moving backwards
            if(input == 'a' || input == 'A')
            {

            }
            //moving forwards
            else if (input == 'd' || input == 'D')
            {

            }
        }

        //accelerating(depending on how long a key ('A' or 'D') is pressed will increase your speed)
        public void Accel(char input)
        {
            //accelerating backwards
            if (input == 'a' || input == 'A')
            {

            }
            //accelerating forwards
            else if (input == 'd' || input == 'D')
            {

            }
        }

        //jumping(depending on user input ('W'), player position goes upwards)
        public void Jump(char input)
        {
            //jump up
        }

        //shooting(depending on user input ('Space Bar'?), a single projectile is fired from the player)
        public void Shoot(char input)
        {
            //fire right

            //fire left
        }

        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
        {
            //when hit by projectile

            //when hit by an enemy
        }


    }
}
