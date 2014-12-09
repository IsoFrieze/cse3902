using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BulletBill : IEnemy
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

        public BulletBill(int x = 0, int y = 0, String direction = "")
        {
            this.SequenceCounter = 0;
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.BULLETBILL_OFFSET_X, Hitboxes.BULLETBILL_OFFSET_Y);
            this.IsActive = true;
            this.CollisionHandler = new BulletBillCollisionHandler(this);

            if (direction.Equals("left"))
            {
                this.State = new SBulletMovingLeft(this);
            }
            else
            {
                this.State = new SBulletMovingRight(this);
            }
            SoundPanel.PlaySoundEffect(Sound.fireworksEffect);
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
    }
}
