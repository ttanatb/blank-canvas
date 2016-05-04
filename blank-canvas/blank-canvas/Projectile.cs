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
    /// The projectile that is used by the player (yet to be utilized)
    /// </summary>
    class Projectile : GameObject
    {
        #region fields

        public const int WIDTH = 32; 
        public const int HEIGHT = 32;
        
        //offsets from the left & right or top &bottom
        const int LR_MARGIN = 6;    
        const int TB_MARGIN = 4;     

        //speed of the projectile
        const float SPEED = 900f;

        //the distance to fade
        const float FADE_DISTANCE = 300f;

        #endregion

        #region variables

        //starting position
        float startingPos;              

        bool active;   
        float velocity;   

        PaletteColor projectileColor; 

        Bucket bucket;

        #endregion

        #region properties

        /// <summary>
        /// Gets the collision box of the projectile
        /// </summary>
        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X + LR_MARGIN,
                    (int)position.Y + TB_MARGIN,
                    WIDTH - 2 * LR_MARGIN,
                    HEIGHT - 2 * TB_MARGIN);
            }
        }

        /// <summary>
        /// The color of the projectile
        /// </summary>
        public PaletteColor ProjectileColor
        {
            get { return projectileColor; }
        }

        /// <summary>
        /// Wether or not is the projectile active
        /// </summary>
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion

        #region constructors

        /// <summary>
        /// Instantiates the projectile, but keeps it inactive
        /// </summary>
        public Projectile(Bucket bucket) : base(WIDTH, HEIGHT)
        {
            this.bucket = bucket;
            active = false;
            alpha = 255;
        }

        #endregion

        #region methods
        /// <summary>
        /// Activates the projectile from the position, direction, and color
        /// </summary>
        public void Shoot(Vector2 position, Direction direction, PaletteColor color)
        {
            //sets the initial velocity and position
            velocity = SPEED * (int)direction;
            this.position = position;
            startingPos = position.X;

            //sets the color
            projectileColor = color;

            //makes the projectile and sets the alpha value to maximum
            active = true;
            alpha = 255;
        }

        /// <summary>
        /// Checks collision with all of the puzzleOrbs and enemies
        /// </summary>
        /// <param name="puzzleOrbs">An array of puzzle orbs</param>
        /// <param name="enemies">An array of enemies</param>
        public void CheckCollision(PuzzleOrb[] puzzleOrbs, Enemy[] enemies, FinalOrb finalOrb)
        {
            //loops through all the orbs
            foreach (PuzzleOrb orb in puzzleOrbs)
            {
                //checks if it collides with the orb
                if (CheckCollision(orb))
                {
                    //updates the orb
                    orb.Update();
                    return;
                }
            }

            //loops through all the enemies
            foreach (Enemy enemy in enemies)
            {
                //checks if the enemies collide with the orb
                if (CheckCollision(enemy))
                    return;
            }

            if (CheckCollision(finalOrb))
            {
                finalOrb.Update();
                return;

            }
        }

        /// <summary>
        /// Method that checks collision then deals with the changing of color when it collides with the orb
        /// </summary>
        private bool CheckCollision(PuzzleOrb orb)
        { 
            //checks if the puzzle is not completed, then checks if it actually intersects
            if (orb.PuzzleState != PuzzleState.Completed && CollisionBox.Intersects(orb.CollisionBox))
            {
                //checks if the AddColor method that was called was valid (if it actually added a new color)
                bool added = orb.AddColor(this);

                if (added)
                {
                    //sets the projectile to inactive
                    active = false;

                    //uses up the paint from the bucket
                    bucket.UsePaint();
                }

                return true;
            }

            else return false;
        }

        /// <summary>
        /// Method that checks collision then deals with the changing of color when it collides with the orb
        /// </summary>
        private bool CheckCollision(FinalOrb orb)
        {
            //checks if the puzzle is not completed, then checks if it actually intersects
            if (CollisionBox.Intersects(orb.CollisionBox))
            {
                //checks if the AddColor method that was called was valid (if it actually added a new color)
                bool added = orb.AddColor(this);

                if (added)
                {
                    //sets the projectile to inactive
                    active = false;

                    //uses up the paint from the bucket
                    bucket.UsePaint();
                }

                return true;
            }

            else return false;
        }

        /// <summary>
        /// Method that check collision then deals with the changing of color when it collides with the enemy
        /// </summary>
        /// <returns></returns>
        private bool CheckCollision(Enemy enemy)
        {
            //checks if the enemy is active, then checks for collision
            if (!enemy.Active && CollisionBox.Intersects(enemy.Rectangle))
            {
                //enemies that are not active will always be valid targets to be added color
                enemy.AddColor(this);
                active = false;
                bucket.UsePaint();
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Updates the position of the projectile
        /// </summary>
        public void Update(double deltaTime)
        {
            //updates the x position
            position.X += (float)(velocity * deltaTime);

            //fades if distance traveled is far enough
            if (Math.Abs(startingPos - position.X) > FADE_DISTANCE)
                Fade();

            //de-activates when basically almost transparent
            if (alpha < 15)
               active = false;
        }

        /// <summary>
        /// Draw based on its current color
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (projectileColor)
            {
                //the alpha represents the tint that colors the actual projectile   
                case PaletteColor.Red:
                    spriteBatch.Draw(texture, position, new Color(alpha, 0, 0, alpha));
                    break;
                case PaletteColor.Blue:
                    spriteBatch.Draw(texture, position, new Color(0, 0, alpha, alpha));
                    break;
                case PaletteColor.Yellow:
                    spriteBatch.Draw(texture, position, new Color(alpha, alpha, 0, alpha));
                    break;
                default:
                    throw new Exception(); //enemies can only be rby, you can't shoot out non-rby colors
            }
        }


        #endregion
    }
}
