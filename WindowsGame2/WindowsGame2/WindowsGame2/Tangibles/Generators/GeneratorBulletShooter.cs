using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class GeneratorBulletShooter : IEnemy
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

        private Random rand;
        private int counter, shoot;

        public GeneratorBulletShooter(int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.Hitbox = new Hitbox(0, 0);
            this.State = new SGeneratorIdle(this);
            this.Sprite = new Animation(Textures.mushroomPointer);
            this.IsActive = true;
            this.CollisionHandler = new EmptyCollisionHandler();
            this.rand = new Random();
            this.counter = 0;
            this.shoot = rand.Next(100, 300);
        }

        public void Update()
        {
            counter++;
            State.Update();

            if (counter == shoot)
            {
                counter = 0;
                shoot = rand.Next(100, 300);

                bool leftOfMario = HUD.level.player.Position.X > Position.X;
                HUD.level.AddDynamicObject(new BulletBill((int)Position.X, (int)Position.Y, leftOfMario ? "right" : "left"));
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            //Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }
    }
}
