using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FlagpoleAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int poleHeight;


        public FlagpoleAnimation(Texture2D texture, int poleHeight)
        {
            this.Texture = texture;
            this.poleHeight = poleHeight;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width;
            int height = Texture.Height / 2 * poleHeight;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, Texture.Height / 2);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, Texture.Height / 2);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);

            sourceRectangle = new Rectangle(0, Texture.Height / 2, width, Texture.Height / 2);

            for (int i = 1; i < poleHeight; i++)
            {
                DestinationRectangle = new Rectangle(x, y + Texture.Height / 2 * i, width, Texture.Height / 2);
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
