using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;



namespace Pong
{

     /// <summary>



    /// This is the main type for your game.



    /// </summary>



    public class Game1 : Game

    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Paddle lefPaddle;
        Paddle rightPaddle;
        Ball ball1;
      

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

      

            lefPaddle = new Paddle(Content.Load<Texture2D>("Paddle"),new Vector2(0, 340), Keys.W, Keys.S);
            rightPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(779, 340), Keys.Up, Keys.Down);      

            ball1 = new Ball(Content.Load<Texture2D>("Ball"), new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5));

            


            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);


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


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }


            ball1.Update();
            lefPaddle.Update();
            rightPaddle.Update();



            if (ball1.BallHitbox.Intersects(lefPaddle.PaddleHitbox))
            {
                ball1.Colission();

            }

            if (ball1.BallHitbox.Intersects(rightPaddle.PaddleHitbox))
            {

                ball1.Colission();

            }

         


            base.Update(gameTime);

        }

        /// <summary>



        /// This is called when the game should draw itself.



        /// </summary>



        /// <param name="gameTime">Provides a snapshot of timing values.</param>



        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            rightPaddle.Draw(spriteBatch);
            lefPaddle.Draw(spriteBatch);

            ball1.Draw(spriteBatch);

            spriteBatch.End();


            // TODO: Add your drawing code here.







            base.Draw(gameTime);



        }






    }





}



