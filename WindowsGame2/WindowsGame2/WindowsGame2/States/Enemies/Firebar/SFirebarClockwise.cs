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
    public class SFirebarClockwise : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int angle, size;

        public SFirebarClockwise(IEnemy enemy, int size)
        {
            this.angle = HotDAMN.FIREBAR_POS_DOWN;
            this.size = size;
            this.Enemy = enemy;
            Enemy.Sprite = new FirebarAnimation(Textures.projectileFireball, size, false, 4, 4);

            Enemy.Hitbox.Clear();
            SetHitbox();
        }

        public void Update()
        {
            angle = angle - HotDAMN.FIREBAR_SPEED < 0 ? HotDAMN.FULL_CIRCLE - HotDAMN.FIREBAR_SPEED : angle - HotDAMN.FIREBAR_SPEED;

            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)(Enemy.Position.X + (size - 1) * Math.Cos(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE)),
                    (int)(Enemy.Position.Y - (size - 1) * Math.Sin(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE)),
                    Hitboxes.FIREBAR_WIDTH,
                    Hitboxes.FIREBAR_HEIGHT
                );
        }
    }
}
