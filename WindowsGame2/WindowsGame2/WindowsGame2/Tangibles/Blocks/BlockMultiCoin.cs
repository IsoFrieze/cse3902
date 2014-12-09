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
    public class BlockMultiCoin : IBlock, IContainer
    {
        public ITangibleState State { get; set; }
        public IPowerUp[] Contains { get; set; }
        public bool IsActive { get; set; }
        public IAnimatedSprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public int SequenceCounter { get; set; }

        private int timer;
        private bool startTimer;
        private int coinCount;
        
        public BlockMultiCoin(IPowerUp[] contains, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(Hitboxes.BLOCK_OFFSET_X, Hitboxes.BLOCK_OFFSET_Y);
            this.State = new SBlockIdle(this);
            this.Sprite = new SettingDependentAnimation(Textures.blockBrick);
            this.IsActive = true;
            this.Contains = contains;
            this.CollisionHandler = new MultiCoinBlockCollisionHandler(this);
            timer = HotDAMN.TICKS_UNTIL_MULTICOIN_BLOCK_EXPIRES;
            startTimer = false;
            coinCount = 0;
        }

        public void Update()
        {
            Velocity += Acceleration;
            Position += Velocity;
            State.Update();
            Sprite.Update();

            if (timer == 0)
            {
                Contains[0] = Contains[14];
                Contains[1] = Contains[14];
                this.CollisionHandler = new BrickBlockCollisionHandler(this);
            }
            if (startTimer)
            {
                timer--;
            }
            if (coinCount == 14)
            {
                Contains[0] = Contains[14];
                Contains[1] = Contains[14];
                this.CollisionHandler = new BrickBlockCollisionHandler(this);
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }

        public void Empty(IPlayer player)
        {
            if (Contains != null && Contains.Length > 0)
            {
                ((IPowerUpState)Contains[coinCount].State).Spawn();
                startTimer = true;
                coinCount++;
            }
        }
    }
}
