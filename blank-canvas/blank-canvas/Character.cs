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
    public class Character : GameObject
    {
        #region variables
        protected Rectangle[] collisionBoxes;
        protected Vector2 velocity;
        protected Vector2 acceleration;
        protected Vector2 prevPos;
        protected Vector2 prevAcc;
        protected int health;

        #endregion

        #region constructors
        public Character(Rectangle rectangle) : base(rectangle)
        {
            //NEEDS WORK
            collisionBoxes = new Rectangle[1];
            collisionBoxes[0] = rectangle;

            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
            health = 10;

            acceleration = new Vector2(0, 0);
            health = 10;
        }
        #endregion

        #region properties
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
            get { return acceleration;}
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
        #endregion

        #region Methods

        public virtual void UpdatePos(double deltaTime)
        {
            prevPos = new Vector2(position.X, position.Y);
            position.X += (float)(velocity.X * deltaTime + (0.5 * prevAcc.X * Math.Pow(deltaTime, 2.0)));
            position.Y += (float)(velocity.Y * deltaTime + (0.5 * prevAcc.Y * Math.Pow(deltaTime, 2.0)));
            prevAcc = acceleration;
        }
    
        public void MoveRight()
        {
            if (velocity.X < 200)
                acceleration += new Vector2(10000, 0);
            else velocity.X = 200;
        }

        public void MoveLeft()
        {
            if (velocity.X > -200)
                acceleration += new Vector2(-10000, 0);
            else velocity.X = -200;
        }

        public void Halt()
        {
            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / 1.2));
            else velocity.X = (float)Math.Ceiling((velocity.X / 1.2));
        }

        public void UpdateVy(double deltaTime)
        {
            velocity.Y += (float)(((prevAcc.Y + acceleration.Y) * deltaTime) / 2);

        }

        public void UpdateVx(double deltaTime)
        {
            velocity.X += (float)(((prevAcc.X + acceleration.X) * deltaTime) / 2);

        }

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

        public override string ToString()
        {
            string msg = "Position: " + position.X + ", " + position.Y + "\nVelocity: " + velocity.X + ", " + velocity.Y + "\nAcceleration: " + acceleration.X + ", " + acceleration.Y;
            return msg;

        }
        #endregion
    }
}
