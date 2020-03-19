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
        private Vector2 velocity = new Vector2(4, 4);


        public Ball(Texture2D ball, Vector2 ballPos)
        {

            this.ball = ball;
            this.ballPos = ballPos;

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



        public void Update()
        {

             ballPos.X += velocity.X;
             ballPos.Y += velocity.Y;


            if (ballPos.X <= 0)
                velocity.X *= -1;

            if (ballPos.Y <= 0)
                velocity.Y *= -1;

            if (ballPos.X >= 779)
                velocity.X *= -1;

            if (ballPos.Y >= 480 - 19)
                velocity.Y *= -1;


            ballHitbox.Location = ballPos.ToPoint();

        }


       public void Colission(Paddle leftPaddle, Paddle rightPaddle)
        {

            if(ballHitbox.Intersects(leftPaddle))
            {

               velocity.X *= -1;

            }



        }


        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ball, ballPos, Color.White);

        }



    }
}