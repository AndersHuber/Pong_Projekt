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

        private int score1;
        private int score2;
        private SpriteFont nummer;


        public Score(SpriteFont nummer)

        {
            this.nummer = nummer;
        }

        public void Update(Ball ball1)
        {

            if (ball1.BallPos.X < 0)
            {
                score1++;
            }

            if (ball1.BallPos.X > 785)
            {
                score2++;
            }

            if(score1 == 3)
            {

            }

            if(score2 == 3)
            {


            }

        }



        public void Draw(SpriteFont nummer)
        {

          


        }

    }



}

