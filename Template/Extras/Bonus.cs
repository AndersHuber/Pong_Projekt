using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Bonus klassen som spawnar bonusen på random ställe på skärmen var 3:e sekund. Kollar också kollision mellan bonus och boll.
/// </summary>

namespace Pong
{
    class Bonus
    {
        //Variabler för bonusens egenskaper
        #region Egenskaper och variabler
        private Texture2D bonus;
        private Vector2 bonusPos;
        private Rectangle bonusHitbox;
        private bool intersect;

        //Slumpgeneratorer för bonusens position och innehåll
        private Random boxLocation = new Random();
        private Random boxContent = new Random();

        //Timer och innehåll i själva bonusen
        private int content;
        private double timer;
        #endregion

        //Konstruktor som tar bonusens egenskaper som parametrar
        #region Konstrukor
        public Bonus(Texture2D bonus, Vector2 bonusPos, Rectangle bonusHitbox, bool intersect)
        {
            this.bonus = bonus;
            this.bonusPos = bonusPos;
            this.bonusHitbox = bonusHitbox;
            this.intersect = intersect;
        }
        #endregion

        //Get set metoder för att kunna använda bonusens egenskaper utanför klassen
        #region Get / set metoder
        public Texture2D Bonus1
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public Vector2 BonusPos
        {
            get { return bonusPos; }
            set { bonusPos = value; }
        }

        public Rectangle BonusHitbox
        {
            get { return bonusHitbox; }
            set { bonusHitbox = value; }
        }

        public bool Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }

        public Random BoxContent
        {
            get { return boxContent; }
            set { boxContent = value; }
        }
        #endregion

        //Update metod som flyttar bonusens position var 3:de sekund samt kollar ifall bonusen har blivit intersectad
        #region Update metod
        public void Update(Ball ball1, GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            content = boxContent.Next(1, 3);

            if (timer > 3)
            {
                bonusPos = new Vector2(boxLocation.Next(0, 785), boxLocation.Next(0, 480));
                timer = 0;
            }

            if(ball1.BallHitbox.Intersects(bonusHitbox))
            {
                intersect = true;
            }

            bonusHitbox.Location = bonusPos.ToPoint();

        }
        #endregion

        //Ritar ut bonusen
        #region Draw metod
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bonus, bonusHitbox, Color.White);
        }
        #endregion

    }

}