using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PipeAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }

        private int pipeHeight, setting;
        private bool showtop;

        public PipeAnimation(Texture2D texture, int pipeHeight, bool showtop)
        {
            this.Texture = texture;
            this.pipeHeight = pipeHeight;
            this.showtop = showtop;
            this.setting = HUD.setting;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width;
            int height = Texture.Height / 2 * pipeHeight / 4;

            Rectangle sourceRectangle = new Rectangle(0, (showtop ? 0 : Texture.Height / 8) + setting * 32, width, Texture.Height / 8);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, Texture.Height / 8);

            spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);

            sourceRectangle = new Rectangle(0, Texture.Height / 8 + setting * 32, width, Texture.Height / 8);

            for (int i = 1; i < pipeHeight; i++)
            {
                DestinationRectangle = new Rectangle(x, y + Texture.Height / 8 * i, width, Texture.Height / 8);
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
