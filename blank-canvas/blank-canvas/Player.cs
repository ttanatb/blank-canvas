using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;


namespace blank_canvas
{
    /// <summary>
    /// The child of the character class that the player controls
    /// </summary>
     class Player : Character
    {
        new const float MOVESPEED = 500f;
        const float VERTICAL_KNOCK_BACK = 300f;
        const float HORIZONTAL_KNOCK_BACK = 300f;
        //attributes
        bool canJump;
        enum PlayerFrameState { Idle, Walk, Run, Shoot, Jump, Hurt};
        PlayerFrameState pfs;

        Bucket bucket;
        PaletteColor currentColor;
        Projectile projectile;
        PlayerState playerState;

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

        public PlayerState State
        {
            get { return playerState; }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Rectangle pRec) : base(pRec)
        {
            canJump = false;
            bucket = new Bucket();
            projectile = new Projectile();
            currentColor = PaletteColor.Yellow;
            playerState = PlayerState.Active;
            //spriteOrigin = new Vector2(pRec.X, pRec.Y);
        }

        //NEEDS WORK:
        public void colorChange()
        {

        }


        public void UpdateInput(InputManager input)
        {
            //checks for input for jump
            if (canJump && input.KeyPressed(Keys.Space) && velocity.Y <= 10)
                Jump();

            //checks if jump was released early
            if (input.KeyRelease(Keys.Space))
                ReleaseJump();

            if (input.KeyDown(Keys.Left) && input.KeyUp(Keys.Right))
                MoveLeft();

            //checks for input towards the right
            else if (input.KeyDown(Keys.Right) && input.KeyUp(Keys.Left))
                MoveRight();

            //checks for no input
            else if (input.KeysUp(Keys.Left, Keys.Right))
                Halt();

            if (input.KeyPressed(Keys.C) && !projectile.Active)
                Shoot();
        }

        /// <summary>
        /// Accelerates the character to the right, then caps it
        /// </summary>
        private void MoveRight()
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
        private void MoveLeft()
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
        private void Halt()
        {
            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / 1.2));
            else velocity.X = (float)Math.Ceiling((velocity.X / 1.2));
        }

        /// <summary>
        /// Jumps
        /// </summary>
        private void Jump()
        {
            velocity.Y = -500f;
            canJump = false;
        }

        /// <summary>
        /// Cuts vertical velocity during jump
        /// </summary>
        private void ReleaseJump()
        {
            if (velocity.Y < -250f)
                velocity.Y = -250f; 
        } 

        //depletes your buckety thing
        private void Shoot()
        {
            Vector2 startingPos = Vector2.Zero;
            if (direction == Direction.Right)
                startingPos = new Vector2(X + width, Y + height / 3 + Projectile.HEIGHT);
            else startingPos = new Vector2(X - Projectile.WIDTH, Y + height / 3 + Projectile.HEIGHT);

            //deal with the color thing with the bucket

            projectile.Shoot(startingPos, direction, currentColor);
        }

        public void TakeDamage()
        {
            velocity.X -= (float)direction * VERTICAL_KNOCK_BACK;
            velocity.Y -= HORIZONTAL_KNOCK_BACK;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (projectile.Active)
            {

                //animation frame states
                if(pfs == PlayerFrameState.Idle)
                {
                    //for standing still
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                if (pfs == PlayerFrameState.Jump)
                {
                    //for jumping
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                if (pfs == PlayerFrameState.Run)
                {
                    //for going faster than walk
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                if (pfs == PlayerFrameState.Shoot)
                {
                    //for firing projectiles
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                if (pfs == PlayerFrameState.Walk)
                {
                    //for inbetween idle speed and running speed
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                if (pfs == PlayerFrameState.Hurt)
                {
                    //for when collisions occur
                    SpriteEffects spriteEffects;
                    if (direction == Direction.Right)
                        spriteEffects = SpriteEffects.None;
                    else spriteEffects = SpriteEffects.FlipHorizontally;
                    //insert frame from spritesheet in line below
                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                }
                projectile.Draw(spriteBatch);
            }
        }


    }
}
