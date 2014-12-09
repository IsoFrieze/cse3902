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
    class SParticleFlagpolePoints : IParticleState
    {
        public IParticle Particle { get; set; }

        private int timer;
        public SParticleFlagpolePoints(IParticle score)
        {
            this.Particle = score;

            Particle.Velocity = new Vector2(0, -1f);
            Particle.Acceleration = Vector2.Zero;
            timer = 0;
        }

        public void Update()
        {
            if (timer > HotDAMN.TICKS_UNTIL_FLAG_STOPS)
            {
                Particle.Velocity = Vector2.Zero;
            }
            timer++;
        }

    }
}
     
