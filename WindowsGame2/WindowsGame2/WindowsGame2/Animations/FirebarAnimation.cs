using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class FirebarAnimation: IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        
        private int currentFrame, totalFrames, size, counter, speed, angle;
        private bool ccw;

        public FirebarAnimation(Texture2D texture, int size, bool ccw, int frames = 1, int speed = 1)
        {
            this.Texture = texture;
            this.totalFrames = frames;
            this.speed = speed;
            this.currentFrame = 0;
            this.counter = 0;
            this.size = size;
            this.ccw = ccw;
            this.angle = ccw ? HotDAMN.FIREBAR_POS_UP : HotDAMN.FIREBAR_POS_DOWN;
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

            angle += (ccw ? HotDAMN.FIREBAR_SPEED : -HotDAMN.FIREBAR_SPEED);
            if (angle < 0)
            {
                angle += HotDAMN.FULL_CIRCLE;
            }
            else if (angle >= HotDAMN.FULL_CIRCLE)
            {
                angle -= HotDAMN.FULL_CIRCLE;
            }
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            int width = Texture.Width / totalFrames;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, 0, width, height);
            Rectangle DestinationRectangle;

            for (int i = 0; i < size; i++)
            {
                DestinationRectangle = new Rectangle(
                    (int)(x + ((i * width) * Math.Cos(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE))) + Hitboxes.FIREBAR_OFFSET_X,
                    (int)(y - ((i * height) * Math.Sin(2 * Math.PI * angle / HotDAMN.FULL_CIRCLE))) + Hitboxes.FIREBAR_OFFSET_Y,
                    width,
                    height
                        );
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
