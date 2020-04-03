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

        public Bonus(Texture2D bonus, Vector2 bonusPos, Rectangle bonusHitbox)
        {
            this.bonus = bonus;
            this.bonusPos = bonusPos;
            this.bonusHitbox = bonusHitbox;
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

        public void Update(Ball ball1)
        {
            bonusHitbox = new Rectangle(1300, 1500, 50, 50);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bonus, bonusHitbox, Color.White);
        }


    }
}
