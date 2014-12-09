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
    public class MarioAnimation : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        private int row, column, frames, speed, currentFrame, counter;

        public MarioAnimation(Texture2D texture, TextureMap info)
        {
            this.Texture = texture;
            this.row = info.Row;
            this.column = info.Column;
            this.frames = info.FramesInRow;
            this.speed = info.TimePerFrame;
            this.currentFrame = 0;
            this.counter = 0;
        }

        public void Update()
        {
                if (counter % speed == 0)
                {
                    currentFrame++;

                    if (currentFrame == frames)
                    {
                        currentFrame = 0;
                    }
                }
                counter++;
        }

        public void Draw(SpriteBatch sb, int x, int y)
        {
            int width = Texture.Width / Textures.playerColumns;
            int height = Texture.Height / Textures.playerRows;

            Rectangle sourceRectangle = new Rectangle(width * (column + currentFrame), height * row, width, height);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, height);

            sb.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
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
