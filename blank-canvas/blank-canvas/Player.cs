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
        const float JUMP_VELOCITY = -800f;



        //attributes
        bool canJump;
        enum PlayerFrameState { Idle, Walk, Shoot, Jump, Hurt};
        PlayerFrameState pfs;

        //for spritesheet
        private Texture2D image; // image to display
        private int frame; // current frame number
        //identify particulars of frame size when spritesheet arrives
        private Point frameSize; // width and height of image
        private int rows, cols; // defines how spritesheet is laid out
        private Point currentFrame; // location of current frame on spritesheet

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

        public void DrainEnemy(Enemy enemy)
        {
            if (enemy == null)
                return;
            bucket.AddColor(enemy); 
        }

        public void UpdateInput(InputManager input)
        {
            if (playerState == PlayerState.Uncontrollable)
                return;

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
        public void TakeDamage()
        {
            velocity.X -= (float)direction * VERTICAL_KNOCK_BACK;
            velocity.Y -= HORIZONTAL_KNOCK_BACK;
            //playerState = PlayerState.Uncontrollable;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects;

            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(texture, Rectangle, new Rectangle(0, 0, width, height), Color.White, 0f, Vector2.Zero, spriteEffects, 1);

            //base.Draw(spriteBatch);
            if (projectile.Active)
                projectile.Draw(spriteBatch);
        }


        #region private methods        
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
            velocity.Y = JUMP_VELOCITY;
            canJump = false;
        }

        /// <summary>
        /// Cuts vertical velocity during jump
        /// </summary>
        private void ReleaseJump()
        {
            if (velocity.Y < JUMP_VELOCITY / 2)
                velocity.Y = JUMP_VELOCITY / 2; 
        } 

        //depletes your buckety thing
        private void Shoot()
        {
            Vector2 startingPos;// = Vector2.Zero;
            if (direction == Direction.Right)
                startingPos = new Vector2(X + width, Y + height / 3 + Projectile.HEIGHT);
            else startingPos = new Vector2(X - Projectile.WIDTH, Y + height / 3 + Projectile.HEIGHT);

            //deal with the color thing with the bucket

            projectile.Shoot(startingPos, direction, currentColor);
        }

        #endregion

        /*
        public override void Draw(SpriteBatch spriteBatch)
        {
            //animation frame states
            if (pfs == PlayerFrameState.Idle)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;
            }
            if (pfs == PlayerFrameState.Jump)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;

            }
            if (pfs == PlayerFrameState.Run)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;
                
            }
            if (pfs == PlayerFrameState.Shoot)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;
                
            }
            if (pfs == PlayerFrameState.Walk)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;
                
            }
            if (pfs == PlayerFrameState.Hurt)
            {
                //calculate correct frame size once spritesheet arrives
                /*
                currentFrame.X = 0;
                currentFrame.Y = 0;
                
            }

            //for when collisions occur
            SpriteEffects spriteEffects;
            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            //insert frame from spritesheet in line below
            spriteBatch.Draw(texture, Rectangle, new Rectangle(currentFrame.X, currentFrame.Y, frameSize.X, frameSize.Y), Color.White, 0f, Vector2.Zero, spriteEffects, 1);

            if (projectile.Active)
                projectile.Draw(spriteBatch);
        }
        */
    }
}
