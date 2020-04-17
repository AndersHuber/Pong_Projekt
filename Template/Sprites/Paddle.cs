

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
        private bool intersect, small;
        private bool big = true;


        public Paddle(Texture2D paddel, Vector2 paddlePos, Rectangle paddleHitbox, Keys Up, Keys Down, bool intersect)
        {
            paddle = paddel;
            this.paddlePos = paddlePos;
            this.Up = Up;
            this.Down = Down;
            this.paddleHitbox = paddleHitbox;
            this.intersect = intersect;
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

        public bool Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }

        public bool Small
        {
            get { return small; }
            set { small = value; }
        }

        public bool Big
        {
            get { return big; }
            set { big = value; }
        }



        public void Update(Bonus box)
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

            if (Big == true)
            {
                if (paddlePos.Y < 0)
                {

                    paddlePos.Y = 0;

                }

                if (paddlePos.Y > 332)
                {

                    paddlePos.Y = 332;
                }

            }

            if (small == true)
            {
                if (paddlePos.Y < 0)
                {

                    paddlePos.Y = 0;

                }

                if (paddlePos.Y > 400)
                {

                    paddlePos.Y = 400;
                }
            }

            paddleHitbox.Location = paddlePos.ToPoint();

        }


        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(paddle, paddleHitbox, Color.White);
           


        }









    }



}



