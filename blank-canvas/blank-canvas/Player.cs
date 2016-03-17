using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace blank_canvas
{
<<<<<<< HEAD
    public class Player: Character
=======
    public class Player : Character
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
    {
        //a child of the character class

        //attributes
<<<<<<< HEAD
        Rectangle playerRec;

        //constructor
        public Player(Rectangle pRec)
        {
            playerRec = new Rectangle(pRec.X, pRec.Y, pRec.Width, pRec.Height);
        }

        //methods from the Parent

            /*
        //take damage(when colliding with an enemy/projectile, health gets lowered
        public void takeDamage()
<<<<<<< HEAD
=======
        bool canJump;
=======
        {

        }*/
>>>>>>> f81c99f4a40d1b267a24e7a95de91ca4496a7302

        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        //constructor
        public Player(Rectangle pRec):base(pRec)
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
        {
        }

        //change colors
        public void colorChange()
        {
            //if player hits enter then 
        }
    }
}
