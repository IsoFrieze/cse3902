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
    public class SBlockBroken : IBlockState
    {
        public IBlock Block { get; set; }
        private int counter;
        
        public SBlockBroken(IBlock block)
        {
            this.Block = block;
            Block.Sprite = new Animation(Textures.blockHidden);

            Block.Hitbox.Clear();
            SetHitbox();

            Block.Velocity = new Vector2(0, -1f);
            SoundPanel.PlaySoundEffect(Sound.breakblockEffect);

            Vector2 brokenBits = Block.Position + new Vector2(4f, 4f);
            HUD.level.AddParticle(new BrokenBrickParticle(brokenBits, new Vector2(1.5f, -1f)));
            HUD.level.AddParticle(new BrokenBrickParticle(brokenBits, new Vector2(-1.5f, -1f)));
            HUD.level.AddParticle(new BrokenBrickParticle(brokenBits, new Vector2(1.5f, -8f)));
            HUD.level.AddParticle(new BrokenBrickParticle(brokenBits, new Vector2(-1.5f, -8f)));
        }

        public void Update()
        {
            if (counter == 5)
            {
                Block.IsActive = false;
            }
            counter++;
            Block.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Block.Hitbox.AddRectHitbox(
                    (int)Block.Position.X,
                    (int)Block.Position.Y,
                    Hitboxes.BLOCK_WIDTH,
                    Hitboxes.BLOCK_HEIGHT
                );
        }
    }
}
