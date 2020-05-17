using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/// <summary>
/// Inget speciellt, här ritas bara bakgrunderna ut samt texten till menyn. 
/// </summary>

namespace Pong
{
    class Background
    {
        //Klassvariabler för myntets egenskaper
        #region Egenskaper
        private Texture2D backGround;
        private Vector2 backGroundPos, fontPos;
        private Rectangle backGroundHitbox;
        private bool intersect;
        private SpriteFont backGroundFont;
        #endregion

        //Konstruktor som tar bakgrundens egenskaper som parametrar
        #region Konstruktor
        public Background(Texture2D backGround, Vector2 backGroundPos, Rectangle backGroundHitbox, bool intersect)
        {
            this.backGround = backGround;
            this.backGroundPos = backGroundPos;
            this.intersect = intersect;
            this.backGroundHitbox = backGroundHitbox;        
        }
        #endregion

        //Get set metoder för att kunna använda bakgrundens egenskaper utanför klassen
        #region Get / set metoder
        public Background(SpriteFont backGroundFont)
        {
            this.backGroundFont = backGroundFont;
        }

        public Texture2D BackGround
        {
            get { return backGround; }
            set { backGround = value; }
        }

        public Vector2 BackGroundPos
        {
            get { return backGroundPos; }
            set { backGroundPos = value; }
        }

        public Vector2 FontPos
        {
            get { return fontPos; }
            set { fontPos = value; }
        }

        public Rectangle BackGroundHitbox
        {
            get { return backGroundHitbox; }
            set { backGroundHitbox = value; }
        }

        public bool Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }
        #endregion

        //Draw metoder som ritar ut bakgrund, samt bakgrundens "text" vid olika tillfällen
        #region
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, BackGroundHitbox, Color.White);
        }

        public void Draw4(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, new Rectangle(0, 0, 800, 500), Color.White);
        }

        public void Draw2(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(backGroundFont, "Choose BackGround", new Vector2(180, 100), Color.Black);
        }

        public void Draw3(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(backGroundFont, "Loading", new Vector2(315, 200), Color.Black);
            spriteBatch.DrawString(backGroundFont, "Be Ready!", new Vector2(295, 300), Color.Black);
        }
        #endregion
    }
}
