using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class Explosion : IParticle
    {
        public bool IsActive { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public IParticleState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Explosion(Vector2 position)
        {
            this.Position = position;
            this.Velocity = Vector2.Zero;
            this.State = new SParticleExplosion(this, 7);
            this.Sprite = new Animation(Textures.particleExplosion, 3, 3);
            this.IsActive = true;
        }

        public void Update()
        {
            State.Update();
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
