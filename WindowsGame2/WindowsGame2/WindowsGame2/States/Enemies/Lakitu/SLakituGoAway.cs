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
    public class SLakituGoAway : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SLakituGoAway(IEnemy enemy)
        {
            this.Enemy = enemy;
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            Enemy.Velocity = new Vector2(-0.2f, 0);
            Enemy.Sprite = new Animation(Textures.lakituInCloud);
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
                    Hitboxes.LAKITU_WIDTH,
                    Hitboxes.LAKITU_HEIGHT
                );
        }
    }
}
