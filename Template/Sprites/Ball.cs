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
        //Instansvariabler för klassen
        private Texture2D ball;
        private Vector2 ballPos, velocity;
        private Rectangle ballHitbox;
        //Slumpar fram tal som slumpar riktning på boll
        public Random random = new Random();
        private int tal;
        //Poäng
        private int score1, score2 = 0;

        //Konstruktor som tar Texture2D och position som parametrar
        public Ball(Texture2D ball, Vector2 ballPos)
        {

            this.ball = ball;
            this.ballPos = ballPos;
         
            tal = random.Next(1, 3);

            if (tal == 1)
            {
                velocity = new Vector2(-4, -4);
            }

            if (tal == 2)
            {
                velocity = new Vector2(4, 4);
            }
 
        }

        //Get, Set metoder som returnerar variablerna och sätter deras värden
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

        //Sätter ballHitboxens värde i rektangeln
        public Rectangle BallHitbox
        {

            get { return new Rectangle((int)ballPos.X, (int)ballPos.Y, 19, 19); }
            set { ballHitbox = value; }

        }


        //Ifall main anropar denna så har bollen träffat en paddel
        public void Colission()
        {
            velocity.X *= -1;

        }


        //Bollens hastighet, riktning och begränsningar
        public void Update()
        {

             ballPos.X += velocity.X;
             ballPos.Y += velocity.Y;
             

            if (ballPos.Y <= 0)
            {
                velocity.Y *= -1;
            }

            if (ballPos.Y >= 480 - 19)
            {
                velocity.Y *= -1;
            }

            //Score
           

            if (score1 == 3)
            {

            }

            if (score2 == 3)
            {

            }




            ballHitbox.Location = ballPos.ToPoint();

        }

        //Main anropar metoden för att rita ut bollen, tar texturen, positionen och färgen
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ball, ballPos, Color.White);

        }



    }
}