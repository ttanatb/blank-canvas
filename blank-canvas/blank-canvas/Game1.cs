using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        KeyboardState prevKBState;

        Character player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here
            player = new Character(new Rectangle(20,20,100,100));
            base.Initialize();
            prevKBState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Texture = this.Content.Load<Texture2D>("testChar");
            // TODO: use this.Content to load your game content here
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
            //input handling (begin)
            KeyboardState kbState = Keyboard.GetState();
            float timer = gameTime.ElapsedGameTime.Milliseconds;

            //if the user hits the escape button
            if (kbState.IsKeyDown(Keys.Escape))
                Exit();

            //if the user hits the right arrow key or D
            if ((kbState.IsKeyDown(Keys.Right)) || (kbState.IsKeyDown(Keys.D)))
                //goes forward
                player.Force = new Vector2(1, 0);

            //if the user hits the left arrow key or A
            if ((kbState.IsKeyDown(Keys.Left)) || (kbState.IsKeyDown(Keys.A)))
                //goes backwards
                player.Force = new Vector2(-1, 0);

            //if the user hits the up arrow key or W
            if ((kbState.IsKeyDown(Keys.Up)) || (kbState.IsKeyDown(Keys.W)))
                //jumps up
                player.Force = new Vector2(0, 2);

            //if the user hits the space bar
            if ((kbState.IsKeyDown(Keys.Space)))
            {
                //shoots projectile
                Character(Player).Shoot();
            }

            player.UpdatePos(timer);
            prevKBState = kbState;
            //input handling(end)

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
