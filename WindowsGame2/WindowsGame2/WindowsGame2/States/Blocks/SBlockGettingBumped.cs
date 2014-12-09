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
    // Block gets lifted up and then returns to starting position.
    public class SBlockGettingBumped : IBlockState
    {
        public IBlock Block { get; set; }
        private float startingYPos;
        private IBlockState finalState;

        public SBlockGettingBumped(IBlock block, IBlockState finalState)
        {
            this.Block = block;
            this.finalState = finalState;
            startingYPos = Block.Position.Y;
            if (finalState is SBlockUsed)
            {
                Block.Sprite = new SettingDependentAnimation(Textures.blockUsed);
            }

            Block.Hitbox.Clear();
            SetHitbox();

            Block.Velocity = new Vector2(0f, -7f);
            Block.Acceleration = new Vector2(0f, 1.5f);
            SoundPanel.PlaySoundEffect(Sound.bumpEffect);

        }

        public void Update()
        {
            if (Block.Position.Y >= startingYPos)
            {
                Block.State = finalState;
                Block.Position = new Vector2(Block.Position.X, startingYPos);
                Block.Velocity = Vector2.Zero;
                Block.Acceleration = Vector2.Zero;
            }
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
