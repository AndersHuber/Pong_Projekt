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
        private int intersect2;
        private bool intersect;
        private Random random = new Random();
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

        public void Update(Ball ball1, GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (timer == 5)
            {
                bonusHitbox = new Rectangle(random.Next(30, 750), random.Next(30, 450), 50, 50);
                timer = 0;
            }

            if (ball1.BallHitbox.Intersects(bonusHitbox))
            {
                intersect = true;
                bonusPos = new Vector2(1000, 1000);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bonus, bonusHitbox, Color.White);
        }

    }

}