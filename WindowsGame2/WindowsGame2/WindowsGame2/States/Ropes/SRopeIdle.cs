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
    // The block is idle.
    public class SRopeIdle : IRopeState
    {
        public IRope Rope { get; set; }

        private int height;

        public SRopeIdle(IRope rope, int height)
        {
            this.Rope = rope;
            this.height = height;

            SetHitbox();
        }

        public void Update()
        {
            Rope.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Rope.Hitbox.AddRectHitbox(
                    (int)Rope.Position.X,
                    (int)Rope.Position.Y,
                    Hitboxes.ROPE_WIDTH,
                    Hitboxes.ROPE_HEIGHT * height
                );
        }
    }
}
