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
        #region fields
        //movespeed of the player
        const float MAX_MOVE_SPEED = 500f;
        const float MOVE_SPEED = 40f;
        const float HALT_RATE = 1.18f;

        //knock back from taking damage
        const float VERTICAL_KNOCK_BACK = 300f;
        const float HORIZONTAL_KNOCK_BACK = 300f;

        //initial jump velocity
        const float JUMP_VELOCITY = -800f;

        //search range to drain color
        const int SEARCH_RANGE = 400;

        //width and height for the rectangle
        const int WIDTH = 89;
        const int HEIGHT = 137;

        //timer to change frame
        const double FRAME_TIMER = 0.2;

        //margin for collision box
        public const int LEFT_MARGIN = 16;
        public const int RIGHT_MARGIN = 36;
        public const int TOP_MARGIN = 11;
        public const int BOTTOM_MARGIN = 16;

        //maximum health
        const int MAX_HEALTH = 3;
        const int FADE_DECREMENT = 30;
        #endregion

        #region variables

        bool canJump;
        Bucket bucket;

        //used for animation
        double elapsedTime;
        int frame;

        int health;

        #endregion

        #region properties

        /// <summary>
        /// Wether or not can the player jump
        /// </summary>
        public bool CanJump
        {
            get { return canJump; }
            set
            {
                //makes sure the animation transitions when the character lands
                if (animState == AnimState.Jump)
                    animState = AnimState.Idle;

                //sets the value
                canJump = value;
            }
        }

        /// <summary>
        /// The collision box based on the margins
        /// </summary>
        public Rectangle CollisionBox
        {
            get
            {
                //collision box when direction is right
                if (direction == Direction.Right)
                    return new Rectangle((int)position.X + LEFT_MARGIN, 
                        (int)position.Y + TOP_MARGIN, 
                        WIDTH - LEFT_MARGIN - RIGHT_MARGIN, 
                        HEIGHT - TOP_MARGIN);

                //collision box when direction is left
                else return new Rectangle((int)position.X + RIGHT_MARGIN, 
                        (int)position.Y + TOP_MARGIN, 
                        WIDTH - LEFT_MARGIN - RIGHT_MARGIN, 
                        HEIGHT - TOP_MARGIN);
            }
        }

        /// <summary>
        /// Returns the projectile of the player's bucket
        /// </summary>
        public Projectile Projectile
        {
            get { return bucket.Projectile; }
        }

        /// <summary>
        /// Returns the rectangle that is used to DrainColor
        /// </summary>
        public Rectangle SearchRectangle
        {
            get
            {
                //search box when direction is right
                if (direction == Direction.Right)
                    return new Rectangle(Max.X, (int)Y, SEARCH_RANGE, height);

                //search box when direction is left
                else return new Rectangle((int)position.X - SEARCH_RANGE, (int)position.Y, SEARCH_RANGE, height);
            }
        }

        /// <summary>
        /// The current animation state
        /// </summary>
        public AnimState AnimState
        {
            get { return animState; }
            set
            {
                //sets the frame back to the initial frame
                frame = 0;
                animState = value;
            }
        }

        #endregion

        #region constructor

        public Player(Vector2 position) : base(new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT))
        {
            canJump = false;
            bucket = new Bucket();
            elapsedTime = 0;
            health = MAX_HEALTH;
        }

        #endregion

        #region methods

        /// <summary>
        /// Updates the input based on the input manager
        /// </summary>
        /// <param name="input">The input manager</param>
        public void UpdateInput(InputManager input)
        {
            //if the player is in its hurt animation, return
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

            //shifts through the primary colors
            if (input.KeyPressed(Keys.RightShift))
                bucket.SwitchRBY();
            else if (input.KeyPressed(Keys.LeftShift))
                bucket.SwitchYBR();

            //the player shouldn't be able to shoot or drain if she is shooting or draining
            if (animState == AnimState.Shoot || animState == AnimState.Drain)
                return;

            //shoots
            if (input.KeyPressed(Keys.C))
            {
                bucket.Shoot(this);
                frame = 0;
                animState = AnimState.Shoot;
            }
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
            if (velocity.X < MAX_MOVE_SPEED)
            {
                velocity += new Vector2(MOVE_SPEED, 0);
                //acceleration += new Vector2(10000, 0);
                direction = Direction.Right;
            }
            else velocity.X = MAX_MOVE_SPEED;
        }

        /// <summary>
        /// Accelerates the character to the left, then caps it
        /// </summary>
        private void MoveLeft()
        {
            if (animState == AnimState.Idle)
                animState = AnimState.Walk;

            direction = Direction.Left;
            if (velocity.X > -MAX_MOVE_SPEED)
            {
                velocity += new Vector2(-MOVE_SPEED, 0);
                direction = Direction.Left;
            }
            else velocity.X = -MAX_MOVE_SPEED;
        }

        /// <summary>
        /// Halts the character to a stop
        /// </summary>
        private void Halt()
        {
            if (animState == AnimState.Walk)
                animState = AnimState.Idle;

            if (velocity.X > 0)
                velocity.X = (float)Math.Floor((velocity.X / HALT_RATE));
            else velocity.X = (float)Math.Ceiling((velocity.X / HALT_RATE));
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

        /// <summary>
        /// Reduces the health of the player when collided with an enemy
        /// </summary>
        /// <param name="enemy">The enemy that the player collided with</param>
        public void TakeDamage(Enemy enemy)
        {
            //If the player is already in the hurting animation, return
            if (animState == AnimState.Hurt)
                return;

            //reduces the health
            health--;

            //set initial frame and animation state
            frame = 0;
            animState = AnimState.Hurt;

            //determine direction after collision
            if (enemy.Center.X - Center.X > 0)
                direction = Direction.Right;
            else direction = Direction.Left;

            //sets the player up the knocks the player back
            position.Y -= 1;
            velocity.Y = -HORIZONTAL_KNOCK_BACK;
            velocity.X = -(float)direction * VERTICAL_KNOCK_BACK;
        }

        /// <summary>
        /// Drains the color from an enemy
        /// </summary>
        public void DrainColor(Enemy enemy)
        {
            bucket.AddColor(enemy);
        }

        /// <summary>
        /// Drains the color from a puzzle orb
        /// </summary>
        public void DrainColor(PuzzleOrb orb)
        {
            bucket.AddColor(orb);
        }

        /// <summary>
        /// Updates the frame of animation
        /// </summary>
        /// <param name="deltaTime">Time elapsed since last update</param>
        public void UpdateAnim(double deltaTime)
        {
            //increases total elapsed time
            elapsedTime += deltaTime;

            //determines if frame should increment
            if (elapsedTime > FRAME_TIMER)
            {
                elapsedTime -= FRAME_TIMER;
                frame++;
            }
        }

        /// <summary>
        /// Draw the player as well as deal with the animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //sprite effects used for flipping the character based on the direction
            SpriteEffects spriteEffects;

            if (direction == Direction.Right)
                spriteEffects = SpriteEffects.None;
            else spriteEffects = SpriteEffects.FlipHorizontally;

            //the transparency of the sprite
            int a = alpha - (MAX_HEALTH - health) * FADE_DECREMENT;
            Color color = new Color(a, a, a, a);
            
            switch(animState)
            {
                case AnimState.Idle:
                    //checks if the plater is moving vertically
                    if (velocity.Y != 0)
                    {
                        animState = AnimState.Jump;
                        goto case AnimState.Jump;
                    }

                    //makes sure that the animation state is idle
                    animState = AnimState.Idle;

                    spriteBatch.Draw(texture, Rectangle, new Rectangle(0 * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;

                case AnimState.Walk:
                    //loops the animation
                    if (frame > 3)
                        frame = 0;

                    spriteBatch.Draw(texture, Rectangle, new Rectangle(frame * WIDTH, 1 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;

                case AnimState.Shoot:
                    //goes to idle animation after shooting animation is done
                    if (frame > 2)
                    {
                        animState = AnimState.Idle;
                        goto case AnimState.Idle;
                    }

                    spriteBatch.Draw(texture, Rectangle, new Rectangle((1 + frame) * WIDTH, 0 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;

                case AnimState.Hurt:
                    //changes animation after hurting animation is done
                    if (frame > 4)
                    {
                        animState = AnimState.Idle;
                        goto case AnimState.Idle;
                    }

                    spriteBatch.Draw(texture, Rectangle, new Rectangle(frame * WIDTH, 2 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;

                case AnimState.Drain:
                    //changes animation after draining animation is done
                    if (frame > 2)
                    {
                        animState = AnimState.Idle;
                        goto case AnimState.Idle;
                    }

                    spriteBatch.Draw(texture, Rectangle, new Rectangle(frame * WIDTH, 3 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;

                case AnimState.Jump:
                    //determines the frame from the vertical velocity
                    if (velocity.Y < JUMP_VELOCITY / 2)
                        frame = 0;
                    else if(velocity.Y > -JUMP_VELOCITY/2)
                        frame = 2;
                    else frame = 1;

                    spriteBatch.Draw(texture, Rectangle, new Rectangle(frame * WIDTH, 4 * HEIGHT, WIDTH, HEIGHT), color, 0f, Vector2.Zero, spriteEffects, 1);
                    break;
            }

            //draws the projectile if it is active
            if (Projectile.Active)
                Projectile.Draw(spriteBatch);
        }

        //used to test
        public override string ToString()
        {
            string msg = base.ToString();
            if (health > 0)
                msg += "\nHealth: " + health;
            else msg += "You should be dead now, but I haven't implemented that yet";
            return msg;
        }

        #endregion

    }
}
