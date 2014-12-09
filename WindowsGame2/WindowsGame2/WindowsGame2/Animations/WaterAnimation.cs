using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class WaterAnimation: IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        private int totalWidth, totalHeight, setting;

        public WaterAnimation(Texture2D texture, int width, int height)
        {
            this.Texture = texture;
            this.setting = HUD.setting;
            this.totalWidth = width;
            this.totalHeight = height;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width;
            int height = Texture.Height / 2 / 4;

            for (int i = 0; i < totalHeight; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, (i == 0 ? 0 : height) + (height * 2 * setting), width, height);
                for (int j = 0; j < totalWidth; j++)
                {
                    Rectangle DestinationRectangle = new Rectangle(x + HotDAMN.GRID * j, y + HotDAMN.GRID * i, width, height);
                    spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, Rectangle hitbox)
        {
            Draw(spriteBatch, x, y);

            Texture2D pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            spriteBatch.Draw(pixel, new Rectangle(hitbox.X, hitbox.Y, hitbox.Width, 1), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(hitbox.X, hitbox.Y + hitbox.Height - 1, hitbox.Width, 1), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(hitbox.X, hitbox.Y, 1, hitbox.Height), Color.Red);
            spriteBatch.Draw(pixel, new Rectangle(hitbox.X + hitbox.Width - 1, hitbox.Y, 1, hitbox.Height), Color.Red);
        }
    }
}
