using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class BillBlasterAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int poleHeight;

        public BillBlasterAnimation(Texture2D texture, int poleHeight)
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
            int height = Texture.Height / 3;

            for (int i = 0; i < poleHeight; i++)
            {
                Rectangle sourceRectangle = new Rectangle(0, height * (i <= 2 ? i : 2), width, height);
                Rectangle DestinationRectangle = new Rectangle(x, y + height * i, width, height);
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
