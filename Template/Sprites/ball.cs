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
        //Textur
        private Texture2D ball;
        //Bollens position och fart
        private Vector2 ballPos, velocity;
        //Hitboxen
        private Rectangle ballHitbox;
        //Skapar slumpgenerator
        public Random random = new Random();
        private int tal;

        //Konstruktor som tar Texture2D och position som parametrar
        public Ball(Texture2D ball, Vector2 ballPos)
        {
           //Instansvariablerna ska vara lika med konstruktorns parametrar
            this.ball = ball;
            this.ballPos = ballPos;

            //Slumpar fram tal som slumpar riktning på boll
            tal = random.Next(1, 3);

            //Beroende på tal (1 eller 2) så färdas bollen +(höger) eller -(vänster)
            if (tal == 1)
            {
                velocity = new Vector2(-8, -8);
            }

            if (tal == 2)
            {
                velocity = new Vector2(8, 8);
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


        //Ifall main anropar denna så har bollen träffat en paddel och paddelns x hastighet multipliceras med -1 och alltså går åt vänster
        public void Colission()
        {
            velocity.X *= -1;

        }


        //Bollens hastighet, riktning och begränsningar
        public void Update()
        {

            //Bollpositionen ökar med +8 eller -8  hela tiden
             ballPos.X += velocity.X;
             ballPos.Y += velocity.Y;
             
            //Ifall bollen går över eller under skärmen multiplicera med -1
            if (ballPos.Y <= 0)
            {
                velocity.Y *= -1;
            }

            if (ballPos.Y >= 480 - 19)
            {
                velocity.Y *= -1;
            }

            //Bollhitboxen ska ha boll positionen
            ballHitbox.Location = ballPos.ToPoint();

        }

        //Main anropar metoden för att rita ut bollen, tar texturen, positionen och färgen
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(ball, ballPos, Color.White);

        }



    }
}