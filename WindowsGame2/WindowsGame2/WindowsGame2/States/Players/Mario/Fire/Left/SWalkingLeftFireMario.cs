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
    public class WalkingLeftFireMarioState : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }

        IPlayer<IMarioState> mario;
        double x, y;
        double walkSpeed = 0.8;

        public WalkingLeftFireMarioState(IPlayer<IMarioState> mario, int x, int y)
        {
            this.mario = mario;
            this.Sprite = new MarioAnimation(Textures.mario0, Textures.fireLeftWalking);
            this.x = x;
            this.y = y;
        }

        public void Update()
        {
            x -= walkSpeed;

           this.Sprite.Update();
        }

        public double xPos
        {
            get { return this.x; }
        }
        public double yPos
        {
            get { return this.y; }
        }
    }
}