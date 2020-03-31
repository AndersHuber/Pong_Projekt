using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Pong
{
    class Meny
    {
        private Texture2D meny;
        private Vector2 menyPos;
        private bool gameState;

        public Meny(Texture2D meny, Vector2 menyPos, bool gameState)
        {
            this.meny = meny;
            this.menyPos = menyPos;
            this.gameState = gameState;
        }

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

        public void Update(Background backGround1)
        {
            if(backGround1.Intersect == true)
            {
                gameState = false;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(meny, menyPos, Color.White);
        }



    }
}
