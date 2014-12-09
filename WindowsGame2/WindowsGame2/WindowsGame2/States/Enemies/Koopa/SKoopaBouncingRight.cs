using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SKoopaBouncingRight : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SKoopaBouncingRight(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.koopaBouncingRight, 2, 10);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(0.6f, Enemy.Velocity.Y);
            Enemy.Acceleration = Physics.GRAVITY / 3;
        }

        public void Update()
        {
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
