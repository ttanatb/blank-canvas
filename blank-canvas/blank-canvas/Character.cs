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
    /// A child of the gameObject class that can move around 
    /// </summary>
    public class Character : GameObject
    {

        #region variables

        protected Vector2 velocity;
        protected Vector2 prevPos;

        protected Direction direction;
        protected AnimState animState;

        #endregion

        #region constructors

        public Character(Rectangle rectangle) : base(rectangle)
        {
            velocity = new Vector2(0, 0);
            prevPos = position;
            direction = Direction.Right;
            animState = AnimState.Idle;
        }

        #endregion

        #region properties

        /// <summary>
        /// Returns the position of the character in the previous frame
        /// </summary>
        public Vector2 PrevPos
        {
            get { return prevPos; }
        }

        /// <summary>
        /// The velocity, sometimes you just gotta go fast
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        /// <summary>
        /// The direction that the character is facing
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        #endregion

        #region methods

        /// <summary>
        /// Moves the character based on the previous position, velocity, and time step
        /// </summary>
        /// <param name="deltaTime">The time step from the previous update call</param>
        public virtual void UpdatePos(double deltaTime)
        {
            prevPos = position;
            position.X += (float)(velocity.X * deltaTime);
            position.Y += (float)(velocity.Y * deltaTime);
        }

        /// <summary>
        /// Used to show the variables when testing
        /// </summary>
        public override string ToString()
        {
            string msg = "Position: " + position.X + ", " + position.Y + "\nVelocity: " + velocity.X + ", " + velocity.Y;
            return msg;

        }

        /// <summary>
        /// Draw method that flips the character correctly
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects;
            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(texture, Rectangle, new Rectangle(0,0,width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
        }
        #endregion
    }
}

