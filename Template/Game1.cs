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

        //Skapar objekten för paddlar och boll
        private Paddle leftPaddle;
        private Paddle rightPaddle;

        private Score score1;

        private Ball ball1;

        private Background backGround1, backGround2, backGround3, backGround4, backGround5;

        private Meny menuScreen;


        public Game1()
        {


            graphics = new GraphicsDeviceManager(this);


            Content.RootDirectory = "Content";

            IsMouseVisible = true;

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

      
            //Ger objekten värden, en Texture2D, positioner samt input för tangentbord
            leftPaddle = new Paddle(Content.Load<Texture2D>("Paddle"),new Vector2(0, 340), Keys.W, Keys.S);
            rightPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(779, 340), Keys.Up, Keys.Down);

            //Bakgrunder

            backGround1 = new Background(Content.Load<Texture2D>("Menu/Background"), new Vector2(220, 200), new Rectangle(220, 200, 40, 40), false);

            backGround2 = new Background(Content.Load<Texture2D>("Menu/BackGround2"), new Vector2(300, 200), new Rectangle(300, 200, 40, 40), false);

            backGround3 = new Background(Content.Load<Texture2D>("Menu/BackGround3"), new Vector2(380, 200), new Rectangle(380, 200, 40, 40), false);

            backGround4 = new Background(Content.Load<Texture2D>("Menu/BackGround4"), new Vector2(460, 200), new Rectangle(460, 200, 40, 40), false);

            backGround5 = new Background(Content.Load<Texture2D>("Menu/BackGround5"), new Vector2(540, 200), new Rectangle(540, 200, 40, 40), false);

            score1 = new Score(Content.Load<SpriteFont>("SpriteFont/Score1"), new Vector2(150, 15), false);

            ball1 = new Ball(Content.Load<Texture2D>("Ball"), new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5));

            menuScreen = new Meny(Content.Load<Texture2D>("Menu/Menu"), new Vector2(0, 0), true);

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

            backGround1.Update();
            menuScreen.Update(backGround1);

            if (menuScreen.GameState == false)
            {             
                if (score1.Pause == false)
                {
                    score1.Update(leftPaddle, rightPaddle, ball1, Window);

                    //Update metoder som ständigt anropas från respektive klasser
                    ball1.Update();
                    leftPaddle.Update();
                    rightPaddle.Update();


                    //Bollens kolission med paddlarna, anropar boll klassen ifall true
                    if (ball1.BallHitbox.Intersects(leftPaddle.PaddleHitbox))
                    {
                        ball1.Colission();

                    }

                    if (ball1.BallHitbox.Intersects(rightPaddle.PaddleHitbox))
                    {

                        ball1.Colission();

                    }

                }

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

            if (menuScreen.GameState == true)
            {
                menuScreen.Draw(spriteBatch);

                backGround1.Draw(spriteBatch);

                backGround2.Draw(spriteBatch);

                backGround3.Draw(spriteBatch);

                backGround4.Draw(spriteBatch);

                backGround5.Draw(spriteBatch);
            }

            if (menuScreen.GameState == false)
            {
                backGround1.Draw(spriteBatch);

                //Ritar ut paddlar och boll
                rightPaddle.Draw(spriteBatch);
                leftPaddle.Draw(spriteBatch);

                ball1.Draw(spriteBatch);

                score1.Draw(spriteBatch, Window);

            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }


    }




}