using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    class SKoopaUpsideDownShellMovingRight : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SKoopaUpsideDownShellMovingRight(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.koopaInShellUpsideDown);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_SHELL_OFFSET_X, Hitboxes.KOOPA_SHELL_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(2.5f, 0);
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
                    Hitboxes.KOOPA_SHELL_WIDTH,
                    Hitboxes.KOOPA_SHELL_HEIGHT
                );
        }
    }
}


