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
        const float JUMP_VELOCITY = -600f;
        //NEEDS WORK: paint attribute

        //properties

        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Rectangle pRec) : base(pRec)
        {
            canJump = false;
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
            base.ProjectPos(deltaTime);
        }

        /// <summary>
        /// Jumps
        /// </summary>
        public void Jump()
        {
            velocity.Y = JUMP_VELOCITY;
            canJump = false;
        }

        /// <summary>
        /// Cuts vertical velocity during jump
        /// </summary>
        public void ReleaseJump()
        {
            if (velocity.Y < JUMP_VELOCITY/2)
                velocity.Y = JUMP_VELOCITY/2; 
        }

        //used for testing
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
