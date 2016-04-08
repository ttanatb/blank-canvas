using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace blank_canvas
{
    /// <summary>
    /// The StageManager manages the gameplay loop
    /// </summary>
    class StageManager
    {
        #region variables
        StageReader stageReader;
        InputManager input;
        Camera camera;
        SpriteFont testFont;

        Player player;
        Enemy[] enemies;
        Tile[] tiles;
        Rectangle[] tileCollision;

        int level;

        const float GRAVITY = 1200f;
        Texture2D testTexture;
        #endregion

        //constructor
        public StageManager(Camera camera, InputManager inputManager)
        {
            input = new InputManager();
            stageReader = new StageReader();
            this.camera = camera;
            level = 0;

            stageReader.ReadFile();
            player = stageReader.Player;
            enemies = stageReader.Enemies;
            tiles = stageReader.Tile;
            tileCollision = stageReader.CollisionBoxes;
        }

        //property
        public Camera Camera
        {
            get { return camera;  }
        }

        /// <summary>
        /// Loads in the textures
        /// </summary>
        /// <param name="content">The ContentManager</param>
        /// <param name="playerTexture">The texture for the player</param>
        /// <param name="enemyTexture">The texture for the enemy</param>
        /// <param name="tileTexture">The texture for the tiles</param>
        public void LoadContent(ContentManager content, string playerTexture,
            string enemyTexture, string tileTexture)
        {
            player.Texture = content.Load<Texture2D>(playerTexture);
            foreach (Enemy enemy in enemies)
                enemy.Texture = content.Load<Texture2D>(enemyTexture);

            foreach (Tile tile in tiles)
                tile.Texture = content.Load<Texture2D>(tileTexture);

            //for printing out test information
            testFont = content.Load<SpriteFont>("Arial_14");
            testTexture = content.Load<Texture2D>("testChar");
        }

        /// <summary>
        /// Updates position, takes input to update acceleration, checks collision and fix positions,
        /// and then updates velocity of characters
        /// </summary>
        /// <param name="deltaTime">The amount of miliseconds passed since previous update</param>
        public void Update(double deltaTime)
        {           
            //converts from time to miliseconds
            deltaTime = deltaTime / 1000.0;

            player.UpdatePos(deltaTime);
            camera.Update(player);

            //updates acceleartion for players
            player.Acceleration = Vector2.Zero;
            input.Update();


            player.Acceleration += new Vector2(0, GRAVITY);
            player.UpdateVelocity(deltaTime);

            foreach (Rectangle r in tileCollision)
            {
                if (r.Intersects(player.Rectangle))
                    FixPos(player, r);
            }
            

            //checks for input for jump
            if (player.CanJump && input.KeyPressed(Keys.Space) && player.Velocity.Y <= 10)
                player.Jump();

            //checks if jump was released early
            if (input.KeyRelease(Keys.Space))
                player.ReleaseJump();

            if (input.KeyDown(Keys.Left) && input.KeyUp(Keys.Right))
                player.MoveLeft();

            //checks for input towards the right
            else if (input.KeyDown(Keys.Right) && input.KeyUp(Keys.Left))
                player.MoveRight();

            //checks for no input
            else if (input.KeysUp(Keys.Left, Keys.Right))
                player.Halt();

        }

        private void NextLevel()
        {
            level++;
            //NEEDS WORK: dump everything
            //NEEDS WORK: load the new variables
        }

        //NEEDS WORK
        private Tile[] SearchClosestTiles(Character character)
        {
            Tile[] tiles = new Tile[4];
            //NEEDS WORK: search the tiles in the 4 directions
            return tiles;
        }

        private void FixPos(Player player, Rectangle rect)
        {
            if (player.PrevPos.X + 4 >= rect.X + rect.Width) //prioritizes intersection from the sides
            {
                player.CollisionX = true;
                player.X = rect.X + rect.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.X + player.Width - 4 <= rect.X)
            {
                player.CollisionX = true;
                player.X = rect.X - player.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.Y + player.Height - 1 <= rect.Y) //intersects from top
            {
                player.CollisionY = true;
                player.Y = rect.Y - player.Height + 1;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.Acceleration = new Vector2(player.Velocity.X, 0);
                player.CanJump = true;
            }
            else if (player.PrevPos.Y + player.Height + 1 >= rect.Y + rect.Height)
            {
                player.Y = rect.Y + rect.Height ;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.Acceleration = new Vector2(player.Velocity.X, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            foreach (Rectangle rect in tileCollision)
                //spriteBatch.Draw(testTexture, rect, Color.Red);
            
            spriteBatch.DrawString(testFont, player.ToString(), new Vector2(player.X , player.Y ), Color.Black);
        }
    }
}
