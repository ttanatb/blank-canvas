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
        const int SEARCH_RANGE = 400;

        const int WIDTH = 89;
        const int HEIGHT = 137;
        const double FRAME_TIMER = 0.2;

        public const int LEFT_MARGIN = 16;
        public const int RIGHT_MARGIN = 36;
        public const int TOP_MARGIN = 11;
        public const int BOTTOM_MARGIN = 16;


        //attributes
        bool canJump;
        double elapsedTime;

        //for spritesheet
        private int frame; // current frame number

        Bucket bucket;
        PaletteColor currentColor;

        //properties

        public bool CanJump
        {
            get { return canJump; }
            set
            {
                if (animState == AnimState.Jump)
                    animState = AnimState.Idle;
                canJump = value;
            }
        }

        public new Rectangle Rectangle
        {
            get
            {
                if (direction == Direction.Right)
                    return new Rectangle((int)position.X + LEFT_MARGIN, (int)position.Y + TOP_MARGIN, WIDTH - LEFT_MARGIN - RIGHT_MARGIN, HEIGHT - TOP_MARGIN);
                else
                    return new Rectangle((int)position.X + RIGHT_MARGIN, (int)position.Y + TOP_MARGIN, WIDTH - LEFT_MARGIN - RIGHT_MARGIN, HEIGHT - TOP_MARGIN);
            }
        }

        public PaletteColor CurrentColor
        {
            get { return currentColor; }
        }

        public Projectile Projectile
        {
            get { return bucket.Projectile; }
        }

        public Rectangle SearchRectangle
        {
            get
            {
                if (direction == Direction.Right)
                    return new Rectangle(Max.X, (int)position.Y, SEARCH_RANGE, height);
                else return new Rectangle((int)position.X - SEARCH_RANGE, (int)position.Y, SEARCH_RANGE, height);
            }
        }

        public AnimState AnimState
        {
            get { return animState; }
            set
            {
                 frame = 0;
                 animState = value;
            }
        }

        //NEEDS WORK: Paint properties

        //constructor
        public Player(Vector2 position) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            canJump = false;
            bucket = new Bucket();
            currentColor = PaletteColor.Yellow;
            elapsedTime = 0;
        }

        public void DrainEnemy(Enemy enemy)
        {
            if (enemy == null)
                return;
            bucket.AddColor(enemy); 
        }

        public void UpdateInput(InputManager input)
        {
            if (animState == AnimState.Hurt)
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

            if (animState == AnimState.Shoot || animState == AnimState.Drain)
                return;

            if (input.KeyPressed(Keys.C))
            {
                bucket.Shoot(this);
                frame = 0;
                animState = AnimState.Shoot;
            }

            if (input.KeyPressed(Keys.RightShift))
                bucket.SwitchRBY();
            else if (input.KeyPressed(Keys.LeftShift))
                bucket.SwitchYBR();
        }

        public void TakeDamage()
        {
            animState = AnimState.Hurt;
            frame = 0;
            velocity.X -= (float)direction * VERTICAL_KNOCK_BACK;
            velocity.Y -= HORIZONTAL_KNOCK_BACK;
            //playerState = PlayerState.Uncontrollable;
        }
        public void DrainColor(Enemy enemy)
        {
            bucket.AddColor(enemy);
        }

        public void DrainColor(PuzzleOrb orb)
        {
            bucket.AddColor(orb);
        }

        public void UpdateAnim(double deltaTime)
        {
            elapsedTime += deltaTime;
            if (elapsedTime > FRAME_TIMER)
            {
                elapsedTime -= FRAME_TIMER;
                frame++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects;

            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;
            
            switch(animState)
            {
                case AnimState.Idle:
                    if (velocity.Y != 0)
                        goto case AnimState.Jump;
                    animState = AnimState.Idle;
                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle(0 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                    break;
                case AnimState.Walk:
                    if (frame > 3)
                        frame = 0;

                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle(frame * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                    break;
                case AnimState.Shoot:
                    if (frame > 2)
                        goto case AnimState.Idle;

                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle((1 + frame) * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);

                    break;
                case AnimState.Hurt:
                    if (frame > 4)
                        goto case AnimState.Idle;
                    
                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle(frame * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                    break;
                case AnimState.Drain:
                    if (frame > 2)
                        goto case AnimState.Idle;

                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle(frame * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);

                    break;
                case AnimState.Jump:
                    animState = AnimState.Jump;
                    if (velocity.Y < JUMP_VELOCITY / 2)
                        frame = 0;
                    else if(velocity.Y > -JUMP_VELOCITY/2)
                        frame = 2;
                    else frame = 1;

                    spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT), new Rectangle(frame * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), Color.White, 0f, Vector2.Zero, spriteEffects, 1);
                    break;
            }


            //base.Draw(spriteBatch);
            if (Projectile.Active)
                Projectile.Draw(spriteBatch);
        }

        public override string ToString()
        {
            return bucket.ToString();
        }


        #region private methods        

        /// <summary>
        /// Accelerates the character to the right, then caps it
        /// </summary>
        private void MoveRight()
        {
            if (animState == AnimState.Idle)
                animState = AnimState.Walk;

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
            if (animState == AnimState.Idle)
                animState = AnimState.Walk;

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
            if (animState == AnimState.Walk)
                animState = AnimState.Idle;

            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / 1.2));
            else velocity.X = (float)Math.Ceiling((velocity.X / 1.2));
        }

        /// <summary>
        /// Jumps
        /// </summary>
        private void Jump()
        {
            animState = AnimState.Jump;
            frame = 0;
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
