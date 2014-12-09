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
    public class _1Up : IPowerUp
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

        public _1Up(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Physics.GRAVITY;
            this.Hitbox = new Hitbox(Hitboxes.ONE_UP_OFFSET_X, Hitboxes.ONE_UP_OFFSET_Y);
            this.State = new S1UpMovingLeft(this);
            this.Sprite = new Animation(Textures.powerup1up, 1 , 1);
            this.IsActive = true;
            this.CollisionHandler = new OneUpCollisionHandler(this);
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
