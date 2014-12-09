using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SKoopaWarningUpsideDown : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        private int timer;

        public SKoopaWarningUpsideDown(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.koopaWarningUpsideDown, 2, 9);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_SHELL_OFFSET_X, Hitboxes.KOOPA_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            timer = 0;
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_KOOPA_AWAKES - HotDAMN.TICKS_UNTIL_KOOPA_WARNING)
            {
                Enemy.State = new SKoopaWalkingRight(Enemy);
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
