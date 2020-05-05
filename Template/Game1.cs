using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;


namespace Pong
{
    /// <summary>
    /// Det är här jag laddar in alla mina objekt och variabler. Sedan använder jag de i respektive metoder.
    /// </summary>

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Objekt för klasserna
        #region Objekt och variabler
        private Paddle leftPaddle, rightPaddle;

        private Score score1;

        private Ball ball1;

        private Background backGround1, backGround2, backGround3, backGround4, backGround5, backGroundFont, backGroundFont2;

        private Meny menuScreen;

        private MouseState state;
        private Point mousePos;

        //Timers som hanterar global tid men också tid för bonusen
        private double globalTimer;
        private double coinTimer = 1;

        private Song backGroundSound;

        private Bonus box;

        //Lista som lagrar coin objekt
        private List<Coin> coins = new List<Coin>();

        private Random random = new Random();
        #endregion


        //Konstruktorn för main klassen
        #region Konstruktor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            //Ifall musen ska vara synlig
            IsMouseVisible = true;

            //Ifall musiken ska repeteras eller spelas en gång
            MediaPlayer.IsRepeating = true;
        }
        #endregion

        /// <summary>
        /// Tillåter spelet att utföra den initialisering den behöver innan spelet startar. Det är här den kan fråga efter alla nödvändiga tjänster och ladda ner-
        /// all icke-grafiskt innehåll. Att kalla på base.Initialize kommer att räkna upp alla komponenter och initialisera de också.
        /// </summary>

        protected override void Initialize()
        {
          base.Initialize();
        }

        /// <summary>
        /// Loadcontent kallas på en gång varje gång du startar spelet. Här har jag anget alla värden till mina objekt. De värdena ändras sedan i Update metoden.
        /// </summary>

            //all spelgrafik laddas här
        #region Loadcontent där all spelgrafik laddas
        protected override void LoadContent()
        {       
            //Ger objekten värden, en Texture2D, positioner samt input för tangentbord
            leftPaddle = new Paddle(Content.Load<Texture2D>("Paddle"),new Vector2(0, 340), new Rectangle(0, 340, 21, 148), Keys.W, Keys.S, false);
            rightPaddle = new Paddle(Content.Load<Texture2D>("Paddle"), new Vector2(779, 340), new Rectangle(779, 340, 21, 148), Keys.Up, Keys.Down, false);

            //Bakgrunder
            #region
            backGround1 = new Background(Content.Load<Texture2D>("Menu/Background"), new Vector2(150, 200), new Rectangle(150, 200, 80, 80), false);

            backGround2 = new Background(Content.Load<Texture2D>("Menu/BackGround2"), new Vector2(250, 200), new Rectangle(250, 200, 80, 80), false);

            backGround3 = new Background(Content.Load<Texture2D>("Menu/BackGround3"), new Vector2(350, 200), new Rectangle(350, 200, 80, 80), false);

            backGround4 = new Background(Content.Load<Texture2D>("Menu/BackGround4"), new Vector2(450, 200), new Rectangle(450, 200, 80, 80), false);

            backGround5 = new Background(Content.Load<Texture2D>("Menu/BackGround5"), new Vector2(550, 200), new Rectangle(550, 200, 80, 80), false);
            #endregion

            //Bakgrunds text
            #region
            backGroundFont = new Background(Content.Load<SpriteFont>("SpriteFont/Choose"));

            backGroundFont2 = new Background(Content.Load<SpriteFont>("SpriteFont/Choose"));
            #endregion

            //Poäng objekt
            score1 = new Score(Content.Load<SpriteFont>("SpriteFont/Score1"), new Vector2(150, 15), false);

            //Boll objekt
            ball1 = new Ball(Content.Load<Texture2D>("Ball"), new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5));

            //Menyskärmens bakgrund
            menuScreen = new Meny(Content.Load<Texture2D>("Menu/Menu"), new Vector2(0, 0), true);

            //Bonus objektet - utseende och aktivering
            box = new Bonus(Content.Load<Texture2D>("Bonus/Bonus"), new Vector2(1000, 1000), new Rectangle(1000, 1000, 50, 50), false);

            //bakgrunds musik, spelas direkt när spelet börjar
            backGroundSound = Content.Load<Song>("Music/337056__hmmm101__pixel-song-16 (1) (1)");
            MediaPlayer.Play(backGroundSound);

            //Coin objektet
            coins.Add(new Coin(Content.Load<Texture2D>("Coin"), new Vector2(random.Next(0, 780), 0)));

            // Create a new SpriteBatch, which can be used to draw textures
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        #endregion

        /// <summary>
        /// Här sker spelets updatering av allt. Mynten rör sig genom att deras position uppdateras ständigt genom en metod i coin klassen som update loopar igenom med en foreach loop
        ///  Här i update går man bara igenom  listan som mynten sitter i och addar nya mynt med en timer som går av varje sekund. Bakgrundsklassen anropas också och update
        ///  kollar kollision mellan mus och respektive bakgrundsbild genom en bool. Kolission mellan paddel, boll, bonus kollas också genom att Update anropar respektive klass.
        ///  Här i Update kollas också vilken paddel som har träffat bollen och ifall bollen träffat bonusen med bools. Ifall båda boolsen är sanna så anropar update paddel klassen
        ///  och gör den paddel som har sin bool false mindre.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        #region Update metod för main
        protected override void Update(GameTime gameTime)
        {
            //Ifall menyn är borta, börja räkna tiden
            if (menuScreen.GameState == false)
            {
                globalTimer += gameTime.ElapsedGameTime.TotalSeconds;
            }

            //För varje sekund så addas ett nytt coin objekt till coin listan, samtidigt som timern resettar sig själv
            if (menuScreen.GameState == true)
            {
                coinTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (coinTimer <= 0)
                {
                    coins.Add(new Coin(Content.Load<Texture2D>("Coin"), new Vector2(random.Next(0, 780), 0)));
                    coinTimer = 1;
                }

                if (coins.Count > 20)
                {
                    coins.RemoveAt(19);
                }

                foreach (Coin coin in coins)
                {
                    coin.Update();
                }
            }
                //Musens position på skärmen
                state = Mouse.GetState();
                mousePos = new Point(state.X, state.Y);

                //Ifall musens position är innanför respektive bakgrundsbild och man vänsterklickar, så väljs bakgrund
                //Intersect håller koll på vilken bakgrund det är
                #region
                if (state.LeftButton == ButtonState.Pressed && backGround1.BackGroundHitbox.Contains(mousePos))
                {
                    backGround1.Intersect = true;
                }

                if (state.LeftButton == ButtonState.Pressed && backGround2.BackGroundHitbox.Contains(mousePos))
                {
                    backGround2.Intersect = true;
                }

                if (state.LeftButton == ButtonState.Pressed && backGround3.BackGroundHitbox.Contains(mousePos))
                {
                    backGround3.Intersect = true;
                }

                if (state.LeftButton == ButtonState.Pressed && backGround4.BackGroundHitbox.Contains(mousePos))
                {
                    backGround4.Intersect = true;
                }

                if (state.LeftButton == ButtonState.Pressed && backGround5.BackGroundHitbox.Contains(mousePos))
                {
                    backGround5.Intersect = true;
                }
                #endregion

                //Kollar ifall man tryckt på en bakgrund, och ifall musen är innanför objektets hitbox
                menuScreen.Update(backGround1, backGround2, backGround3, backGround4, backGround5);

                if (score1.Pause == false && globalTimer > 8)
                {
                    //Kollar poängen
                    score1.Update(leftPaddle, rightPaddle, ball1, Window, box, gameTime);

                    //Paddlarnas rörelse och bollens rörelse ifall spelet är igång
                    if (score1.StartRound == true)
                    {
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

                    //Kollar vilken paddel som knuffade bollen till bonusen, så att man kan avgöra vilken sida som träffade den
                    //Ifall höger paddel träffade bonusen med bollen blir vänster paddel mindre och tvärtom
                    #region
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
                        rightPaddle.PaddleHitbox = new Rectangle((int)rightPaddle.PaddlePos.X, (int)rightPaddle.PaddlePos.Y, 21, 80);
                        box.Intersect = false;
                        rightPaddle.Small = true;
                        rightPaddle.Big = false;
                    }

                    if (rightPaddle.Intersect == true && box.Intersect == true)
                    {
                        leftPaddle.PaddleHitbox = new Rectangle((int)leftPaddle.PaddlePos.X, (int)leftPaddle.PaddlePos.Y, 21, 80);
                        box.Intersect = false;
                        leftPaddle.Small = true;
                        leftPaddle.Big = false;
                    }
                    #endregion

                }

                base.Update(gameTime);
        }
        #endregion

        /// <summary>
        /// Här ritas alla textures ut vid olika tidpunkter. Först ritas menyskärmen ut, spelet kollar ifall den är false så ritas loading screenen ut.
        /// Efter 5 sekunder ritas själva spelet ut. Draw metoden i main tar metoder från de andra klasserna, alltså ritas iget ut direkt ifrån main.
        /// Penga regnet loopas bara igenom här och ritar ut alla mynt som finns i listan, det är update som rör på mynten. 
        /// </summary>

        //Här ritas all spelgrafik ut
        #region Draw metod för main
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            menuScreen.Draw(spriteBatch);

            //Ritar ut alla väljbara bakgrunder ifall menyskärmen är aktiv
            #region
            if (menuScreen.GameState == true)
            {
                menuScreen.Draw(spriteBatch);

                //Ritar ut alla mynt som finns i listan
                for(int i = 0; i < coins.Count; i++)
                {
                   coins[i].Draw(spriteBatch);
                }

                backGround1.Draw(spriteBatch);

                backGround2.Draw(spriteBatch);

                backGround3.Draw(spriteBatch);

                backGround4.Draw(spriteBatch);

                backGround5.Draw(spriteBatch);

                backGroundFont.Draw2(spriteBatch);
            }
            #endregion

            //Ritar ut loading screen i 5 sekunder
            if(globalTimer > 0 && globalTimer < 5)
            {
                backGroundFont2.Draw3(spriteBatch);
            }

            //Ifall menyskärmen inte visas och ifall blobala timern är större än 5, gör följande
            if (menuScreen.GameState == false && globalTimer > 5)
            {
                //Ifall intersect är ett nummer från 1 till 5, rita ut respektive nummers bakgrundsbild
                #region
                if (backGround1.Intersect)
                {
                    backGround1.Draw4(spriteBatch);
                }

                if (backGround2.Intersect)
                {
                    backGround2.Draw4(spriteBatch);
                }

                if (backGround3.Intersect)
                {
                    backGround3.Draw4(spriteBatch);
                }

                if (backGround4.Intersect)
                {
                    backGround4.Draw4(spriteBatch);
                }

                if (backGround5.Intersect)
                {
                    backGround5.Draw4(spriteBatch);
                }
                #endregion

                //Ritar ut paddlar, boll och bonus
                #region
                rightPaddle.Draw(spriteBatch);
                leftPaddle.Draw(spriteBatch);

                ball1.Draw(spriteBatch);

                score1.Draw(spriteBatch, Window);

                box.Draw(spriteBatch);
                #endregion

            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
        #endregion


    }




}