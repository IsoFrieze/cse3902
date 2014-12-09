using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class BrokenBrickParticle : IParticle
    {
        public bool IsActive { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public IParticleState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public BrokenBrickParticle(Vector2 position, Vector2 velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.State = new SFallingParticle(this);
            this.Sprite = new SettingDependentAnimation(Textures.particleBricks, 4, 4);
            this.IsActive = true;
        }

        public void Update()
        {
            Position += Velocity;
            Velocity += Acceleration;
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
