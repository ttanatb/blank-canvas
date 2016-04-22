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

        //this shouldn't be here
        //background position
        Vector2 backgroundPosition;
        Texture2D backgroundTexture;
        Texture2D menuTexture;
        Vector2 menuPosition;
        Texture2D pauseTexture;
        

        // game state
        GameState state;

        // creates button
        Button butt;

        public GameState gameState
        {
            get { return state; }
            set { state = value; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            stageManager = new StageManager(new Camera(GraphicsDevice.Viewport), new InputManager());

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

            stageManager.LoadContent(Content, "playerIdle", "enemyNoColor", "tileGround5", "projectile", "orbBase", "orb");

            // gameplay textures
            backgroundPosition = new Vector2(-500, 0);
            backgroundTexture = Content.Load<Texture2D>("testBackground");

            // main menu screen
            menuPosition = new Vector2(0,0);
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
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary> 
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (state)
            {
                case GameState.MainMenu:
                    UpdateMainMenu();
                    break;
                case GameState.Gameplay:
                    float deltaTime = gameTime.ElapsedGameTime.Milliseconds;
                    stageManager.Update(deltaTime);
                    UpdateGamePlay(deltaTime);
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

        // changes from main menu to gameplay
        private void UpdateMainMenu()
        {
            //currently in Main Menu state
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Space))
                state = GameState.Gameplay;
        }

        // changes from gameplay to pause screen
        private void UpdateGamePlay(float deltaTime)
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Back))
                state = GameState.Pause;
        }

        // changes from gameplay to pause
        private void UpdatePause()
        {
            KeyboardState key = Keyboard.GetState();
            //currently in pause state
            if (key.IsKeyDown(Keys.Enter))
                state = GameState.Gameplay;
            if (key.IsKeyDown(Keys.Escape))
                state = GameState.EndOfGame;
        }

        // changes from gameplay to end of game
        // exits until scores are calculated
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            
            switch (state)
            {
                case GameState.MainMenu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(menuTexture, menuPosition, Color.White);
                    break;
                case GameState.Gameplay:
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
                    spriteBatch.Draw(backgroundTexture, backgroundPosition, Color.White);
                    stageManager.Draw(spriteBatch);
                    break;
                case GameState.Pause:
                    spriteBatch.Begin();
                    spriteBatch.Draw(pauseTexture, menuPosition, Color.White);
                    break;
                //case GameState.EndOfGame:
                //    break;
            }
            spriteBatch.End();
            //for camera

        }
    }
}
