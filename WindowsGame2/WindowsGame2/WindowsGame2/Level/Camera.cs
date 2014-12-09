using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Camera : ICamera
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Camera(int width = 800, int height = 480, int x = 0, int y = 0)
        {
            this.PosX = x;
            this.PosY = y;
            this.Width = width;
            this.Height = height;
        }

        public void Update(IPlayer player)
        {
            int playerXPos = (int)player.Position.X;

            if (playerXPos - PosX  > Width / 2)
            {
                PosX = playerXPos - Width / 2;
            }
        }

        public bool IsInView(ITangible obj)
        {
            return
                obj.Position.X + obj.Hitbox.Width >= PosX &&
                obj.Position.X <= PosX + Width &&
                obj.Position.Y + obj.Hitbox.Height >= PosY &&
                obj.Position.Y <= PosY + Height;
        }
    }
}
