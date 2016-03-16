using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace blank_canvas
{
    public class Player: Character
    {
        //a child of the character class

        //attributes
        Rectangle playerRec;

        //constructor
        public Player(Rectangle pRec)
        {
            playerRec = new Rectangle(pRec.X, pRec.Y, pRec.Width, pRec.Height);
        }

        //methods from the Parent

        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
        {
            //only real change is how much damage the player takes depending on each enemy
        }

        //methods not from the Parent

        //change colors
        public void colorChange()
        {
            //if player hits enter then 
        }
    }
}

