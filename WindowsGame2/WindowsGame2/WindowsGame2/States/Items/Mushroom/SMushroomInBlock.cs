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
    public class SMushroomInBlock : IPowerUpState
    {
        public IPowerUp Powerup { get; set; }

        public SMushroomInBlock(IPowerUp powerup)
        {
            this.Powerup = powerup;
            Powerup.Sprite = new Animation(Textures.blockHidden);

            Powerup.Hitbox.Clear();
            SetHitbox();

            Powerup.Acceleration = Vector2.Zero;
            Powerup.Velocity = Vector2.Zero;
        }

        public void Update()
        {
            Powerup.Hitbox.Cycle();
            SetHitbox();
        }

        public void Spawn()
        {
            Powerup.State = new SMushroomSpawning(Powerup);
        }

        private void SetHitbox()
        {
            Powerup.Hitbox.AddRectHitbox(
                    (int)Powerup.Position.X,
                    (int)Powerup.Position.Y,
                    0,
                    0
                );
        }
    }
}
