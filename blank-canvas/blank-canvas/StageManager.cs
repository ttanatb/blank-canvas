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
        Grid grid;

        int level;

        const float GRAVITY = 1200f;
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
            enemies = stageReader.Enemy;
            grid = stageReader.Grid;
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

            grid.LoadContent(content, tileTexture);

            //for printing out test information
            testFont = content.Load<SpriteFont>("Arial_14");
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

            player.ProjectPos(deltaTime);

            //updates the position based on velocity on acceleration
            int xDistanceToTile = Math.Abs(SearchLowestDistanceToTilesX(player));
            Console.WriteLine("Distance to travel: " + player.DistanceToTravel.X + " Distance to tile: " + xDistanceToTile);

            bool canMove = CheckIfCanMoveX(player, xDistanceToTile);

            //player.Acceleration = Vector2.Zero;
            input.Update();
            player.UpdatePosX();

            if (!(player.FacingDirection == Direction.Left && !canMove) && input.KeyDown(Keys.Left) && input.KeyUp(Keys.Right))
                player.MoveLeft();

            else if (!(player.FacingDirection == Direction.Right && !canMove) && input.KeyDown(Keys.Right) && input.KeyUp(Keys.Left))
                player.MoveRight();

            if (input.KeysUp(Keys.Left, Keys.Right))
                player.Halt();

            //player.UpdateVx(deltaTime);
            

            /*
            if (!player.CollisionY)
            {
                player.UpdatePosY();
                player.Acceleration += new Vector2(0, GRAVITY);
                player.UpdateVy(deltaTime);
            }

            if (!player.CollisionX)
            {
                player.UpdatePosX();
                //checks input to change acceleration/velocity
                //checks for input towards the left
                if (input.KeyDown(Keys.Left) && input.KeyUp(Keys.Right))
                    player.MoveLeft();

                //checks for input towards the right
                else if (input.KeyDown(Keys.Right) && input.KeyUp(Keys.Left))
                    player.MoveRight();

                //checks for no input
                else if (input.KeysUp(Keys.Left, Keys.Right))
                    player.Halt();

                player.UpdateVx(deltaTime);
            }
            */

            camera.Update(player);

            //checks for input for jump
            if (player.CanJump && input.KeyPressed(Keys.Space) && (player.Velocity.Y <= 40))
                player.Jump();

            //checks if jump was released early
            if (input.KeyRelease(Keys.Space))
                player.ReleaseJump();
            
        }

        private void NextLevel()
        {
            level++;
            //NEEDS WORK: dump everything
            //NEEDS WORK: load the new variables
        }

        //NEEDS WORK
        private int SearchLowestDistanceToTilesX(Character character)
        {
            int lowestDistance = 99999999;
            Tile[] tiles = new Tile[character.IntersectingRows.Length];

            for (int i = 0; i < character.IntersectingRows.Length; i++)
            {
                if (character.IntersectingRows[i] == -1)
                    continue;

                tiles[i] = grid.SearchNearestTileInRow(character.IntersectingRows[i], (int)character.X/64,character.FacingDirection);

                int xDistanceToChar = (int)tiles[i].DistanceToChar(character).X;
                if (xDistanceToChar < lowestDistance)
                    lowestDistance = xDistanceToChar;
            }

            
            return lowestDistance;
        }

        private bool CheckIfCanMoveX(Player player, int xDistanceToTile)
        {
            if (xDistanceToTile < (int)player.DistanceToTravel.X)
                return true;
            else return false;
        }

        /*
        private Tile[] SearchClosestTilesY(Character character)
        {
            Tile[] tiles = new Tile[character.IntersectingColumns.Length];
            
            for(int i = 0;)
            return tiles;
        }
        */

        private void FixPos(Player player, Tile tile)
        {
            if (player.PrevPos.X + 4 >= tile.Max.X) //prioritizes intersection from the sides
            {
                //player.CollisionX = true;
                player.X = tile.Max.X;
                player.Velocity = new Vector2(0, player.Velocity.Y);
               // player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.X + player.Width - 4 <= tile.X)
            {
                //player.CollisionX = true;
                player.X = tile.X - player.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                //player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.Y + player.Height - 1 <= tile.Y) //intersects from top
            {
                //player.CollisionY = true;
                player.Y = tile.Min.Y - player.Height;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                //player.Acceleration = new Vector2(player.Velocity.X, 0);
                if (player is Player)
                    player.CanJump = true;
            }
            else if (player.PrevPos.Y + player.Height + 1 >= tile.Max.Y)
            {
                player.Y = tile.Max.Y;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                //player.Acceleration = new Vector2(player.Velocity.X, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            grid.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.DrawString(testFont, player.ToString(), new Vector2(player.X , player.Y ), Color.Black);
        }
    }
}
