using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
    Class: Enemy
    Purpose: creates enemy and all movement required for it
*/

namespace blank_canvas
{
    public class Enemy : Character
    {
        //a child of the character class

        //attributes

        //constructor
        public Enemy()
        {

        }

        //methods from the Parent

        //moving (takes user input ('A' or 'D') and translates that to movement)
        public void Move(int posX, int posY)
        {
            //no longer player controlled
            // enemies move based on where the player's postiton is relative to their own
        }

        //accelerating(depending on how long a key ('A' or 'D') is pressed will increase your speed)
        public void Accel()
        {
            //no longer player controlled
            //will accelerate when moving in a direction for a period of time
        }

        //jumping(depending on user input ('W'), player position goes upwards)
        public void Jump(char input)
        {
            //no longer player controlled
            //in fact, I don't think we really need a jump method for enemies
        }

        //shooting(depending on user input ('Space Bar'?), a single projectile is fired from the player)
        public void Shoot(int posX, int posY)
        {
            //no longer player controlled
            //if the enemies fire, mechanic is the same as parent, just with player position

            //fire right

            //fire left
        }

        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
        {
            //will have a health bar, invisible
            //the same as the parent, except much lower hit points
            //plus, enemies don't hur other enemies
        }

        //methods not from the Parent
    }
}

