using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class Fireworks : IParticle
    {
        public bool IsActive { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public IParticleState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Fireworks(Vector2 position)
        {
            this.Position = position;
            this.Velocity = Vector2.Zero;
            this.State = new SParticleExplosion(this, 25);
            this.Sprite = new Animation(Textures.particleExplosion, 3, 12);
            this.IsActive = true;
            SoundPanel.PlaySoundEffect(Sound.fireworksEffect);
            HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_FIREWORK;
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
