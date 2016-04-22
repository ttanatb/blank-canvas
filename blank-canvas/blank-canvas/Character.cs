﻿using System;
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

        #region variables
        //variables
        protected const float MAX_MOVE_SPEED = 300f;

        protected Rectangle[] collisionBoxes;

        protected Vector2 velocity;
        protected Vector2 prevPos;

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
            //acceleration = new Vector2(0, 0);
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

        /*
        public Vector2 Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
        */

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

        #region methods

        /// <summary>
        /// Moves the character based on the previous position, velocity, time step, and acceleration
        /// </summary>
        /// <param name="deltaTime">The time step from the previous update call</param>
        public virtual void UpdatePos(double deltaTime)
        {
            prevPos.X = position.X;
            prevPos.Y = position.Y;
            position.X += (float)(velocity.X * deltaTime);// + (0.5 * prevAcc.X * Math.Pow(deltaTime, 2.0)));
            position.Y += (float)(velocity.Y * deltaTime);// + (0.5 * prevAcc.Y * Math.Pow(deltaTime, 2.0)));
            //prevAcc = acceleration;
        }

        /// <summary>
        /// Updates the velocity of a character based on the average acceleration and time step
        /// </summary>
        /// <param name="deltaTime">Time step in miliseconds</param>
        /*public void UpdateVelocity(double deltaTime)
        {
            velocity.Y += (float)(((prevAcc.Y + acceleration.Y) * deltaTime) / 2);
            velocity.X += (float)(((prevAcc.X + acceleration.X) * deltaTime) / 2);

        }*/

        //used for testing
        public override string ToString()
        {
            string msg = "Position: " + position.X + ", " + position.Y + "\nVelocity: " + velocity.X + ", " + velocity.Y;// + "\nAcceleration: " + acceleration.X + ", " + acceleration.Y;
            return msg;

        }

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

