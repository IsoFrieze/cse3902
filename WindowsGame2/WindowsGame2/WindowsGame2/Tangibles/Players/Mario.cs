using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class Mario : IPlayer
    {
        public string Name { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }
        public int Score { get; set; }

        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public TemporaryDecorator Decorator { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public IAutoMovement AutoMove { get; set; }
        public bool IsRunning { get; set; }
        public int SequenceCounter { get; set; }
        public Mario(int x = 0, int y = 0)
        {
            Name = "MARIO";
            Lives = HotDAMN.INITIAL_LIVES_COUNT;
            Position = new Vector2(x, y);
            Velocity = Vector2.Zero;
            Acceleration = Physics.GRAVITY;
            Hitbox = new Hitbox(Hitboxes.SMALL_MARIO_IDLE_OFFSET_X, Hitboxes.SMALL_MARIO_IDLE_OFFSET_Y);
            State = HUD.MarioState(this, HUD.setting);
            Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallRightIdle);
            IsActive = true;
            Decorator = new PlainPlayer(this);
            CollisionHandler = new PlayerCollisionHandler(this);
            IsRunning = false;
        }
        
        public void Update()
        {
            if (!(this.State is SDeadMario))
            {
                if (HUD.TIME == 0)
                {
                    this.State = new SDeadMario(this);
                }
                else if (Position.Y > HotDAMN.WINDOW_HEIGHT)
                {
                    HUD.level.PlayerFallsOffScreen();
                }
            }
            if (AutoMove != null && AutoMove.IsActive)
            {
                AutoMove.Update();
            }
            Velocity += Acceleration;
            Position += Velocity;
            State.Update();
            Sprite.Update();
            if (Velocity.Y > Physics.TERMINAL_VELOCITY_FALLING)
            {
                Velocity = new Vector2(Velocity.X, Physics.TERMINAL_VELOCITY_FALLING);
            }
            float terminalVelocity = IsRunning ? Physics.TERMINAL_VELOCITY_RUNNING : Physics.TERMINAL_VELOCITY_WALKING;
            if (Velocity.X > terminalVelocity || Velocity.X < -terminalVelocity)
            {
                Velocity = new Vector2(Velocity.X * 0.9f, Velocity.Y);
            }
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, (int)this.Position.X - camera.X, (int)this.Position.Y - camera.Y);
        }
    }
}
