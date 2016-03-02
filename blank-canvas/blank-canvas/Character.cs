using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blank_canvas
{
    class Character
    {
        //parent to the enemy and the player

        //constructor
        public Character()
        {

        }

        //moving (takes user input ('A' or 'D') and translates that to movement)
        public void Move(char input)
        {
            //moving forwards

            //moving backwards



        }

        //accelerating(depending on how long a key ('A' or 'D') is pressed will increase your speed)
        public void Accel()
        {
            //accelerating forwards and backwards

        }

        //jumping(depending on user input ('W'), player position goes upwards)
        public void Jump(char input)
        {
            //jump up
        }

        //shooting(depending on user input ('Space Bar'?), a single projectile is fired from the player)
        public void Shoot(char input)
        {
            //fire right or fire left
        }

        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
        {
            //when hit by projectile

        }


    }
}
