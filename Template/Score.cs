using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Klass som resettar spelet. Alltså bara skickar tillbaka alla objekt till deras ursprungliga position. Sen har score klassen en timer
/// som lägger en paus efter varje runda på 3 sekunder. 
/// </summary>

namespace Pong
{
    class Score
    {
        //Klassvariabler för poäng egenskaper
        #region Variabler
        private int Score_1, Score_2 = 0;
        private SpriteFont font;
        private Vector2 fontPos;
        private bool pause, newRound, startRound;
        private double timer;
        #endregion

        //Konstruktor som tar poängens egenskaper som parametrar och anger värdet för dess hitbox
        #region Konstruktor
        public Score(SpriteFont nummer, Vector2 fontPos, bool pause)
        {
            this.font = nummer;
            this.fontPos = fontPos;
            this.pause = pause;
        }
        #endregion

        //Get set metoder för att kunna använda poäng egenskaper utanför klassen
        #region Get / set metoder
        public Vector2 FontPos
        {
            get { return fontPos; }
            set { fontPos = value; }

        }

        public bool Pause
        {
            get { return pause; }
            set { pause = value; }

        }

        public double Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public bool NewRound
        {
            get { return newRound; }
            set { newRound = value; }
        }

        public bool StartRound
        {
            get { return startRound; }
            set { startRound = value; }
        }
        #endregion


        //Update metod som "resettar" spelets state tillbaka till ursprung, kollar också ifall bollen är utanför skärmen
        //Har också timer för att pausa mellan ronderna
        #region Update metod
        public void Update(Paddle leftPaddle, Paddle rightPaddle, Ball ball1, GameWindow Window, Bonus box, GameTime gameTime)
        {
            if (ball1.BallPos.X <= 0 || ball1.BallPos.X >= 785)
            {
                newRound = true;
            }

            if (newRound == false)
            {
                startRound = true;
            }

            //ifall bollen gått längre än 785 på x värdet så får spelare 1 poäng och spelet resettas
            if (ball1.BallPos.X >= 785)
            {
                Score_1++;
                box.Intersect = false;

                ball1.BallPos = new Vector2((Window.ClientBounds.Width / 2) - 20, (Window.ClientBounds.Height / 2) - 20);

                leftPaddle.PaddlePos = new Vector2(0, 340);
                rightPaddle.PaddlePos = new Vector2(779, 340);

                leftPaddle.PaddleHitbox = new Rectangle((int)leftPaddle.PaddlePos.X, (int)leftPaddle.PaddlePos.Y, 21, 148);
                rightPaddle.PaddleHitbox = new Rectangle((int)rightPaddle.PaddlePos.X, (int)rightPaddle.PaddlePos.Y, 21, 148);

                box.BonusPos = new Vector2(1000, 1000);

                //Kollar ifall paddeln är liten, isåfall gör den stor igen nästa runda
                leftPaddle.Small = false;
                leftPaddle.Big = true;

                rightPaddle.Small = false;
                rightPaddle.Big = true;

            }

            //ifall bollen gått mindre än 0 på x värdet så får spelare 2 poäng och spelet resettas
            if (ball1.BallPos.X <= 0)
            {
                Score_2++;

                box.Intersect = false;

                ball1.BallPos = new Vector2((Window.ClientBounds.Width / 2) - 20, (Window.ClientBounds.Height / 2) - 20);

                leftPaddle.PaddlePos = new Vector2(0, 340);
                rightPaddle.PaddlePos = new Vector2(779, 340);

                leftPaddle.PaddleHitbox = new Rectangle((int)leftPaddle.PaddlePos.X, (int)leftPaddle.PaddlePos.Y, 21, 148);
                rightPaddle.PaddleHitbox = new Rectangle((int)rightPaddle.PaddlePos.X, (int)rightPaddle.PaddlePos.Y, 21, 148);

                box.BonusPos = new Vector2(1000, 1000);

                //Kollar ifall paddeln är liten, isåfall gör den stor igen nästa runda
                    leftPaddle.Small = false;
                    leftPaddle.Big = true;  

                    rightPaddle.Small = false;
                    rightPaddle.Big = true;

            }

            //Timer som pausar spelet direkt efter en spelare gjort mål, spelet pausas i 3 sekunder
            if (newRound == true)
            {
                timer += gameTime.ElapsedGameTime.TotalSeconds;
                startRound = false;

                if (timer >= 3)
                {
                    timer = 0;
                    newRound = false;
                    startRound = true;
                }
            }


        }
        #endregion


        #region Draw metod
        public void Draw(SpriteBatch spriteBatch, GameWindow Window)
        {
            spriteBatch.DrawString(font, Score_1.ToString(), fontPos, Color.Black);
            spriteBatch.DrawString(font, Score_2.ToString(), new Vector2(620, 15), Color.Black);

            //skriver ut vinnaren på skärmen
            if (Score_1 == 3)
            { 
                spriteBatch.DrawString(font, "Spelare 1 vann!", new Vector2(260, 170), Color.Black);
                pause = true;
            }

            if (Score_2 == 3)
            {
                spriteBatch.DrawString(font, "Spelare 2 vann!", new Vector2(260, 170), Color.Black);
                pause = true;
            }

        }
        #endregion

    }



}

