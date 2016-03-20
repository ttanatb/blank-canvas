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
    /// The StageManager starts with the stageReader. The stageReader will determine the tiles needed and the enemies to instantiate
    /// </summary>
    class StageManager
    {
        #region variables
        StageReader stageReader;
        InputManager input;
        Camera camera;

        Player player;
        Enemy[] enemies;
        Tile[,] tiles;

        int level;

        const float GRAVITY = 1200f;
        #endregion

        public StageManager(Camera camera, InputManager inputManager)
        {
            input = new InputManager();
            stageReader = new StageReader();
            this.camera = camera;
            level = 0;

            //NEEDS WORK: calls construct stage method(?)
            //NEEDS WORK: instantiate the player based on starting position
            //NEEDS WORK: instantiate all teh enemies needed    

            player = new Player(new Rectangle(20, 20, 113, 160));
            enemies = new Enemy[0];
            tiles = new Tile[0,0];


        }

        public Camera Camera
        {
            get { return camera;  }
        }

        public void LoadContent(ContentManager content, string playerTexture,
            string enemyTexture, string tileTexture)
        {
            player.Texture = content.Load<Texture2D>(playerTexture);
            foreach (Enemy enemy in enemies)
                enemy.Texture = content.Load<Texture2D>(enemyTexture);

            foreach (Tile tile in tiles)
                tile.Texture = content.Load<Texture2D>(tileTexture);
        }

        /// <summary>
        /// Updates position, takes input to update acceleration, checks collision and fix positions,
        /// and then updates velocity of characters
        /// </summary>
        /// <param name="deltaTime">The amount of miliseconds passed since previous update</param>
        public void Update(double deltaTime)
        {            //converts from time to miliseconds
            deltaTime = deltaTime / 1000.0;

            //updates the position based on velocity on acceleration
            player.UpdatePos(deltaTime);
            camera.Update(player);

            foreach (Enemy enemy in enemies)
                enemy.UpdatePos(deltaTime);

            //updates acceleartion for players
            player.Acceleration = Vector2.Zero;
            player.Acceleration += new Vector2(0, GRAVITY);

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

            //checks for input for jump
            if (player.CanJump && input.KeyPressed(Keys.Space) && (player.Velocity.Y <= 0))
                player.Jump();

            //checks if jump was released early
            if (input.KeyRelease(Keys.Space))
                player.ReleaseJump();
            
            //NEEDS WORK: updates enemy movement

            //search for nearest tile of each character (left,right,top,bottom)
            /*
            foreach (Tile t in SearchClosestTiles(player))
            {
                if (CheckCollision(player, t))
                    FixPos(player, t);
            }
            */

            //updates velocity if collision didn't occur
            if (!player.CollisionX)
                player.UpdateVx(deltaTime);

            if (!player.CollisionY)
                player.UpdateVy(deltaTime);
            
            //updates velocity for enemies
            foreach (Enemy enemy in enemies)
            {
                enemy.UpdateVx(deltaTime);
                enemy.UpdateVy(deltaTime);
            }
            
        }

        private void NextLevel()
        {
            level++;
            //NEEDS WORK: dump everything
            //NEEDS WORK: load the new variables
        }

        /// <summary>
        /// Checks collision with each of the character's collision boxes
        /// </summary>
        /// <param name="character">Character to check collision with</param>
        /// <returns>Returns true if there is collision</returns>
        public bool CheckCollision(Character character, Tile tile)
        {
            foreach (Rectangle r in character.CollisionBoxes)
            {
                if (r.Intersects(tile.Rectangle))
                    return true;
            }
            return false;
        }

        private Tile[] SearchClosestTiles(Character character)
        {
            Tile[] tiles = new Tile[4];
            //NEEDS WORK: search the tiles in the 4 directions
            return tiles;
        }

        private void FixPos(Player player, Tile tile)
        {
            if (player.PrevPos.X + 4 >= tile.Max.X) //prioritizes intersection from the sides
            {
                player.CollisionX = true;
                player.X = tile.Max.X;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.X + player.Width - 4 <= tile.X)
            {
                player.CollisionX = true;
                player.X = tile.X - player.Width;
                player.Velocity = new Vector2(0, player.Velocity.Y);
                player.Acceleration = new Vector2(0, player.Acceleration.Y);
                return;
            }
            else if (player.PrevPos.Y + player.Height - 1 <= tile.Y) //intersects from top
            {
                player.CollisionY = true;
                player.Y = tile.Min.Y - player.Height;
                player.Velocity = new Vector2(player.Velocity.X, 0);
                player.Acceleration = new Vector2(player.Velocity.X, 0);
                if (player is Player)
                    player.CanJump = true;
            }
            else if (player.PrevPos.Y + player.Height + 1 >= tile.Max.Y)
            {
                player.CollisionY = true;
                player.Y = tile.Max.Y;
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
        }
    }
}
