using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/*
    Class: Game1
    Purpose: creates Monogame
*/

namespace blank_canvas
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StageManager stageManager;
        InputManager input;

        // creates variables for textures of background, main menu, and pause screen
        Texture2D backgroundTexture;
        Texture2D menuTexture;
        Texture2D pauseTexture;
        Texture2D gameOverTexture;
        Texture2D levelChangeTexture;

        // creates game state
        GameState state;

        // game state property
        public GameState gameState
        {
            get { return state; }
            set { state = value; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //updates the dimensions of the game screen
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            input = new InputManager();

            //instantializes the initial GameState
            state = GameState.MainMenu;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads in all the texture that the stage manager requries

            // gameplay textures
            backgroundTexture = Content.Load<Texture2D>("testBackground");

            // main menu screen texture
            menuTexture = Content.Load<Texture2D>("mainmenu");

            // pause screen texture
            pauseTexture = Content.Load<Texture2D>("pausemenu");

            // game over screen texture
            gameOverTexture = Content.Load<Texture2D>("gameover");

            //level change screen texture
            levelChangeTexture = Content.Load<Texture2D>("testlevelchange");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary> 
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //updates input
            input.Update();

            //updates the current state
            switch (state)
            {
                // if mainmenu state
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;

                // if gameplay state
                case GameState.Gameplay:

                    // updates the level based on the amount of time that has passed
                    float deltaTime = gameTime.ElapsedGameTime.Milliseconds;
                    try
                    {
                        stageManager.Update(deltaTime);
                    }
                    catch (GameOverException)
                    {
                        state = GameState.EndOfGame;
                    }

                    //  updates the gameplay based on any input to change the state
                    UpdateGamePlay();
                    break;

                // if pause state
                case GameState.Pause:
                    UpdatePause();
                    break;

                // if game over or exit
                case GameState.EndOfGame:
                    UpdateEndOfGame();
                    break;

                // when player changes levels
                case GameState.LevelChange:
                    UpdateLevelChange();
                    break;
            }

            base.Update(gameTime);
        }

        ///<summary>
        ///Changes from main menu to gameplay
        ///</summary>
        private void UpdateMainMenu()
        {
            //currently in Main Menu state
            if (input.KeyPressed(Keys.Space))
            {
                //starts up the stage manager and loads in the content
                stageManager = new StageManager(new Camera(GraphicsDevice.Viewport),input);
                stageManager.LoadContent(Content, "playerIdle", "enemyNoColor", "Tiles-Spritesheet", "projectile", "orbBase", "orb", "Door");
                state = GameState.Gameplay;
            }
        }

        /// <summary>
        /// Changes from gameplay to pause screen
        /// </summary>
        private void UpdateGamePlay()
        {
            if (input.KeysPressed(Keys.Back, Keys.Escape))
                state = GameState.Pause;
        }

        /// <summary>
        /// Changes from pause to gameplay or exit
        /// </summary>
        private void UpdatePause()
        {
            //unpauses
            if (input.KeyPressed(Keys.Enter))
                state = GameState.Gameplay;

            //exits
            else if (input.KeyPressed(Keys.Escape))
                Exit();
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        private void UpdateEndOfGame()
        {
            if (input.KeyPressed(Keys.Enter))
            {
                //unloads all content then loads in what is necessary for the menu states
                Content.Unload();
                LoadContent();
                state = GameState.MainMenu;
            }
        }

        /// <summary>
        /// When end of level reached, end of level screen pops up and level changes
        /// </summary>
        private void UpdateLevelChange()
        {
            // test to see if level change works
            // need to do: to check if end of level reached, changes to next level in the game

            //if (input.KeyPressed(Keys.Enter))
            //{
            //    //unloads all content then loads in what is necessary for the menu states

            //}
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);

            // switches the state based on current GameState
            switch (state)
            {

                // draws the main menu
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
                    break;

                // draws gameplay and focuses the camera
                case GameState.Gameplay:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
                    spriteBatch.Draw(backgroundTexture, new Vector2(-500, 0), Color.White);
                    stageManager.Draw(spriteBatch);
                    break;

                // draws pause screen
                case GameState.Pause:
                    spriteBatch.Begin();
                    spriteBatch.Draw(pauseTexture, Vector2.Zero, Color.White);
                    break;

                // draws end screen, which then exits
                case GameState.EndOfGame:
                    spriteBatch.Begin();
                    spriteBatch.Draw(gameOverTexture, Vector2.Zero, Color.White);
                    break;

                // when player reaches end of level
                case GameState.LevelChange:
                    spriteBatch.Begin();
                    spriteBatch.Draw(levelChangeTexture, Vector2.Zero, Color.White);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
