using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Score
    {

        private int score1, score2 = 0;
        private SpriteFont nummer;
        private Vector2 fontPos;


        public Score(SpriteFont nummer, Vector2 fontPos)
        {
            this.nummer = nummer;
            this.fontPos = fontPos;
        }

        public Vector2 FontPos
        {
            get { return fontPos; }
            set { fontPos = value; }


        }


      public void Update()
        {

        }



        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.DrawString(nummer, "1", fontPos, Color.Black);


        }

    }



}

