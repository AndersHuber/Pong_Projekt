

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
        private KeyboardState kstate = Keyboard.GetState();
        private Keys Up, Down;


        public Paddle(Texture2D paddel, Vector2 paddlePos, Keys Up, Keys Down)
        {
            paddle = paddel;
            this.paddlePos = paddlePos;
            this.Up = Up;
            this.Down = Down;
        }


        public Rectangle PaddleHitbox
        {

            get { return new Rectangle((int)paddlePos.X, (int)paddlePos.Y, 21, 148); }
            set { paddleHitbox = value; }

        }

        public Vector2 PaddlePos
        {

            get { return paddlePos; }
            set { paddlePos = value; }

        }


        public void Update()
        {
            if (kstate.IsKeyDown(Up))
            {
                paddlePos.Y += fart;
            }

            if (kstate.IsKeyDown(Down))
            {
                paddlePos.Y -= fart;
            }          

            paddleHitbox.Location = paddlePos.ToPoint();
        }


        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(paddle, paddlePos, Color.White);
           


        }









    }



}



