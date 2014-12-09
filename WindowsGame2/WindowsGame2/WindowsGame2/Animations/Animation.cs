using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class Animation: IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        
        private int totalFrames, counter, speed;
        public int currentFrame;

        public Animation(Texture2D texture, int frames = 1, int speed = 1, int startFrame = 0, int startCounter = 0)
        {
            this.Texture = texture;
            this.totalFrames = frames;
            this.speed = speed;
            this.counter = startCounter;
            this.currentFrame = startFrame;
        }

        public void Update()
        {
            if (counter % speed == 0)
            {
                currentFrame++;

                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            counter++;     
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / totalFrames;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, height);
            Rectangle DestinationRectangle = new Rectangle(x, y, width, height);

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
