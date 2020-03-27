using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pong
{
    class Score
    {

        private int Score_1, Score_2 = 0;
        private SpriteFont font;
        private Vector2 fontPos;
        private bool pause;
  


        public Score(SpriteFont nummer, Vector2 fontPos, bool pause)
        {
            this.font = nummer;
            this.fontPos = fontPos;
            this.pause = pause;
        }

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



        public void Update(Paddle leftPaddle, Paddle rightPaddle, Ball ball1, GameWindow Window)
        {

            if (ball1.BallPos.X >= 785)
            {
                Score_1++;



                ball1.BallPos = new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5);



                leftPaddle.PaddlePos = new Vector2(0, 340);



                rightPaddle.PaddlePos = new Vector2(779, 340);


            }

            if (ball1.BallPos.X <= 0)

            {

                Score_2++;



                ball1.BallPos = new Vector2((Window.ClientBounds.Width / 2) - 5, (Window.ClientBounds.Height / 2) - 5);



                leftPaddle.PaddlePos = new Vector2(0, 340);



                rightPaddle.PaddlePos = new Vector2(779, 340);

            }

     

    }



        public void Draw(SpriteBatch spriteBatch, GameWindow Window)
        {

            spriteBatch.DrawString(font, Score_1.ToString(), fontPos, Color.Black);
            spriteBatch.DrawString(font, Score_2.ToString(), new Vector2(620, 15), Color.Black);

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

    }



}

