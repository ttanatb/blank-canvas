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
        StageReader stageReader;    //reads in the text file and creates the stage
        InputManager input;         //manages input
        Camera camera;              //manages camera movement

        SpriteFont testFont;        //just a test font
        Texture2D testTexture;      //just a test texture

        Player player;              
        Enemy[] enemies;            
        Tile[] tiles;               //tiles to draw (we really don't need tiles, just rectangles)
        Rectangle[] tileCollision;  //tiles to check collision with

        PuzzleOrb puzzleOrb;        //this is for testing
        //the puzzle orb should be linked to a gate

        int level;                  //the level of the stage (may be unnecessary)

        const float GRAVITY = 1200f;    //gravity of the whole thing (kind of unnecessary)
        #endregion

        //constructor
        public StageManager(Camera camera, InputManager inputManager)
        {
            input = new InputManager();         //normal instantialization for input manager
            stageReader = new StageReader();    //may need some tinkering?
            this.camera = camera;               //get camera from game1
            level = 0;                          //sets level at 0

            //read file from the stage reader and get player, enemy, tile data
            stageReader.ReadFile();
            player = stageReader.Player;
            enemies = stageReader.Enemies;
            tiles = stageReader.Tile;
            tileCollision = stageReader.CollisionBoxes;

            //instantialization some for testing
            puzzleOrb = new PuzzleOrb(new Vector2(250, 704), PaletteColor.Yellow);
        }

        //properties
        public Camera Camera
        {
            get { return camera;  }
        }

        #region Load Content
        /// <summary>
        /// Loads in the textures
        /// </summary>
        /// <param name="content">The ContentManager</param>
        /// <param name="playerTexture">The texture for the player</param>
        /// <param name="enemyTexture">The texture for the enemy</param>
        /// <param name="tileTexture">The texture for the tiles</param>
        public void LoadContent(ContentManager content, string playerTexture,
            string enemyTexture, string tileTexture, string projectileTexture,
            string orbBaseTexture, string orbTexture)
        {
            player.Texture = content.Load<Texture2D>(playerTexture);
            foreach (Enemy enemy in enemies)
                enemy.Texture = content.Load<Texture2D>(enemyTexture);

            foreach (Tile tile in tiles)
                tile.Texture = content.Load<Texture2D>(tileTexture);

            player.Projectile.Texture = content.Load<Texture2D>(projectileTexture);

            puzzleOrb.Texture = content.Load<Texture2D>(orbBaseTexture);
            puzzleOrb.OrbTexture = content.Load<Texture2D>(orbTexture);
            testFont = content.Load<SpriteFont>("Arial_14");
            testTexture = content.Load<Texture2D>("testChar");
        }
        #endregion

        /// <summary>
        /// Updates position, takes input to update acceleration, checks collision and fix positions,
        /// and then updates velocity of characters
        /// </summary>
        /// <param name="deltaTime">The amount of miliseconds passed since previous update</param>
        public void Update(float deltaTime)
        {           
            //converts from time to miliseconds
            deltaTime = deltaTime / 1000.0f;

            //updates the position
            player.UpdatePos(deltaTime);

            //updates the camera and input
            camera.Update(player);
            input.Update();

            //updates acceleartion for players (kind of unnecessary because it's always the same)
            player.Acceleration = new Vector2(0, GRAVITY);

            //updates velocity
            player.UpdateVelocity(deltaTime);

            //updates projectile if it is active
            if (player.Projectile.Active)
                player.Projectile.Update(deltaTime);

            foreach (Rectangle r in tileCollision)
            {
                if (player.Projectile.Active)
                    //player.Projectile.CheckCollision(r);
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

            if (input.KeyPressed(Keys.C) && ! player.Projectile.Active)
            {
                player.Shoot();
                //puzzleOrb.ChangeColor();
            }

            puzzleOrb.Update();
        }

        private void NextLevel()
        {
            level++;
            //NEEDS WORK: dump everything
            //NEEDS WORK: load the new variables
        }

        /// <summary>
        /// Fixes the position of the player based on the rectangle it intersected with
        /// </summary>
        private void FixPos(Player player, Rectangle rect)
        {
            if (player.PrevPos.X + 4 >= rect.X + rect.Width) //prioritizes intersection from the sides
            {
                player.X = rect.X + rect.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                return;
            }
            else if (player.PrevPos.X + player.Width - 4 <= rect.X)
            {
                player.X = rect.X - player.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                return;
            }
            else if (player.PrevPos.Y + player.Height - 1 <= rect.Y) //intersects from top
            {
                player.Y = rect.Y - player.Height + 1;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.CanJump = true;
            }
            else if (player.PrevPos.Y + player.Height + 1 >= rect.Y + rect.Height)
            {
                player.Y = rect.Y + rect.Height ;
                player.Velocity = new Vector2(player.Velocity.X, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
                tile.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);

            puzzleOrb.Draw(spriteBatch);
            spriteBatch.DrawString(testFont, player.ToString(), new Vector2(player.X , player.Y - 50 ), Color.Black);
        }
    }
}
