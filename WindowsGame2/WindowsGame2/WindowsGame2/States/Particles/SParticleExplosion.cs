using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class SParticleExplosion : IParticleState
    {
        public IParticle Particle { get; set; }
        private int timer;
        private int timeLimit;
        public SParticleExplosion(IParticle particle, int time)
        {
            this.Particle = particle;
            timer = 0;
            timeLimit = time;
        }

        public void Update()
        {
           if (timer > timeLimit)
           {
               Particle.IsActive = false;
           }
           timer++;
        }
    }
}
