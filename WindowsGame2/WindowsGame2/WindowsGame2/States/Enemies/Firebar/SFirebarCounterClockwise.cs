using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class SFirebarCounterClockwise : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int angle, size;

        public SFirebarCounterClockwise(IEnemy enemy, int size)
        {
            this.angle = HotDAMN.FIREBAR_POS_UP;
            this.size = size;
            this.Enemy = enemy;
            Enemy.Sprite = new FirebarAnimation(Textures.projectileFireball, size, true, 4, 4);

            Enemy.Hitbox.Clear();
            SetHitbox();
        }

        public void Update()
        {
            angle = angle + HotDAMN.FIREBAR_SPEED == HotDAMN.FULL_CIRCLE ? 0 : angle + HotDAMN.FIREBAR_SPEED;

            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)(Enemy.Position.X + (size - 1) * Hitboxes.FIREBAR_WIDTH * Math.Cos(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE)),
                    (int)(Enemy.Position.Y - (size - 1) * Hitboxes.FIREBAR_HEIGHT * Math.Sin(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE)),
                    Hitboxes.FIREBAR_WIDTH,
                    Hitboxes.FIREBAR_HEIGHT
                );
        }
    }
}
