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
    public class Projectile : GameObject
    {
        #region Fields
        public const int WIDTH = 32;        
        public const int HEIGHT = 32;

        const int HORIZONTAL_OFFSET = 6;    //offset top or bottom
        const int VERTICAL_OFFSET = 4;      //offset left or right

        const float SPEED = 900f;
        const float FADE_DISTANCE = 300f;
        #endregion

        #region Variables
        float startingPos;              //starting position (for distnc)

        bool active;                    //if projectile is active
        Rectangle collisionBox;         //collision box of projectile
        float velocity;                 //velocity, you know what that is

        PaletteColor projectileColor;   //current color of the projectile
        #endregion

        #region Properties
        public Rectangle CollisionBox
        {
            get { return collisionBox; }
        }

        public PaletteColor ProjectileColor
        {
            get { return projectileColor; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion

        /// <summary>
        /// Instantiates the projectile, but keeps it inactive
        /// </summary>
        public Projectile() : base(WIDTH, HEIGHT)
        {
            active = false;
            alpha = 255;
            collisionBox = new Rectangle((int)position.X + VERTICAL_OFFSET,
                (int)position.Y + HORIZONTAL_OFFSET,
                WIDTH - 2 * VERTICAL_OFFSET,
                HEIGHT - 2 * HORIZONTAL_OFFSET);
        }

        #region Constructors
        /// <summary>
        /// Activates the projectile from the position, direction, and color
        /// </summary>
        public void Shoot(Vector2 position, Direction direction, PaletteColor color)
        {
            velocity = SPEED * (int)direction;
            this.position = position;
            startingPos = position.X;
            projectileColor = color;
            active = true;
            alpha = 255;
        }

        public bool CheckCollision(GameObject gameObj)
        {
            if (Rectangle.Intersects(gameObj.Rectangle))
            {
                if (gameObj is PuzzleOrb)
                {
                    PuzzleOrb puzzleOrb = (PuzzleOrb)gameObj;
                    puzzleOrb.AddColor(this);
                }

                active = false;
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

            //de-activates when transparent
            if (alpha == 0)
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
                    throw new Exception(); //you can't shoot out non-rby colors
            }
        }
        #endregion
    }
}
