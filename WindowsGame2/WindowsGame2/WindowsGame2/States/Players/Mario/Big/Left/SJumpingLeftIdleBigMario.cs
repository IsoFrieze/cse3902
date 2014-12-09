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
    public class SJumpingLeftIdleBigMario : IBigMarioState, IJumpingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }

        public SJumpingLeftIdleBigMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.bigLeftJumping);

            Player.Hitbox.SetOffset(Hitboxes.BIG_MARIO_JUMP_OFFSET_X, Hitboxes.BIG_MARIO_JUMP_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            if (!(player.State is IJumpingMarioState))
            {
                Player.Velocity += new Vector2(0f, -6f);
                SoundPanel.PlaySoundEffect(Sound.jumpsuperEffect);
            }
            Player.Acceleration = Physics.GRAVITY;
        }

        public void Update()
        {
            HUD.HangTime++;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    Hitboxes.BIG_MARIO_JUMP_WIDTH,
                    Hitboxes.BIG_MARIO_JUMP_HEIGHT
                );
        }

        public void GoLeft()
        {
            Player.State = new SJumpingLeftBigMario(Player);
        }

        public void GoRight()
        {
            Player.State = new SJumpingRightBigMario(Player);
        }

        public void GoUp()
        {

        }

        public void GoDown()
        {

        }

        public void GoNowhere()
        {
            if (Player.Velocity.Y == 0)
            {
                Player.State = new SIdleLeftBigMario(Player);
            }
        }

        public void Jump()
        {

        }

        public void HoldJump()
        {
            if (Player.Velocity.Y < 0)
            {
                Player.Velocity -= new Vector2(0, 0.54f * (1.0f + (0.01f * Math.Abs(Player.Velocity.X))));
            }
            else if (Player.Velocity.Y > 0)
            {
                Player.Velocity -= new Vector2(0, 0.1f);
            }
        }

        public void Run()
        {
            ((Mario)Player).IsRunning = true;
        }

        public void Climb()
        {
            Player.State = new SClimbingIdleLeftBigMario(Player);
        }

        public void PowerUp()
        {
            Player.State = new SMarioTansition(Player, typeof(SJumpingLeftIdleFireMario), Textures.fireJumpingIdleTransitionLeft);
        }

        public void PowerDown()
        {
            Player.State = new SMarioTansition(Player, typeof(SJumpingLeftIdleSmallMario), Textures.bigSmallTransitionLeft); 
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }

    }
}