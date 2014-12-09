using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SettingDependentAnimation: IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        
        private int currentFrame, totalFrames, counter, speed, setting;

        public SettingDependentAnimation(Texture2D texture, int frames = 1, int speed = 1, int startFrame = 0, int startCounter = 0)
        {
            this.Texture = texture;
            this.setting = HUD.setting;
            this.totalFrames = frames;
            this.speed = speed;
            this.currentFrame = startFrame;
            this.counter = startCounter;
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
            int height = Texture.Height / 4;

            Rectangle sourceRectangle = new Rectangle(width * currentFrame, height * setting, width, height);
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
