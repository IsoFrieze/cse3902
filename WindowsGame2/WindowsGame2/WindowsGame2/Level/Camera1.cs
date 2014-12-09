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
    public class Camera1 : ICamera
    {
        public Rectangle Viewport { get; set; }
        private Level level;
        public Camera1(Level level, int x = 0, int y = 0, int width = 800, int height = 480)
        {
            this.level = level;
            this.Viewport = new Rectangle(x, y, width, height);
        }

        public void Update()
        {
            if (level.player.Position.X - Viewport.X > (Viewport.Width / 2))
            {
                Viewport = new Rectangle((int)level.player.Position.X - Viewport.Width / 2, Viewport.Y, Viewport.Width, Viewport.Height);
            }
            if (Viewport.X + Viewport.Width > level.Size.Width)
            {
                Viewport = new Rectangle(level.Size.Width - Viewport.Width, Viewport.Y, Viewport.Width, Viewport.Height);
            }
        }

        public void SetBack(int setback)
        {
            int difference = (int)level.player.Position.X - setback;
            level.player.Position = new Vector2(setback, level.player.Position.Y);
            Viewport = new Rectangle(Viewport.X - difference, Viewport.Y, Viewport.Width, Viewport.Height);

            level.camXNow = level.camera.Viewport.Right / HotDAMN.GRID;
            level.camXThen = -HotDAMN.OFFSCREEN_LEVEL_LOAD_BLOCKS;
        }

        public bool IsInView(ITangible obj)
        {
            bool offLeftSide = obj.Hitbox.Right() < Viewport.X - HotDAMN.OFFSCREEN_TOLERANCE;
            bool offRightSide = obj.Hitbox.Left() > Viewport.X + Viewport.Width + HotDAMN.OFFSCREEN_TOLERANCE;
            
            bool inView =
                !offLeftSide &&
                !offRightSide &&
                obj.Hitbox.Bottom() >= Viewport.Y - HotDAMN.OFFSCREEN_TOLERANCE &&
                obj.Hitbox.Top() - HotDAMN.OFFSCREEN_TOLERANCE <= Viewport.Y + Viewport.Height;
            
            if (offLeftSide)
            {
                obj.IsActive = false;
            }
            if (obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingRight || obj is IProjectile)
            {
                if (offRightSide)
                {
                    obj.IsActive = false;
                }
            }
            return inView;
        }
    }
}
