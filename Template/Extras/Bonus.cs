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
        private bool intersect;
        private Random boxLocation = new Random();
        private Random boxContent = new Random();
        private Random paddlePos = new Random();
        private int content;
        private double timer;

        public Bonus(Texture2D bonus, Vector2 bonusPos, Rectangle bonusHitbox, bool intersect)
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

        public bool Intersect
        {
            get { return intersect; }
            set { intersect = value; }
        }

        public Random BoxContent
        {
            get { return boxContent; }
            set { boxContent = value; }
        }

        public void Update(Ball ball1, GameTime gameTime, Paddle leftPaddle, Paddle rightPaddle)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            content = boxContent.Next(1, 3);

            if (timer > 3)
            {
                bonusPos = new Vector2(boxLocation.Next(0, 785), boxLocation.Next(0, 480));
                timer = 0;
            }

            if(ball1.BallHitbox.Intersects(bonusHitbox))
            {
                intersect = true;
            }

            bonusHitbox.Location = bonusPos.ToPoint();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bonus, bonusHitbox, Color.White);
        }

    }

}