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
        new const float MOVESPEED = 500f;
        //attributes
        bool canJump;

        Bucket bucket;
        PaletteColor currentColor;

        Projectile projectile;
        //NEEDS WORK: paint attribute

        //properties

        public bool CanJump
        {
            get { return canJump; }
            set { canJump = value; }
        }

        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        public Projectile Projectile
        {
            get { return projectile; }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Rectangle pRec) : base(pRec)
        {
            canJump = false;
            bucket = new Bucket();
            projectile = new Projectile();
            //spriteOrigin = new Vector2(pRec.X, pRec.Y);
        }

        //NEEDS WORK:
        public void colorChange()
        {

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

        //depletes your buckety thing
        public void Shoot()
        {
            Vector2 startingPos = Vector2.Zero;
            if (direction == Direction.Right)
                startingPos = new Vector2(X + width, Y + height / 3 + Projectile.HEIGHT);
            else startingPos = new Vector2(X - Projectile.WIDTH, Y + height / 3 + Projectile.HEIGHT);

            //deal with the color thing with the bucket

            projectile.Shoot(startingPos, direction, currentColor);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (projectile.Active)
                projectile.Draw(spriteBatch);
        }
    }
}
