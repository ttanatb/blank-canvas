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

public enum Direction
{
    Left,
    Right,
}

namespace blank_canvas
{
    /// <summary>
    /// A child of the gameObject class that can move around 
    /// </summary>
    public class Character : GameObject
    {
        #region enums

        //enum for anim states?!?!??!
        #endregion

        #region variables
        //variables
        protected Rectangle[] collisionBoxes;

        protected Vector2 velocity;
        //protected Vector2 acceleration;
        protected Vector2 projectedPos;
        protected Vector2 prevPos;
        //protected Vector2 prevAcc;
        protected Vector2 distanceToTravel;

        protected int[] intersectingRows;
        protected int[] intersectingColumns;

        protected Direction direction;
        protected int health;
        #endregion

        #region constructors
        //constructor
        public Character(Rectangle rectangle) : base(rectangle)
        {
            //NEEDS WORK (Collision box still only has one box)
            collisionBoxes = new Rectangle[1];
            collisionBoxes[0] = rectangle;


            direction = Direction.Right;
            intersectingRows = new int[rectangle.Height / 64 + 1];
            intersectingColumns = new int[rectangle.Width / 64 + 1];

            projectedPos = new Vector2(rectangle.X, rectangle.Y);
            distanceToTravel = Vector2.Zero;
            velocity = new Vector2(0, 0);
            //acceleration = new Vector2(0, 0);
            health = 10;
        }
        #endregion

        #region properties
        public Vector2 PrevPos
        {
            get { return prevPos; }
        }

        public Vector2 DistanceToTravel
        {
            get { return distanceToTravel; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        /*public Vector2 Acceleration
        {
            get { return acceleration;}
            set { acceleration = value; }
        }*/

        public int[] IntersectingRows
        {
            get { return intersectingRows; }
        }

        public int[] IntersectingColumns
        {
            get { return intersectingColumns; }
        }

        public Direction FacingDirection
        {
            get { return direction; }
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
        #endregion

        #region Methods

        /// <summary>
        /// Projects out the position of the character based on the previous position, velocity, time step, and acceleration
        /// </summary>
        /// <param name="deltaTime">The time step from the previous update call</param>
        public virtual void ProjectPos(double deltaTime)
        {
            for(int i = 0; i < intersectingRows.Length; i++)
            {
                if ((Y % 64 == 0) && (i == IntersectingRows.Length - 1))
                {
                    intersectingRows[i] = -1;
                    continue;
                }
                intersectingRows[i] = (int)(Y/64) + i;
            }

            for(int i = 0; i < intersectingColumns.Length; i++)
            {
                if ((X % 64 == 0) && (i == IntersectingColumns.Length - 1))
                {
                    intersectingColumns[i] = -1;
                    continue;
                }
                intersectingColumns[i] = (int)(X / 64) + i;
            }

            projectedPos.X = position.X + (float)(velocity.X * deltaTime);// + (0.5 * prevAcc.X * Math.Pow(deltaTime, 2.0)));
            projectedPos.Y = position.Y + (float)(velocity.Y * deltaTime);// + (0.5 * prevAcc.Y * Math.Pow(deltaTime, 2.0)));
            distanceToTravel.X = Math.Abs(projectedPos.X - position.X);
            distanceToTravel.Y = Math.Abs(projectedPos.Y - position.Y);

            //prevAcc = acceleration;
        }

        /// <summary>
        /// Updates the actual position of the character
        /// </summary>
        public void UpdatePosX()
        {
            prevPos.X = position.X;
            position.X = projectedPos.X;
        }

        /// <summary>
        /// Updates the actual position of the character
        /// </summary>
        public void UpdatePosY()
        {
            prevPos.Y = position.Y;
            position.Y = projectedPos.Y;
        }
    
        /// <summary>
        /// Accelerates the character to the right, then caps it
        /// </summary>
        public void MoveRight()
        {
            direction = Direction.Right;
            if (velocity.X < 200)
                velocity.X += 30;
            else velocity.X = 200;
            /*
            if (velocity.X < 200)
                acceleration += new Vector2(10000, 0);
            else velocity.X = 200;
            */
        }

        /// <summary>
        /// Accelerates the character to the left, then caps it
        /// </summary>
        public void MoveLeft()
        {
            direction = Direction.Left;
            if (velocity.X > -200)
                velocity.X -= 30;
            else velocity.X = -200;
            /*
            if (velocity.X > -200)
                acceleration += new Vector2(-10000, 0);
            else velocity.X = -200;
            */
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
        /// Updates the y factor of the velocity of a character based on the average acceleration and time step
        /// </summary>
        /// <param name="deltaTime">Time step in miliseconds</param>
        /*public void UpdateVy(double deltaTime)
        {
            //velocity.Y += (float)(((prevAcc.Y + acceleration.Y) * deltaTime) / 2);
        }

        /// <summary>
        /// Updates the x factor of the velocity of a character based on the average accelearation and time step
        /// </summary>
        /// <param name="deltaTime">Time step in miliseconds</param>
        public void UpdateVx(double deltaTime)
        {
            //velocity.X += (float)(((prevAcc.X + acceleration.X) * deltaTime) / 2);

        }*/

        //NEEDS WORK
        public void Shoot()
        {
            //fire right

            //fire left
        }

        //NEEDS WORK
        protected virtual void takeDamage()
        {
            //when hit by projectile

            //when hit by an enemy
        }

        //used for testing
        public override string ToString()
        {
            string msg = "";
            //msg += "Position: " + position.X + ", " + position.Y + "\nVelocity: " + velocity.X + ", " + velocity.Y + "\nAcceleration: " + acceleration.X + ", " + acceleration.Y;
            msg += "Intersecting Rows: {";
            for(int i = 0; i < intersectingRows.Length; i++)
            {
                msg += intersectingRows[i].ToString();
                if (i < intersectingRows.Length - 1)
                    msg += ", ";
                else msg += "}\n";
            }
            msg += "Intersecting Columns: {";
            for (int i = 0; i < intersectingColumns.Length; i++)
            {
                msg += intersectingColumns[i].ToString();
                if (i < intersectingColumns.Length - 1)
                    msg += ", ";
                else msg += "}\n";
            }
            return msg;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //checks facing direction to flip (or not flip) the direction of the character
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (direction == Direction.Left)
                spriteEffects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(texture, position, new Rectangle(0, 0, Width, Height), Color.White, 0, Vector2.Zero, 1, spriteEffects, 0);

        }
        #endregion
    }
}
