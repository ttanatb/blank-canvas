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

        Texture2D backgroundTexture;
        Texture2D menuTexture;
        Texture2D pauseTexture;

        // game state
        GameState state;

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
            stageManager = new StageManager(new Camera(GraphicsDevice.Viewport), input);

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

<<<<<<< HEAD
            //loads in all the texture that the stage manager requries
            stageManager.LoadContent(Content, "playerIdle", "enemyNoColor", "tileGround5", "projectile", "orbBase", "orb");
=======
            stageManager.LoadContent(Content, "playerIdle", "enemyNoColor", "tileGround5", "projectile", "orbBase", "orb", "Door");
>>>>>>> 35aed0cc605b6713867426a80e1c89f947662f68

            // gameplay textures
            backgroundTexture = Content.Load<Texture2D>("testBackground");

            // main menu screen
            menuTexture = Content.Load<Texture2D>("mainmenu");

            // pause screen
            pauseTexture = Content.Load<Texture2D>("pausemenu");
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
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;

                case GameState.Gameplay:
                    float deltaTime = gameTime.ElapsedGameTime.Milliseconds;

                    stageManager.Update(deltaTime);
                    UpdateGamePlay();

                    break;

                case GameState.Pause:
                    UpdatePause();
                    break;

                case GameState.EndOfGame:
                    UpdateEndOfGame();
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
                state = GameState.Gameplay;
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
        /// Changes from gameplay to pause
        /// </summary>
        private void UpdatePause()
        {
            if (input.KeyPressed(Keys.Enter))
                state = GameState.Gameplay;
            else if (input.KeyPressed(Keys.Escape))
                state = GameState.EndOfGame;
        }

        private void UpdateEndOfGame()
        {

            Exit();
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);


            switch (state)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
                    break;

                case GameState.Gameplay:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
                    spriteBatch.Draw(backgroundTexture, new Vector2(-500,0), Color.White);
                    stageManager.Draw(spriteBatch);
                    break;

                case GameState.Pause:
                    spriteBatch.Begin();
                    spriteBatch.Draw(pauseTexture, Vector2.Zero, Color.White);
                    break;

                case GameState.EndOfGame:
                    spriteBatch.Begin();

                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
