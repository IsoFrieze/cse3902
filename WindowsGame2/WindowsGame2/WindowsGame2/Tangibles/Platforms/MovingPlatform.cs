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
    public class MovingPlatform : IBlock
    {
        public ITangibleState State { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public bool IsActive { get; set; }

        private Vector2 PointA { get; set; }
        private Vector2 PointB { get; set; }
        public int SequenceCounter { get; set; }

        public MovingPlatform(int width, int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0)
        {
            this.Position = new Vector2(x1, y1);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.PLATFORM_OFFSET_X, Hitboxes.PLATFORM_OFFSET_Y);
            this.State = new SPlatformAlternate(this, width, x1, y1, x2, y2);
            this.Sprite = new PlatformAnimation(Textures.platform, width);
            this.IsActive = true;
            this.CollisionHandler = new StaticBlockCollisionHandler(this);
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
