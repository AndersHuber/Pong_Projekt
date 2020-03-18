

using System;

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


namespace Pong

{

    class Paddle



    {

        private Texture2D paddle;
        public Vector2 paddlePos;
        private float fart = 5;
        private Rectangle paddleHitbox;







        public Paddle(Texture2D paddle)

        {

            this.paddle = paddle;



        }


        public void LoadContent(Paddle leftPaddle, Paddle rightPaddle)
        {

            leftPaddle.paddlePos.X = 0;
            leftPaddle.paddlePos.Y = 340;

            rightPaddle.paddlePos.X = 1179;
            rightPaddle.paddlePos.Y = 340;


        }

        public Rectangle PaddleHitbox
        {

            get { return new Rectangle((int)paddlePos.X, (int)paddlePos.Y, 21, 148); }
            set { paddleHitbox = value; }

        }



        public void Update(Paddle leftPaddle, Paddle rightPaddle, KeyboardState kstate)
        {


            if (kstate.IsKeyDown(Keys.Up))
            {
                rightPaddle.paddlePos.Y -= fart;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                rightPaddle.paddlePos.Y += fart;
            }

            if (kstate.IsKeyDown(Keys.W))
            {
                leftPaddle.paddlePos.Y -= fart;
            }

            if (kstate.IsKeyDown(Keys.S))
            {
                leftPaddle.paddlePos.Y += fart;
            }

            if (paddlePos.Y <= 0)
            {
                paddlePos.Y = 0;
            }

            if (paddlePos.Y >= 1052)
            {
                paddlePos.Y = 340;
            }

            paddleHitbox.Location = paddlePos.ToPoint();

        }


        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(paddle, paddlePos, Color.White);


        }









    }



}



