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
        public float velocity = 6;




        public Ball(Texture2D ball)
        {

            this.ball = ball;

        }

        public Texture2D Boll
        {

            get { return ball; }
            set { ball = value; }

        }

        public Rectangle BallHitbox
        {

            get { return new Rectangle((int)ballPos.X, (int)ballPos.Y, 19, 19); }
            set { ballHitbox = value; }

        }


        public void LoadContent(Ball ball1)
        {

            ball1.ballPos.X = 340;
            ball1.ballPos.Y = 600;

        }


        public void Update(Ball ball1, float velocity)
        {

            ball1.ballPos.X += velocity;
            ball1.ballPos.Y += velocity;

            if (ballPos.Y > 1179)
            {
                velocity *= -1;

            }

            if (ballPos.Y < 0)
            {
                velocity *= -1;
            }

            if (ballPos.X <= 0)
            {


            }

            if (ballPos.X > 1200)
            {


            }


            ballHitbox.Location = ballPos.ToPoint();

        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ball, ballPos, Color.White);

        }



    }
}