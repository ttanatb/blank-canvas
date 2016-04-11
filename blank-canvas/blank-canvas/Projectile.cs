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
        #region Variables
        public const int WIDTH = 32; // Need to be changed/balanced correctly
        public const int HEIGHT = 32;

        const int HORIZONTAL_OFFSET = 6; //offset up or down
        const int VERTICAL_OFFSET = 4; //offset towards the left or the right

        const float SPEED = 900f;
        const float FADE_DISTANCE = 300f;

        float startingPos;

        bool active;
        Rectangle collisionBox;
        float velocity;


        // unique variables
        PaletteColor projectileColor;
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

        public Projectile() : base(WIDTH, HEIGHT)
        {
            active = false;
            alpha = 255;
            collisionBox = new Rectangle((int)position.X + VERTICAL_OFFSET,
                (int)position.Y + HORIZONTAL_OFFSET,
                WIDTH - VERTICAL_OFFSET,
                HEIGHT - HORIZONTAL_OFFSET);
        }

        #region Constructors
        public void Shoot(Vector2 position, Direction direction, PaletteColor color)
        {
            velocity = SPEED * (int)direction;
            this.position = position;
            startingPos = position.X;
            projectileColor = color;
            active = true;
        }

        private bool CheckValidTarget(GameObject gameObject)
        {
            if (gameObject is PuzzleOrb)
                return true;
            else return false;
        }

        public bool CheckCollision(Rectangle rectangle)
        {
            if (Rectangle.Intersects(rectangle))
            {
                return true;
            }
            else return false;
        }

        public void Update(double deltaTime)
        {
            position.X += (float)(velocity * deltaTime);
            if (Math.Abs(startingPos - position.X) > FADE_DISTANCE)
                Fade();

            if (alpha == 0)
               active = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
                    /*
                    Red = 2,
                    Blue = 3,
                    Yellow = 5,
                    Orange = 10,
                    Green = 15,
                    Purple = 6,
                    Black = 30,
                    White = 1,
                    */
            switch (projectileColor)
            {
                case PaletteColor.Red:
                    spriteBatch.Draw(texture, position, new Color(alpha, 0, 0, alpha));
                    break;
                case PaletteColor.Blue:
                    spriteBatch.Draw(texture, position, new Color(0, 0, alpha, alpha));
                    break;
                case PaletteColor.Yellow:
                    spriteBatch.Draw(texture, position, new Color(alpha, alpha, 0, alpha));
                    break;
            }
        }
        //methods to check intersection

        #endregion


    }
}
