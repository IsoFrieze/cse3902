using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    class SBulletDead : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter;
        public SBulletDead(IEnemy enemy)
        {
            this.Enemy = enemy;
            

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(0, -5f);
            Enemy.Acceleration = Physics.GRAVITY / 2;
            counter = 0;
            SoundPanel.PlaySoundEffect(Sound.kickEffect);

        }

        public SBulletDead(IEnemy enemy, String direction)
        {
            this.Enemy = enemy;
            Enemy.Hitbox.Clear();
            SetHitbox();
            Enemy.Acceleration = Physics.GRAVITY / 2;
            counter = 0;
            SoundPanel.PlaySoundEffect(Sound.kickEffect);

            if (direction.Equals("left"))
            {
                Enemy.Velocity = new Vector2(-1f, -5f);
            }
            else
            {
                Enemy.Velocity = new Vector2(1f, -5f);
            }

        }

        public void Update()
        {
            if (counter == HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE)
            {
                Enemy.IsActive = false;
            }
            counter++;
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

