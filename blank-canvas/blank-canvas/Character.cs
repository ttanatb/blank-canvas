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
        Rectangle[] collisionBoxes;
        Vector2 velocity;
        Vector2 accleration;
        Vector2 force;
        int health;
        #endregion

        //need more constructors
        #region constructors 
        public Character(Rectangle rectangle) : base(rectangle)
        {
            collisionBoxes = new Rectangle[1];
            collisionBoxes[0] = rectangle;
            velocity = new Vector2(0, 0);
            accleration = new Vector2(0, 0);
            force = new Vector2(0, 0);
            health = 10;
        }
        #endregion

        #region properties

        public Vector2 Force
        {
            get { return force; }
            set { force = value; }
        }

        public Rectangle[] CollisionBoxes
        {
            get { return collisionBoxes; }
        }
        #endregion

        #region methods
        public virtual void UpdatePos(float deltaTime)
        {
            Console.WriteLine("@@@@@Delta time: " + deltaTime);
            Console.WriteLine("Force: {0}, {1}", force.X, force.Y);
            Console.WriteLine("Acceleration: {0}, {1}", accleration.X, accleration.Y);

            Vector2 prevAcc = accleration;
            position.X += velocity.X * deltaTime + (0.5f * prevAcc.X * (float)Math.Pow(deltaTime, 2));
            position.Y += velocity.Y * deltaTime + (0.5f * prevAcc.Y * (float)Math.Pow(deltaTime, 2));

            accleration += force;
            force = new Vector2(0, 0);

            Vector2 avgAcc = (prevAcc + accleration) / 2;
            velocity += avgAcc * deltaTime;

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
        {
            //accelerating backwards
            if (input == 'a' || input == 'A')
            {

            }
            //accelerating forwards
            else if (input == 'd' || input == 'D')
            {

            }
        }

        //jumping(depending on user input (" "[space bar]), player position goes upwards)
        protected virtual void Jump(string input)
        {
            //jump up(with space bar)
            if (input == " ")
            {

            }
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
        #endregion

    }
}
