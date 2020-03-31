using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class Background
    {
        private Texture2D backGround;
        private Vector2 backGroundPos;
        private Rectangle backGroundHitbox;
        private bool intersect, b1, b2, b3, b4, b5;
        private MouseState state;
        private Point mousePos;
        

        public Background(Texture2D backGround, Vector2 backGroundPos, Rectangle backGroundHitbox, bool Intersect)
        {
            this.backGround = backGround;
            this.backGroundPos = backGroundPos;
            this.intersect = Intersect;
            this.backGroundHitbox = backGroundHitbox;
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

        public void Update()
        {

            state = Mouse.GetState();
            mousePos = new Point(state.X, state.Y);

            if (backGroundHitbox.Contains(mousePos))
            {
                if (state.LeftButton == ButtonState.Pressed)
                {
                    intersect = true;
                }

            }

            backGroundHitbox.Location = backGroundPos.ToPoint();
                      
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, BackGroundHitbox, Color.White);
        }


    }
}
