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
<<<<<<< HEAD
        Rectangle[] collisionBoxes;
        Vector2 velocity;
        Vector2 accleration;
        Vector2 force;
        int health;
=======
        protected Rectangle[] collisionBoxes;
        protected Vector2 velocity;
        protected Vector2 acceleration;
        protected Vector2 prevPos;
        protected Vector2 prevAcc;
        protected int health;
        private int paint;
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
        #endregion

        //need more constructors
        #region constructors 
        public Character(Rectangle rectangle) : base(rectangle)
        {
            collisionBoxes = new Rectangle[1];
            collisionBoxes[0] = rectangle;
            velocity = new Vector2(0, 0);
<<<<<<< HEAD
            accleration = new Vector2(0, 0);
            force = new Vector2(0, 0);
            health = 10;
=======
            acceleration = new Vector2(0, 0);
            health = 10;
            paint = 0;
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
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

<<<<<<< HEAD
        #region methods
        public virtual void UpdatePos(float deltaTime)
=======
        public Vector2 Acceleration
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
        {
            get { return acceleration;}
            set { acceleration = value; }
        }

        public Rectangle[] CollisionBoxes
        {
            get { return collisionBoxes; }
        }

<<<<<<< HEAD
            Console.WriteLine("Position: {0}, {1}", position.X, position.Y);
            Console.WriteLine("Velocity: {0}, {1}", velocity.X, velocity.Y);
        }
    

        //moving (takes user input ('A' or 'D') and translates that to movement)
        public void Move(KeyboardState kbState, Player p)
        {
            //if the user hits the right arrow key or D
            if ((kbState.IsKeyDown(Keys.Right)) || (kbState.IsKeyDown(Keys.D)))
                //goes forward
                p.Force = new Vector2(1, 0);

            //if the user hits the left arrow key or A
            if ((kbState.IsKeyDown(Keys.Left)) || (kbState.IsKeyDown(Keys.A)))
                //goes backwards
                p.Force = new Vector2(-1, 0);

            //if the user hits the up arrow key or W
            if ((kbState.IsKeyDown(Keys.Up)) || (kbState.IsKeyDown(Keys.W)))
                //jumps up
                p.Force = new Vector2(0, 2);

            //if the user hits the space bar
            if ((kbState.IsKeyDown(Keys.Space)))
            {
                //shoots projectile
                p.Shoot();
            }
        }

        //accelerating(depending on how long a key ('A' or 'D') is pressed will increase your speed)
        protected virtual void Accel(char input)
=======
        public int Heath
        {
            get { return health; }
            set { health = value; }
        }

        public int Paint
        {
            set { paint = value; }
        }
        #endregion

        #region methods

        public void UpdatePos(double deltaTime)
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
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
        {
            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / 1.2));
            else velocity.X = (float)Math.Ceiling((velocity.X / 1.2));
        }

        public void UpdateVy(double deltaTime)
        {
            velocity.Y += (float)(((prevAcc.Y + acceleration.Y) * deltaTime) / 2);

        }

<<<<<<< HEAD
        //jumping(depending on user input (" "[space bar]), player position goes upwards)
        protected virtual void Jump(string input)
=======
        public void UpdateVx(double deltaTime)
>>>>>>> d909b04d77a90b37b7dc3a4f2fa66a63c36a65e9
        {
            velocity.X += (float)(((prevAcc.X + acceleration.X) * deltaTime) / 2);

        }

        //shooting(depending on user input ('Space Bar'?), a single projectile is fired from the player)
        protected virtual void Shoot()
        {
            //fire right

            //fire left
        }

        //take damage(when colliding with an enemy/projectile, health gets lowered
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
