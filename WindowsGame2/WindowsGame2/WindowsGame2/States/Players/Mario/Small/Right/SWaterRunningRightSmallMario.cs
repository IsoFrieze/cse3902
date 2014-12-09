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
    public class SWaterRunningRightSmallMario : ISmallMarioState, IRunningMarioState, IRightMarioState
    {
        public IPlayer Player { get; set; }

        public SWaterRunningRightSmallMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, ((Mario)Player).IsRunning ? Textures.smallRightRunning : Textures.smallRightWalking);

            Player.Hitbox.SetOffset(Hitboxes.SMALL_MARIO_RUN_OFFSET_X, Hitboxes.SMALL_MARIO_RUN_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            Player.Acceleration = new Vector2(0.1f, Player.Acceleration.Y);
        }

        public void Update()
        {
            HUD.HangTime = 0;
            Player.SequenceCounter = 0;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    Hitboxes.SMALL_MARIO_RUN_WIDTH,
                    Hitboxes.SMALL_MARIO_RUN_HEIGHT
                );
        }

        public void GoLeft()
        {
            Player.State = new SWaterRunningLeftSmallMario(Player);
        }

        public void GoRight()
        {
            if (Player.Velocity.X < 0)
            {
                Player.Velocity = new Vector2(0.9f * Player.Velocity.X, Player.Velocity.Y);
            }
        }

        public void GoUp()
        {

        }

        public void GoDown()
        {
            Player.State = new SWaterDuckingRightSmallMario(Player);
        }

        public void GoNowhere()
        {
            Player.State = new SWaterIdleRightSmallMario(Player);
        }

        public void Jump()
        {
            Player.State = new SWaterSwimmingRightSmallMario(Player);
            ((IPlayerState)Player.State).Jump();
        }

        public void HoldJump()
        {

        }

        public void Run()
        {
            
        }

        public void Climb()
        {
            
        }

        public void PowerUp()
        {
            Player.State = new SMarioTansition(Player, typeof(SWaterRunningRightBigMario), Textures.smallBigTransitionRight);
        }

        public void PowerDown()
        {
            Player.State = new SDeadMario(Player);
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }
    }
}