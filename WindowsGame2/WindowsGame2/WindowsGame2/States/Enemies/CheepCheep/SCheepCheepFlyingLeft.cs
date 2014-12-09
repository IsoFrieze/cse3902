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


    public class SCheepCheepFlyingLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        public SCheepCheepFlyingLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Random random = new Random();
            Enemy.Hitbox.SetOffset(Hitboxes.CHEEPCHEEP_OFFSET_X, Hitboxes.CHEEPCHEEP_OFFSET_Y);
            SetHitbox();

            Enemy.Velocity += new Vector2(-3 * (float)random.NextDouble(), 0f);
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
                    Hitboxes.CHEEPCHEEP_WIDTH,
                    Hitboxes.CHEEPCHEEP_HEIGHT
                );
        }
    }
}
