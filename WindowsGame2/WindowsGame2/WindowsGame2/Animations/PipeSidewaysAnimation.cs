using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PipeSidewaysAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int pipeWidth, setting;

        public PipeSidewaysAnimation(Texture2D texture, int pipeWidth)
        {
            this.Texture = texture;
            this.pipeWidth = pipeWidth;
            this.setting = HUD.setting;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / 4;
            int height = Texture.Height / 4;

            Rectangle sourceRectangle = new Rectangle(0, 32 * setting, width, height);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, height);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);

            for (int i = 1; i < pipeWidth; i++)
            {
                sourceRectangle = new Rectangle(width, 32 * setting, width, height);
                DestinationRectangle = new Rectangle(x+width*i, y, width, height);

                spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
            }

            sourceRectangle = new Rectangle(2*width, 32 * setting, 2*width, height);
            DestinationRectangle = new Rectangle(x + HotDAMN.GRID * pipeWidth, y, 2 * width, height);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
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
