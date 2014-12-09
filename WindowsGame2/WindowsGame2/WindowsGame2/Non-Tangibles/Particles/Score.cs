using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class Score: IParticle
    {
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public IAnimatedSprite Sprite { get; set; }
        public IParticleState State { get; set; }

        public Texture2D texture;
        public Score(Vector2 position, int points)
        {
            this.texture = getTexture(points);
            this.Position = position;
            this.IsActive = true;
            this.State = new SPointsRising(this);
            this.Sprite = new Animation(texture, 1, 1);

        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;

            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }

        Texture2D getTexture(int points)
        {
            switch (points)
            {
                case 100: { return Textures.particleScore100; }
                case 200: { return Textures.particleScore200; }
                case 400: { return Textures.particleScore400; }
                case 500: { return Textures.particleScore500; }
                case 800: { return Textures.particleScore800; }
                case 1000: { return Textures.particleScore1000; }
                case 2000: { return Textures.particleScore2000; }
                case 4000: { return Textures.particleScore4000; }
                case 5000: { return Textures.particleScore5000; }
                case 8000: { return Textures.particleScore8000; }
                default: { return Textures.particle1up; }
            }
        }
    }
}
