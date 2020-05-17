using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Paddel klassen. Här uppdateras paddlarnas position som checkas i update metoden. Det är också här som  update metoden kollar vilken tangent som är nedtryckt.
/// Paddlarnas restriktioner checkas också i update metoden. Update metoden kollar också ifall paddeln är stor eller liten och ändrar restriktionerna utifrån det. 
/// </summary>

namespace Pong
{
    class Paddle
    {   
        //Klassvariabler
        #region Variabler och Egenskaper
        private Texture2D paddle;
        private Vector2 paddlePos;
        private float fart = 5;
        private Rectangle paddleHitbox;
        private KeyboardState kstate;
        private Keys Up, Down;
        private bool intersect, small;
        private bool big = true;
        #endregion

        //Konstruktor som tar paddelns egenskaper som parametrar och sätter deras värden
        #region
        public Paddle(Texture2D paddel, Vector2 paddlePos, Rectangle paddleHitbox, Keys Up, Keys Down, bool intersect)
        {
            paddle = paddel;
            this.paddlePos = paddlePos;
            this.Up = Up;
            this.Down = Down;
            this.paddleHitbox = paddleHitbox;
            this.intersect = intersect;
        }
        #endregion

        //Get set metoder så man kan komma åt egenskaperna utanför klassen
        #region
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
        #endregion

        //update metoden
        #region Update metod
        public void Update(Bonus box)
        {

            kstate= Keyboard.GetState();

            //Kollar ifall du trycker ned eller upp på tangenterna, isåfall gå + eller - 5 på y värdet
            if (kstate.IsKeyDown(Up))
            {
                paddlePos.Y -= fart;
            }

            if (kstate.IsKeyDown(Down))
            {
                paddlePos.Y += fart;
            }

            //Kollar ifall paddeln är stor och sedan anpassar programmet så att den inte kan röra sig utanför skärmen
            if (big == true)
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

            //Kollar ifall paddeln är liten och sedan anpassar programmet så att den inte kan röra sig utanför skärmen
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

            //paddelns rektangel flyttar sig med paddelns position
            paddleHitbox.Location = paddlePos.ToPoint();

        }
        #endregion

        //Här ritas paddlarna ut
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(paddle, paddleHitbox, Color.White);
        }









    }



}



