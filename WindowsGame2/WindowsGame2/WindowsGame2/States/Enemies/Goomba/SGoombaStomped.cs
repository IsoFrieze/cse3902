using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SGoombaStomped : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SGoombaStomped(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.goombaStomped);

            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = Vector2.Zero;
            timer = 0;
            SoundPanel.PlaySoundEffect(Sound.stompEffect);
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE / 6)
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
                    Hitboxes.GOOMBA_WIDTH,
                    Hitboxes.GOOMBA_HEIGHT
                );
        }
    }
}
