

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
        private Vector2 paddlePos;
        private float fart = 5;
        private Rectangle paddleHitbox;
        private KeyboardState kstate;
        private Keys Up, Down;


        public Paddle(Texture2D paddel, Vector2 paddlePos, Rectangle paddleHitbox, Keys Up, Keys Down)
        {
            paddle = paddel;
            this.paddlePos = paddlePos;
            this.Up = Up;
            this.Down = Down;
            this.paddleHitbox = paddleHitbox;
        }


        public Rectangle PaddleHitbox
        {

            get { return paddleHitbox; }
            set { paddleHitbox = value; }

        }

        public Vector2 PaddlePos
        {

            get { return paddlePos; }
            set { paddlePos = value; }

        }



        public void Update()
        {

            kstate= Keyboard.GetState();

            if (kstate.IsKeyDown(Up))
            {
                paddlePos.Y -= fart;
            }

            if (kstate.IsKeyDown(Down))
            {
                paddlePos.Y += fart;
            }   
          
            if(paddlePos.Y < 0)
            {

                paddlePos.Y = 0;

            }

            if(paddlePos.Y > 332)
            {

                paddlePos.Y = 332;
            }

            paddleHitbox.Location = paddlePos.ToPoint();

        }


        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(paddle, paddleHitbox, Color.White);
           


        }









    }



}



