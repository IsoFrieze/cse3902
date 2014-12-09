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
    public class SHammerBroJump : IEnemyState
    {
        public IEnemy Enemy { get; set; }
        private float newHeight, oldHeight;
        Random rand;

        public SHammerBroJump(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Sprite = new SettingDependentAnimation(Textures.hammerBroWalking, 2, 10);
            
            Enemy.Hitbox.Clear();
            SetHitbox();

            this.rand = new Random();
            int newHeightTest = rand.Next(20);
            this.oldHeight = Enemy.Position.Y;
            if (oldHeight > 2 * HotDAMN.WINDOW_HEIGHT / 3 || (oldHeight > HotDAMN.WINDOW_HEIGHT / 3 && newHeightTest % 2 == 0))
            {
                Enemy.Velocity += new Vector2(0f, -7.5f);
                this.newHeight = oldHeight - (HotDAMN.GRID * HotDAMN.BLOCKS_HAMMERBRO_JUMPS_UP);
            }
            else
            {
                Enemy.Velocity += new Vector2(0f, -4f);
                this.newHeight = oldHeight + (HotDAMN.GRID * HotDAMN.BLOCKS_HAMMERBRO_JUMPS_DOWN);
            }
        }

        public void Update()
        {
            Enemy.Hitbox.Cycle();
            SetHitbox();
            if (newHeight > oldHeight ? Enemy.Position.Y > newHeight : Enemy.Position.Y < newHeight)
            {
                if (HUD.TIME < 100)
                {
                    Enemy.State = new SHammerBroApproach(Enemy);
                }
                else
                {
                    Enemy.State = new SHammerBroStay(Enemy);
                }
            }
        }

        private void SetHitbox()
        {
            Enemy.Hitbox.AddRectHitbox(
                    (int)Enemy.Position.X,
                    (int)Enemy.Position.Y,
                    Hitboxes.HAMMERBRO_WIDTH,
                    Hitboxes.HAMMERBRO_HEIGHT
                );
        }
    }
}
