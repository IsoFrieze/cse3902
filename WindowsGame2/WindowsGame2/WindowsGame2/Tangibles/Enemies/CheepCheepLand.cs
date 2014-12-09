using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class CheepCheepLand : IEnemy
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

        public CheepCheepLand(int x = 0, int y = 0, String direction = "")
        {
            this.Position = new Vector2(x, y);
            this.Velocity = new Vector2(0f, -6f);
            this.Acceleration = Physics.GRAVITY / 8;
            this.Hitbox = new Hitbox(Hitboxes.CHEEPCHEEP_OFFSET_X, Hitboxes.CHEEPCHEEP_OFFSET_Y);
            this.CollisionHandler = new CheepCheepLandCollisionHandler(this);
            SetDirection(direction);

            this.IsActive = true;

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
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }

        public void SetDirection(String direction)
        {
            if (direction.Equals("left"))
            {
                this.Sprite = new Animation(Textures.cheepCheepRedLeft, 2, 10);
                this.State = new SCheepCheepFlyingLeft(this);
            }
            else
            {
                this.Sprite = new Animation(Textures.cheepCheepRedRight, 2, 10);
                this.State = new SCheepCheepFlyingRight(this);
            }
        }
    }
}
