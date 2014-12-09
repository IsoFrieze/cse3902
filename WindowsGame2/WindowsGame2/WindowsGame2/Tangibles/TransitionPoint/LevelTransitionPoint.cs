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
    public class LevelTransitionPoint : IBlock
    {
        public IAnimatedSprite Sprite { get; set; }
        public ITangibleState State { get; set; }
        public bool IsActive { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public Hitbox Hitbox { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public String Go { get; set; }
        public String direction;
        public int SequenceCounter { get; set; }

        public LevelTransitionPoint(String go, String direction, int x = 0, int y = 0)
        {
            this.Position = new Vector2(x, y);
            this.Velocity = Vector2.Zero;
            this.Hitbox = new Hitbox(0, 0);
            this.State = new STransitionPointInactive(this);
            this.Sprite = new Animation(Textures.platform, 4, 8);
            this.IsActive = true;
            this.CollisionHandler = new TransitionPointCollisionHandler(this);
            this.Go = go;
            this.direction = direction;
        }
        public void Update()
        {
            Sprite.Update();
            State.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            //Sprite.Draw(sb, (int)Position.X - camera.X, (int)Position.Y - camera.Y);
        }

        public bool IsCorrectDirection(IPlayerState playerState) {
            return
               (direction.Equals("down") && playerState is IDuckingMarioState) ||
               (direction.Equals("left") && (playerState is ILeftMarioState && !(playerState is IIdleMarioState))) ||
               (direction.Equals("right") && (playerState is IRightMarioState && !(playerState is IIdleMarioState)));
        }
    }
}
