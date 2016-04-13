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
            butt = new Button();

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

            backgroundPosition = new Vector2(-500, 0);
            backgroundTexture = Content.Load<Texture2D>("testBackground");

            
            
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
                    break;
                case GameState.Pause:
                    //UpdatePause();
                    break;
                case GameState.EndOfGame:
                    //UpdateEndOfGame();
                    break;
            }

            base.Update(gameTime);
        }

        // changes from main menu to gameplay
        private void UpdateMainMenu()
        {
            if (butt.isPressed())
                state = GameState.Gameplay;
        }

        // changes from pause to gameplay
        private void UpdatePause()
        {
            if (butt.isPressed())
                state = GameState.Gameplay;
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //for camera
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, stageManager.Camera.Transform);
            spriteBatch.Draw(backgroundTexture, backgroundPosition, Color.White);
            stageManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
