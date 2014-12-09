using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SRedKoopaShelledUpsideDown : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SRedKoopaShelledUpsideDown(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.redKoopaInShellUpsideDown);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_SHELL_OFFSET_X, Hitboxes.KOOPA_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(0, -5f);
            Enemy.Acceleration = Physics.GRAVITY / 2;
            timer = 0;
            SoundPanel.PlaySoundEffect(Sound.stompEffect);
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_KOOPA_WARNING)
            {
                Enemy.State = new SKoopaWarningUpsideDown(Enemy);
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
                    Hitboxes.KOOPA_SHELL_WIDTH,
                    Hitboxes.KOOPA_SHELL_HEIGHT
                );
        }
    }
}
