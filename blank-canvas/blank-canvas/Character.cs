using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
    Class: Character
    Purpose: creates character and all movement required for it
*/

namespace blank_canvas
{
    /// <summary>
    /// A child of the gameObject class that can move around 
    /// </summary>
    public class Character : GameObject
    {
        //states to help govern animation states and which way projectile should fire



        protected enum AnimState
        {
            Idle,
            Walk,
            Jump,
            Hurt,
            Shoot,
            Draw,
        }

        #region variables
        //variables
        protected const float MOVESPEED = 300f;

        protected Rectangle[] collisionBoxes;

        protected Vector2 velocity;
        protected Vector2 acceleration;
        protected Vector2 prevPos;
        protected Vector2 prevAcc;

        // character specific attributes
        protected int health;

        protected Direction direction;
        protected AnimState animState;

        #endregion

        #region constructors
        //constructor
        public Character(Rectangle rectangle) : base(rectangle)
        {
            //NEEDS WORK (Collision box still only has one box)
            collisionBoxes = new Rectangle[1];
            collisionBoxes[0] = rectangle;

            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
            health = 10;

            direction = Direction.Right;
            animState = AnimState.Idle;
        }
        #endregion

        #region properties
        //properties
        public Vector2 PrevPos
        {
            get { return prevPos; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public Rectangle[] CollisionBoxes
        {
            get { return collisionBoxes; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Moves the character based on the previous position, velocity, time step, and acceleration
        /// </summary>
        /// <param name="deltaTime">The time step from the previous update call</param>
        public virtual void UpdatePos(double deltaTime)
        {
            prevPos.X = position.X;
            prevPos.Y = position.Y;
            position.X += (float)(velocity.X * deltaTime + (0.5 * prevAcc.X * Math.Pow(deltaTime, 2.0)));
            position.Y += (float)(velocity.Y * deltaTime + (0.5 * prevAcc.Y * Math.Pow(deltaTime, 2.0)));
            prevAcc = acceleration;
        }

        /// <summary>
        /// Accelerates the character to the right, then caps it
        /// </summary>
        public void MoveRight()
        {
            direction = Direction.Right;
            if (velocity.X < MOVESPEED)
            {
                acceleration += new Vector2(10000, 0);
                direction = Direction.Right;
            }
            else velocity.X = MOVESPEED;
        }

        /// <summary>
        /// Accelerates the character to the left, then caps it
        /// </summary>
        public void MoveLeft()
        {
            direction = Direction.Left;
            if (velocity.X > -MOVESPEED)
            {
                acceleration += new Vector2(-10000, 0);
                direction = Direction.Left;
            }
            else velocity.X = -MOVESPEED;
        }

        /// <summary>
        /// Halts the character to a stop
        /// </summary>
        public void Halt()
        {
            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / 1.2));
            else velocity.X = (float)Math.Ceiling((velocity.X / 1.2));
        }

        /// <summary>
        /// Updates the velocity of a character based on the average acceleration and time step
        /// </summary>
        /// <param name="deltaTime">Time step in miliseconds</param>
        public void UpdateVelocity(double deltaTime)
        {
            velocity.Y += (float)(((prevAcc.Y + acceleration.Y) * deltaTime) / 2);
            velocity.X += (float)(((prevAcc.X + acceleration.X) * deltaTime) / 2);

        }

        //NEEDS WORK
        protected virtual void takeDamage()
        {
            //when hit by projectile

            //when hit by an enemy
        }

        //used to identify what frame to use 
        private void FrameChange()
        {
            if (direction == Direction.Left)
            {
                //change to facing left frame
            }
            if (direction == Direction.Right)
            {
                //change to facing right frame
            }
        }

        //used for testing
        public override string ToString()
        {
            string msg = "Position: " + position.X + ", " + position.Y + "\nVelocity: " + velocity.X + ", " + velocity.Y + "\nAcceleration: " + acceleration.X + ", " + acceleration.Y;
            return msg;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects;
            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(texture, Rectangle, new Rectangle(0,0,width, height),Color.White, 0f, Vector2.Zero, spriteEffects, 1);
        }
        #endregion
    }
}

