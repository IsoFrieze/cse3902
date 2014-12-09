using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BowserFireball : IProjectile
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

        public BowserFireball(int x, int y)
        {
            this.Position = new Vector2(x, y);
            this.Acceleration = Physics.GRAVITY;
            this.Hitbox = new Hitbox(Hitboxes.BOWSERS_FIREBALL_WIDTH, Hitboxes.BOWSERS_FIREBALL_HEIGHT);
            this.State = new SBowserFireballLeft(this);
            this.Sprite = new Animation(Textures.bowserFireballLeft, 2, 10);
            this.IsActive = true;
            this.CollisionHandler = new EmptyCollisionHandler();
            
        }
        public void Update()
        {
            Position += Velocity;
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
