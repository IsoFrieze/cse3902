using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PlatformAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int platformWidth;

        public PlatformAnimation(Texture2D texture, int platformWidth)
        {
            this.Texture = texture;
            this.platformWidth = platformWidth;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            Rectangle sourceRectangle;
            Rectangle DestinationRectangle;

            for (int i = 0; i < platformWidth; i++)
            {
                sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
                DestinationRectangle = new Rectangle(x + (HotDAMN.GRID * i), y, Texture.Width, Texture.Height);

                spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
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
