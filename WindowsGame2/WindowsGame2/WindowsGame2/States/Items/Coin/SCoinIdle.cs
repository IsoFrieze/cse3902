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
    public class SCoinIdle : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }

        public SCoinIdle(IPowerUp powerup)
        {
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.powerupCoin, 6, 10);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Velocity = Vector2.Zero; 
        }

        public void Update()
        {
            Powerup.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn() { }

        private void SetHitbox()
        {
            Powerup.Hitbox.AddRectHitbox(
                    (int)Powerup.Position.X,
                    (int)Powerup.Position.Y,
                    Hitboxes.COIN_WIDTH,
                    Hitboxes.COIN_HEIGHT
                );
        }
    }
}
