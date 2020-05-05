using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    class Meny
    {
        //Klassvariabler för menyns egenskaper
        #region
        private Texture2D meny;
        private Vector2 menyPos;
        private bool gameState;
        #endregion

        //Konstruktor som tar menyns egenskaper som parametrar
        #region
        public Meny(Texture2D meny, Vector2 menyPos, bool gameState)
        {
            this.meny = meny;
            this.menyPos = menyPos;
            this.gameState = gameState;
        }
        #endregion

        //Get set metoder för att kunna använda menyns egenskaper utanför klassen
        #region
        public Texture2D Menu
        {
            get { return meny; }
            set { meny = value; }
        }

        public Vector2 MenyPos
        {
            get { return menyPos; }
            set { menyPos = value; }
        }

        public bool GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }
        #endregion

        //update metod som checkar vilken av bakgrunderna som man tryckt ned på och alltså "stänger av" menyskärmen
        #region
        public void Update(Background backGround1, Background backGround2, Background backGround3, Background backGround4, Background backGround5)
        {
            if(backGround1.Intersect == true || backGround2.Intersect == true || backGround3.Intersect == true || backGround4.Intersect == true || backGround5.Intersect == true )
            {
                gameState = false;
            }
        }
        #endregion

        //Draw metod som ritar ut meny-bakgrunden
        #region
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(meny, menyPos, Color.White);
        }
        #endregion
    }
}
