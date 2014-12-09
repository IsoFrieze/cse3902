using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SBuzzyBeetleShelledUpsideDown : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SBuzzyBeetleShelledUpsideDown(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.buzzyBeetleInShellUpsideDown);

            Enemy.Hitbox.SetOffset(Hitboxes.BUZZYBEETLE_SHELL_OFFSET_X, Hitboxes.BUZZYBEETLE_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = Vector2.Zero;
            timer = 0;
            SoundPanel.PlaySoundEffect(Sound.stompEffect);
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_BUZZYBEETLE_AWAKES)
            {
                Enemy.State = new SBuzzyBeetleWalkingRight(Enemy);
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
                    Hitboxes.KOOPA_WIDTH,
                    Hitboxes.KOOPA_HEIGHT
                );
        }
    }
}
