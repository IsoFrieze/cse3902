using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SBuzzyBeetleWalkingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SBuzzyBeetleWalkingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new Animation(Textures.buzzyBeetleLeftWalking, 2, 8);

            Enemy.Hitbox.SetOffset(Hitboxes.BUZZYBEETLE_OFFSET_X, Hitboxes.BUZZYBEETLE_OFFSET_Y);
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.8f, 0);
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
                    Hitboxes.BUZZYBEETLE_WIDTH,
                    Hitboxes.BUZZYBEETLE_HEIGHT
                );
        }
    }
}
