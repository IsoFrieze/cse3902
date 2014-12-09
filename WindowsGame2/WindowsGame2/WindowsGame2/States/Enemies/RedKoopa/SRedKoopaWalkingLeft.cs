using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SRedKoopaWalkingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SRedKoopaWalkingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.redKoopaLeftWalking, 2, 10);

            Enemy.Hitbox.SetOffset(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            Enemy.Hitbox.Clear();
            ((RedKoopa)Enemy).LedgeHitbox.SetOffset(Hitboxes.KOOPA_OFFSET_X, Hitboxes.KOOPA_OFFSET_Y);
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.55f, 0);
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

            ((RedKoopa)Enemy).LedgeHitbox.AddRectHitbox(
                    ((int)Enemy.Position.X - Hitboxes.KOOPA_WIDTH),
                    ((int)Enemy.Position.Y - Hitboxes.KOOPA_HEIGHT),
                    Hitboxes.KOOPA_WIDTH,
                    Hitboxes.KOOPA_HEIGHT
                );
        }
    }
}
