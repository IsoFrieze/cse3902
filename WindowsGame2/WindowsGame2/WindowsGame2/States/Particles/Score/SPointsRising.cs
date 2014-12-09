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
    class SPointsRising : IParticleState
    {
        public IParticle Particle { get; set; }

        private int timer;
        public SPointsRising(IParticle score)
        {
            this.Particle = score;

            Particle.Velocity = new Vector2(0, -0.6f);
            Particle.Acceleration = Vector2.Zero;
            timer = 0;
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_SCORE_DISAPPEARS)
            {
                Particle.IsActive = false;
            }

            timer++;
        }

    }
}
     
