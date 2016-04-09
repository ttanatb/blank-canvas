using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace blank_canvas
{
    /// <summary>
    /// The child of the character class that the player controls
    /// </summary>
    public class Player : Character
    {
        new const float MOVESPEED = 500f;
        //attributes
        bool canJump;

        Bucket bucket;
        PaletteColor currentColor;
        //NEEDS WORK: paint attribute

        //properties

        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Rectangle pRec) : base(pRec)
        {
            canJump = false;
            bucket = new Bucket();
            //spriteOrigin = new Vector2(pRec.X, pRec.Y);
        }

        //NEEDS WORK:
        public void colorChange()
        {

        }


        /// <summary>
        /// Jumps
        /// </summary>
        public void Jump()
        {
            velocity.Y = -500f;
            canJump = false;
        }

        /// <summary>
        /// Cuts vertical velocity during jump
        /// </summary>
        public void ReleaseJump()
        {
            if (velocity.Y < -250f)
                velocity.Y = -250f; 
        }

        //depletes your buckety thing
        public void Shoot()
        {
            //fire right

        }
    }
}
