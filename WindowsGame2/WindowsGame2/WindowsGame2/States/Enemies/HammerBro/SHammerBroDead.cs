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
    public class SHammerBroDead : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int counter;

        public SHammerBroDead(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.hammerBroDead);
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = Vector2.Zero;
            Enemy.Acceleration = Physics.GRAVITY / 2;
            counter = 0;
            SoundPanel.PlaySoundEffect(Sound.stompEffect);
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
                    Hitboxes.HAMMERBRO_WIDTH,
                    Hitboxes.HAMMERBRO_HEIGHT
                );
        }
    }
}
