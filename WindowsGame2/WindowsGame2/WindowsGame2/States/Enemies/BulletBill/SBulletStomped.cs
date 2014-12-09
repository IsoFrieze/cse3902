using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SBulletStomped : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SBulletStomped(IEnemy enemy)
        {
            this.Enemy = enemy;
            

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = Vector2.Zero;
            Enemy.Acceleration = Physics.GRAVITY;
            timer = 0;
            SoundPanel.PlaySoundEffect(Sound.stompEffect);
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE)
            {
                Enemy.IsActive = false;
            }
            timer++;
            Enemy.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                  (int)Enemy.Position.X,
                  (int)Enemy.Position.Y,
                  0,
                  0
              );
        }
    }
}
