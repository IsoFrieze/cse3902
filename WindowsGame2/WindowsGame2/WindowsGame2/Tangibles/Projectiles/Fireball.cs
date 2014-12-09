using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Fireball : IProjectile
    {
        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public Fireball(bool left, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Acceleration = Physics.GRAVITY;
            this.Hitbox = new Hitbox(Hitboxes.FIREBALL_OFFSET_X, Hitboxes.FIREBALL_OFFSET_Y);
            if (left)
            {
                this.State = new SFireballBouncingLeft(this);
            }
            else
            {
                this.State = new SFireballBouncingRight(this);
            }
            this.Sprite = new Animation(Textures.projectileFireball, 4, 4);
            this.IsActive = true;
            this.CollisionHandler = new FireballCollisionHandler(this);
            
        }
        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            if (Velocity.Y > Physics.TERMINAL_VELOCITY_FIREBALL)
            {
                Velocity = new Vector2(Velocity.X, Physics.TERMINAL_VELOCITY_FIREBALL);
            }
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
