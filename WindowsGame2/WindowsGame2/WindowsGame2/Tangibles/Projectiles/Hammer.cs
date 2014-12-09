using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Hammer: IProjectile
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

        public Hammer(int x, int y)
        {
            this.Position = new Vector2(x, y);
            this.Acceleration = Physics.GRAVITY / 4;
            this.Hitbox = new Hitbox(Hitboxes.HAMMER_WIDTH, Hitboxes.HAMMER_HEIGHT);
            this.State = new SHammer(this);
            this.Sprite = new Animation(Textures.hammer, 4, 10);
            this.IsActive = true;
            this.CollisionHandler = new EmptyCollisionHandler();
            
        }
        public void Update()
        {
            Position += Velocity;
            Velocity += Acceleration;
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
