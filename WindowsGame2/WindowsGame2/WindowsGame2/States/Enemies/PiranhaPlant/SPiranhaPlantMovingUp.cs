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
    public class SPiranhaPlantMovingUp : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private int counter;

        public SPiranhaPlantMovingUp(IEnemy enemy)
        {
            this.counter = 0;
            this.Enemy = enemy;

            Enemy.Hitbox.Clear();
            SetHitbox();
            
            Enemy.Velocity = new Vector2(0, -0.5f);
        }

        public void Update()
        {
            if (counter == 2 * HotDAMN.TICKS_UNTIL_PIRANHAPLANT_STOPS)
            {
                Enemy.State = new SPiranhaPlantIdle(Enemy);
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
                    Hitboxes.PIRANHA_PLANT_WIDTH,
                    Hitboxes.PIRANHA_PLANT_HEIGHT
                );
        }
    }
}
