using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace blank_canvas
{
    public class Player : Character
    {
        //a child of the character class

        //attributes
        bool canJump;
        bool collisionX;
        bool collisionY;
        Vector2 projectedPos;
        //NEEDS WORK: paint attribute


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


        public override void UpdatePos(double deltaTime)
        {
            //spriteOrigin = new Vector2(width / 2, height / 2);
            collisionX = false;
            collisionY = false;
            base.UpdatePos(deltaTime);
        }

        /// <summary>
        /// Jump
        /// </summary>
        public void Jump()
        {
            velocity.Y = -500f;
            canJump = false;
        }

        public void ReleaseJump()
        {
            if (velocity.Y < -250f)
                velocity.Y = -250f; 
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public override string ToString()
        {
            return collisionY +  base.ToString();
        }
    }
}
