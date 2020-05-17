using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Coin classen spawnar flera mynt i bakgrunden av huvudmenyn och dessa mynt faller ner som regn. Jag lägger till mynten i en lista, som jag har i main.
/// Myntobjekten skapar jag i main. Jag sätter en for loop samt en timer som gör att mynten spawnar varje sekund, sen använder jag en for loop i draw,
/// som ritar ut alla mynten. Ifall myntlistan blir större än 19 objekt tas det 19:e objektet bort.
/// </summary>

namespace Pong
{
    class Coin
    {
        //Variabler för myntets egenskaper
        #region Egenskaper
        private Vector2 coinPos;
        private Texture2D coinTexture;
        private Rectangle coinHitbox;
        #endregion

        //Konstruktor som tar myntets egenskaper som parametrar och anger värdet för dess hitbox
        #region Konstruktor
        public Coin(Texture2D coinTexture, Vector2 coinPos)
        {
            this.coinTexture = coinTexture;
            this.coinPos = coinPos;
            coinHitbox = new Rectangle((int)coinPos.X, (int)coinPos.Y, 30, 30);
        }
        #endregion

        //Get set metoder för att kunna använda myntets egenskaper utanför klassen
        #region Get / set metoder
        public Texture2D CoinTexture
        {
            get { return coinTexture; }
            set { coinTexture = value; }
        }
           
        public Vector2 CoinPos
        {
            get { return coinPos; }
            set { coinPos = value; }
        }

        public Rectangle CoinHitbox
        {
            get { return coinHitbox; }
            set { coinHitbox = value; }
        }
        #endregion

        //Update metod som checkar ifall myntet är utanför skärm, isåfall flytta det tillbaka längst upp. Flyttar hitboxen till myntets position
        //Uppdaterar myntets position
        #region Update metod
        public void Update()
        {
            
            if(coinPos.Y > 480)
            {
                coinPos.Y = 0;
            }
            
            coinPos.Y += 5;
            coinHitbox.Location = coinPos.ToPoint();
        }
        #endregion

        //Draw metod som ritar ut myntet
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(coinTexture, coinHitbox, Color.White);
        }
    }
}
