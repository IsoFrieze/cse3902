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
    public class SMushroomMovingRight : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }

        public SMushroomMovingRight(IPowerUp powerup)
        {
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.powerupMushroom);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Acceleration = Physics.GRAVITY;
            Powerup.Velocity = new Vector2(1f, 0);
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
                    Hitboxes.MUSHROOM_WIDTH,
                    Hitboxes.MUSHROOM_HEIGHT
                );
        }

    
    }
}
