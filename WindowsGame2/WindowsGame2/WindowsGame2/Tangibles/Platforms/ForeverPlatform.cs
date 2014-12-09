using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class ForeverPlatform : IBlock
    {
        public ITangibleState State { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public bool IsActive { get; set; }
        public int SequenceCounter { get; set; }

        public ForeverPlatform(int width, bool up, int x, double y)
        {
            this.Position = new Vector2(x, (float)y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.PLATFORM_OFFSET_X, Hitboxes.PLATFORM_OFFSET_Y);
            if (up)
            {
                this.State = new SPlatformMovingUp(this, width);
            }
            else
            {
                this.State = new SPlatformMovingDown(this, width);
            }
            this.Sprite = new PlatformAnimation(Textures.platform, width);
            this.IsActive = true;
            this.CollisionHandler = new StaticBlockCollisionHandler(this);
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            if (Position.Y < 0)
            {
                Position = new Vector2(Position.X, Position.Y + 16*16);
            }
            else if (Position.Y > 16*16)
            {
                Position = new Vector2(Position.X, Position.Y - 16*16);
            }
            State.Update();
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
