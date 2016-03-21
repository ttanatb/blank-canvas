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

        //attributes
        bool canJump;
        bool collisionX;    //checks if there was collision in the X-coordinate
        bool collisionY;    //checks if there was collision in the y-coordinate
        //NEEDS WORK: paint attribute

        //properties

        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        public bool CollisionX
        {
            get { return collisionX; }
            set { collisionX = value; }
        }

        public bool CollisionY
        {
            get { return collisionY; }
            set { collisionY = value; }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Rectangle pRec) : base(pRec)
        {
            canJump = false;
            collisionX = false;
            collisionY = false;
            //spriteOrigin = new Vector2(pRec.X, pRec.Y);
        }

        //NEEDS WORK:
        public void colorChange()
        {
        }


        /// <summary>
        /// Sets up the collision variables in addition to projecting the position
        /// </summary>
        /// <param name="deltaTime">The timestep in miliseconds</param>
        public override void ProjectPos(double deltaTime)
        {
            collisionX = false;
            collisionY = false;
            base.ProjectPos(deltaTime);
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

        //used for testing
        public override string ToString()
        {
            return collisionY +  base.ToString();
        }
    }
}
