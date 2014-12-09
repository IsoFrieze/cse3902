using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Star : IPowerUp
    {
        public ITangibleState State { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool IsActive { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public Star(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Physics.GRAVITY / 3;
            this.Hitbox = new Hitbox(Hitboxes.STAR_OFFSET_X, Hitboxes.STAR_OFFSET_Y);
            this.State = new SStarBouncingLeft(this);
            this.Sprite = new Animation(Textures.powerupStar, 4, 4);
            this.IsActive = true;
            this.CollisionHandler = new StarCollisionHandler(this);
        }
        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            Sprite.Update();
            State.Update();
            if (Velocity.Y > Physics.TERMINAL_VELOCITY_FALLING)
            {
                Velocity = new Vector2(Velocity.X, Physics.TERMINAL_VELOCITY_FALLING);
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
