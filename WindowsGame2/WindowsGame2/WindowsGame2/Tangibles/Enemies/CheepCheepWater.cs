using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class CheepCheepWater : IEnemy
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

        public CheepCheepWater(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.CHEEPCHEEP_OFFSET_X, Hitboxes.CHEEPCHEEP_OFFSET_Y);
            this.State = new SCheepCheepSwimmingLeft(this);
            this.CollisionHandler = new CheepCheepWaterCollisionHandler(this);
            setSprite();

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

        private void setSprite()
        {
            Random random = new Random();
            
            int rand = random.Next(0, 1);

            if (rand == 0)
            {
                this.Sprite = new Animation(Textures.cheepCheepRedLeft, 2, 11);
            }
            else
            {
                this.Sprite = new Animation(Textures.cheepCheepGrayLeft, 2, 11);
            }
        }
    }
}
