using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WindowsGame2
{
    class SFallingParticle : IParticleState
    {
        public IParticle Particle { get; set; }

        public SFallingParticle(IParticle particle)
        {
            this.Particle = particle;
            Particle.Acceleration = Physics.GRAVITY;
        }

        public void Update()
        {
            if (Particle.Position.Y > HotDAMN.WINDOW_HEIGHT)
            {
                Particle.IsActive = false;
            }
        }
    }
}
