using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class SStarBouncingRight : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }

        public SStarBouncingRight(IPowerUp powerup)
        {
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.powerupStar, 4, 4);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Velocity = new Vector2(1f, Powerup.Velocity.Y);
            Powerup.Acceleration = Physics.GRAVITY / 3;
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
                    Hitboxes.STAR_WIDTH,
                    Hitboxes.STAR_HEIGHT
                );
        }
    }
}
