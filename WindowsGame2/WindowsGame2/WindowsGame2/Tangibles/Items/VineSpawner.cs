using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class VineSpawner : IPowerUp
    {
        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public bool IsActive { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        public Vine vine;

        public VineSpawner(Vine vine, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.ROPE_OFFSET_X, Hitboxes.ROPE_OFFSET_Y);
            this.State = new SVineSpawnerInBlock(this);
            this.Sprite = new FlagpoleAnimation(Textures.vine, 1);
            this.IsActive = true;
            this.CollisionHandler = new VineSpawnerCollisionHandler(this);
            this.vine = vine;
        }
        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            //Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
