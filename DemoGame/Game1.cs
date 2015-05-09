using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DemoGame
{
    /// <summary>
    /// Juan Guillermo Gómez
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D mario;
        private Texture2D mundoMario;
        private int xMario = 0;
        private int yMario = 180;
        private int velocidadRecorrido = 10;
        private Vector2 origen;
        private SpriteEffects efecto;

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

            // Carga las imagenes
            mundoMario = Content.Load<Texture2D>("sprites/mundo");
            mario = Content.Load<Texture2D>("sprites/mario");
            origen.X = 0;
            origen.Y = 0;
            efecto = SpriteEffects.None;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();            

            ManejoTeclado(Keyboard.GetState(), gameTime);

            base.Update(gameTime);
        }

        private void ManejoTeclado(KeyboardState KeyState, GameTime gameTime)
        {
            if (KeyState.IsKeyDown(Keys.Right))
            {
                if ((xMario + velocidadRecorrido) <= 600)
                {
                    xMario = xMario + velocidadRecorrido;
                }
                else
                {
                    efecto = SpriteEffects.FlipHorizontally;
                }
            }

            if (KeyState.IsKeyDown(Keys.Left))
            {
                if ((xMario - velocidadRecorrido) > 0)
                {
                    xMario = xMario - velocidadRecorrido;
                }
                else
                {
                    efecto = SpriteEffects.None;
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            // Dibujar el Sprite backgroud
            spriteBatch.Draw(mundoMario, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            // Dibujar el Sprite de mario
            spriteBatch.Draw(mario, new Vector2(xMario, yMario), null, Color.White, 0, origen, 1.0f, efecto, 0f);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
