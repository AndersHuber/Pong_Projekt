using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class Bonus
    {
        private Texture2D bonus;
        private Vector2 bonusPos;
        private Rectangle bonusHitbox;
        private int intersect;

        public Bonus(Texture2D bonus, Vector2 bonusPos, Rectangle bonusHitbox, int intersect)
        {
            this.bonus = bonus;
            this.bonusPos = bonusPos;
            this.bonusHitbox = bonusHitbox;
            this.intersect = intersect;
        }

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

        public int Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }

        public void Update(Ball ball1)
        {
            bonusHitbox = new Rectangle(1300, 1500, 50, 50);
        }

        public void UpdateIntersect(Ball ball1, Paddle leftPaddle, Paddle rightPaddle)
        {
            if(ball1.BallHitbox.Intersects(leftPaddle.PaddleHitbox))
            {
                intersect = 2;
            }

            if (ball1.BallHitbox.Intersects(rightPaddle.PaddleHitbox))
            {
                intersect = 1;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bonus, bonusHitbox, Color.White);
        }


    }
}
