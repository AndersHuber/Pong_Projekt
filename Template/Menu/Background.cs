using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class Background
    {
        private Texture2D backGround;
        private Vector2 backGroundPos, fontPos;
        private Rectangle backGroundHitbox;
        private int intersect;
        private SpriteFont backGroundFont;

        public Background(Texture2D backGround, Vector2 backGroundPos, Rectangle backGroundHitbox, int Intersect)
        {
            this.backGround = backGround;
            this.backGroundPos = backGroundPos;
            this.intersect = Intersect;
            this.backGroundHitbox = backGroundHitbox;        
        }

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

        public int Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, BackGroundHitbox, Color.White);

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

    }
}
