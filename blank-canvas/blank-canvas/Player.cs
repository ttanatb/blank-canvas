using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace blank_canvas
{
    public class Player : Character
    {
        //a child of the character class

        //attributes
        bool canJump;


        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        //constructor
        public Player(Rectangle pRec):base(pRec)
        {
        }

        //change colors
        public void colorChange()
        {
            //if player hits enter then 
        }
    }
}
