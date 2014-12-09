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


    public class SCheepCheepDeadLeft : IEnemyState
    {
        public IEnemy Enemy { get; set; }

        
        public SCheepCheepDeadLeft(IEnemy enemy)
        {
            this.Enemy = enemy;
            Enemy.Acceleration = Physics.GRAVITY; // will have to change eventually for underwater gravity
            Enemy.Hitbox.Clear();
            
            if (Enemy.Sprite.Texture == (Textures.cheepCheepGrayLeft))
            {
                Enemy.Sprite = new Animation(Textures.cheepCheepGrayDeadLeft, 1, 1);
            }
            else
            {
                Enemy.Sprite = new Animation(Textures.cheepCheepRedDeadLeft, 1, 1);

            }
            
        }

        public void Update()
        {
            
        }

        private void SetHitbox()
        {
          
        }
    }
}
