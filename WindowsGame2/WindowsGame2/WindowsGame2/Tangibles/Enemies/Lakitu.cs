using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Lakitu : IEnemy
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

        private int xstop;

        public Lakitu (int x = 0, int y = 0, int xstop = 10000)
        {
            this.SequenceCounter = 0;
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.LAKITU_OFFSET_X, Hitboxes.LAKITU_OFFSET_Y);
            this.State = new SLakituHover(this);
            this.IsActive = true;
            this.CollisionHandler = new LakituCollisionHandler(this);
            this.xstop = xstop;
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            if (Position.X > xstop)
            {
                State = new SLakituGoAway(this);
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
