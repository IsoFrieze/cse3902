using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Spiny : IEnemy
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

        public Spiny(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = new Vector2(0f, -3f);
            this.Acceleration = Physics.GRAVITY;
            this.CollisionHandler = new SpinyCollisionHandler(this);
            this.Hitbox = new Hitbox(Hitboxes.SPINY_OFFSET_X, Hitboxes.SPINY_OFFSET_Y);
            this.State = new SSpinyEgg(this);
            
            this.IsActive = true;
            
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
