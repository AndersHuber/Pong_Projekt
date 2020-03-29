using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Background
    {
        private Texture2D backGround;
        private Vector2 backGroundPos;

        public Background(Texture2D backGround, Vector2 backGroundPos)
        {
            this.backGround = backGround;
            this.backGroundPos = backGroundPos;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, backGroundPos, Color.White);
        }


    }
}
