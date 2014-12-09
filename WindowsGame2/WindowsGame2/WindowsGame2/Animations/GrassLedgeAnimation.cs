using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class GrassLedgeAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int ledgeHeight;
        private int ledgeWidth;

        public GrassLedgeAnimation(Texture2D texture, int ledgeWidth, int ledgeHeight)
        {
            this.Texture = texture;
            this.ledgeHeight = ledgeHeight;
            this.ledgeWidth = ledgeWidth;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / 3;
            int height = Texture.Height / 2;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);

            for (int i = 1; i < ledgeWidth - 1; i++)
            {
                sourceRectangle = new Rectangle(width, 0, width, height);
                DestinationRectangle = new Rectangle(x + (HotDAMN.GRID*i), y, width, height);
                spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
            }

            sourceRectangle = new Rectangle(2*width, 0, width, height);
            DestinationRectangle = new Rectangle(x + HotDAMN.GRID * (ledgeWidth - 1), y, width, height);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);

            for (int i = 1; i < ledgeWidth - 1; i++)
            {
                for (int j = 1; j < ledgeHeight; j++)
                {
                    sourceRectangle = new Rectangle(width, height, width, height);
                    DestinationRectangle = new Rectangle(x + (HotDAMN.GRID * i), y + (HotDAMN.GRID * j), width, height);
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
