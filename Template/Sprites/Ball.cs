using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Graphics;

namespace Pong

{
    class Ball
    {

        private Texture2D ball;
        private Vector2 ballPos;
        private Rectangle ballHitbox;
        private Vector2 velocity;
        public Random random = new Random();
        private int tal;
        private int score1;
        private int score2;

        public Ball(Texture2D ball, Vector2 ballPos, int score1, int score2)
        {

            this.ball = ball;
            this.ballPos = ballPos;
            this.score1 = score1;
            this.score2 = score2;

            tal = random.Next(1, 3);

            if (tal == 1)
            {
                velocity = new Vector2(-4, -4);
            }

            if (tal == 2)
            {
                velocity = new Vector2(4, 4);
            }

            if (score1 == 3)
            {

            }

            if (score2 == 3)
            {


            }

        }

        public Texture2D Boll
        {

            get { return ball; }
            set { ball = value; }

        }

        public Vector2 BallPos
        {

            get { return ballPos; }
            set { ballPos = value; }

        }

        public Rectangle BallHitbox
        {

            get { return new Rectangle((int)ballPos.X, (int)ballPos.Y, 19, 19); }
            set { ballHitbox = value; }

        }



        public void Colission()
        {
            velocity.X *= -1;

        }


        public void Update()
        {

             ballPos.X += velocity.X;
             ballPos.Y += velocity.Y;
             


            if (ballPos.X <= 0)
            {
                velocity.X *= -1;
            }

            if (ballPos.Y <= 0)
            {
                velocity.Y *= -1;
            }

            if (ballPos.X >= 779)
            {
                velocity.X *= -1;
            }

            if (ballPos.Y >= 480 - 19)
            {
                velocity.Y *= -1;
            }

            //Score
            if (ballPos.X < 0)
            {
                score1++;
            }

            if (ballPos.X > 785)
            {
                score2++;
            }

        

            ballHitbox.Location = ballPos.ToPoint();

        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ball, ballPos, Color.White);

        }



    }
}