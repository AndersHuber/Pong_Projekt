using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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

        private Background backGround1, backGround2, backGround3, backGround4, backGround5, backGroundFont, backGroundFont2;

        private Meny menuScreen;

        private MouseState state;
        private Point mousePos;

        private double globalTimer;

        private Song backGroundSound;

        private Bonus box;

        

        public Game1()
        {


            graphics = new GraphicsDeviceManager(this);


            Content.RootDirectory = "Content";

            IsMouseVisible = true;

            MediaPlayer.IsRepeating = true;
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
            leftPaddle = new Paddle(Content.Load<Texture2D>("Paddle"),new Vector2(0, 340), new Rectangle(0, 340, 21, 148), Keys.W, Keys.S, false);
            rightPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(779, 340), new Rectangle(779, 340, 21, 148), Keys.Up, Keys.Down, false);

            //Bakgrunder

            backGround1 = new Background(Content.Load<Texture2D>("Menu/Background"), new Vector2(150, 200), new Rectangle(150, 200, 80, 80), 0);

            backGround2 = new Background(Content.Load<Texture2D>("Menu/BackGround2"), new Vector2(250, 200), new Rectangle(250, 200, 80, 80), 0);

            backGround3 = new Background(Content.Load<Texture2D>("Menu/BackGround3"), new Vector2(350, 200), new Rectangle(350, 200, 80, 80), 0);

            backGround4 = new Background(Content.Load<Texture2D>("Menu/BackGround4"), new Vector2(450, 200), new Rectangle(450, 200, 80, 80), 0);

            backGround5 = new Background(Content.Load<Texture2D>("Menu/BackGround5"), new Vector2(550, 200), new Rectangle(550, 200, 80, 80), 0);

            backGroundFont = new Background(Content.Load<SpriteFont>("SpriteFont/Choose"));

            backGroundFont2 = new Background(Content.Load<SpriteFont>("SpriteFont/Choose"));

            score1 = new Score(Content.Load<SpriteFont>("SpriteFont/Score1"), new Vector2(150, 15), false);

            ball1 = new Ball(Content.Load<Texture2D>("Ball"), new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5));

            menuScreen = new Meny(Content.Load<Texture2D>("Menu/Menu"), new Vector2(0, 0), true);

            box = new Bonus(Content.Load<Texture2D>("Bonus/Bonus"), new Vector2(200, 200), new Rectangle(200, 100, 50, 50), false);

            // Create a new SpriteBatch, which can be used to draw textures.

            backGroundSound = Content.Load<Song>("Music/337056__hmmm101__pixel-song-16 (1) (1)");
            MediaPlayer.Play(backGroundSound);

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

            if (menuScreen.GameState == false)
            {
                globalTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }

                state = Mouse.GetState();
                mousePos = new Point(state.X, state.Y);

                    if (state.LeftButton == ButtonState.Pressed && backGround1.BackGroundHitbox.Contains(mousePos))
                    {
                        backGround1.Intersect = 1;
                    }

                    if (state.LeftButton == ButtonState.Pressed && backGround2.BackGroundHitbox.Contains(mousePos))
                    {
                        backGround2.Intersect = 2;
                    }

                    if (state.LeftButton == ButtonState.Pressed && backGround3.BackGroundHitbox.Contains(mousePos))
                    {
                        backGround3.Intersect = 3;
                    }

                    if (state.LeftButton == ButtonState.Pressed && backGround4.BackGroundHitbox.Contains(mousePos))
                    {
                        backGround4.Intersect = 4;
                    }

                    if (state.LeftButton == ButtonState.Pressed && backGround5.BackGroundHitbox.Contains(mousePos))
                    {
                        backGround5.Intersect = 5;
                    }

            menuScreen.Update(backGround1, backGround2, backGround3, backGround4, backGround5);

            if (score1.Pause == false && globalTimer > 8)
            {

                score1.Update(leftPaddle, rightPaddle, ball1, Window, box, gameTime);

                if (score1.StartRound == true)
                {
                    //Update metoder som ständigt anropas från respektive klasser
                    ball1.Update();
                    leftPaddle.Update(box);
                    rightPaddle.Update(box);
                }


                //Bollens kolission med paddlarna, anropar boll klassen ifall true
                if (ball1.BallHitbox.Intersects(leftPaddle.PaddleHitbox))
                {
                    ball1.Colission();

                }

                if (ball1.BallHitbox.Intersects(rightPaddle.PaddleHitbox))
                {

                    ball1.Colission();

                }

                    box.Update(ball1, gameTime);

                if (ball1.BallHitbox.Intersects(leftPaddle.PaddleHitbox))
                {
                    leftPaddle.Intersect = true;
                    rightPaddle.Intersect = false;
                }

                if (ball1.BallHitbox.Intersects(rightPaddle.PaddleHitbox))
                {
                    rightPaddle.Intersect = true;
                    leftPaddle.Intersect = false;
                }

                if (leftPaddle.Intersect == true && box.Intersect == true)
                {
                    rightPaddle.PaddleHitbox = new Rectangle((int)rightPaddle.PaddlePos.X, (int)rightPaddle.PaddlePos.Y, 21, 79);
                    box.Intersect = false;
                }

                if (rightPaddle.Intersect == true && box.Intersect == true)
                {
                    leftPaddle.PaddleHitbox = new Rectangle((int)leftPaddle.PaddlePos.X, (int)leftPaddle.PaddlePos.Y, 21, 79);
                    box.Intersect = false;
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

            menuScreen.Draw(spriteBatch);

            if (menuScreen.GameState == true)
            {
                menuScreen.Draw(spriteBatch);

                backGround1.Draw(spriteBatch);

                backGround2.Draw(spriteBatch);

                backGround3.Draw(spriteBatch);

                backGround4.Draw(spriteBatch);

                backGround5.Draw(spriteBatch);

                backGroundFont.Draw2(spriteBatch);

            }

            if(globalTimer > 0 && globalTimer < 5)
            {
                backGroundFont2.Draw3(spriteBatch);
            }


                if (menuScreen.GameState == false && globalTimer > 5)
                {
                    if (backGround1.Intersect == 1)
                    {
                        backGround1 = new Background(Content.Load<Texture2D>("Menu/Background"), new Vector2(0, 0), new Rectangle(0, 0, 800, 500), 1);
                        backGround1.Draw(spriteBatch);
                    }

                    if (backGround2.Intersect == 2)
                    {
                        backGround2 = new Background(Content.Load<Texture2D>("Menu/BackGround2"), new Vector2(0, 0), new Rectangle(0, 0, 800, 500), 2);
                        backGround2.Draw(spriteBatch);
                    }

                    if (backGround3.Intersect == 3)
                    {
                        backGround3 = new Background(Content.Load<Texture2D>("Menu/BackGround3"), new Vector2(0, 0), new Rectangle(0, 0, 800, 500), 3);
                        backGround3.Draw(spriteBatch);

                    }

                    if (backGround4.Intersect == 4)
                    {
                        backGround4 = new Background(Content.Load<Texture2D>("Menu/BackGround4"), new Vector2(0, 0), new Rectangle(0, 0, 800, 500), 4);
                        backGround4.Draw(spriteBatch);

                    }

                    if (backGround5.Intersect == 5)
                    {
                        backGround5 = new Background(Content.Load<Texture2D>("Menu/BackGround5"), new Vector2(0, 0), new Rectangle(0, 0, 800, 500), 5);
                        backGround5.Draw(spriteBatch);

                    }

                //Ritar ut paddlar och boll
                rightPaddle.Draw(spriteBatch);
                leftPaddle.Draw(spriteBatch);

                ball1.Draw(spriteBatch);

                score1.Draw(spriteBatch, Window);

                box.Draw(spriteBatch);

            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }


    }




}