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
    public interface ITangible
    {
        IAnimatedSprite Sprite { get; set; }
        bool IsActive { get; set; }
        ITangibleState State { get; set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        Hitbox Hitbox { get; set; }
        ICollisionHandler CollisionHandler { get; set; }
        int SequenceCounter { get; set; }

        void Update();
        void Draw(SpriteBatch sb, Rectangle camera);
    }
}
