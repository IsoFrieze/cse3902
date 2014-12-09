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
    public class SWaterSwimmingLeftIdleBigMario : IBigMarioState, IJumpingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }

        public SWaterSwimmingLeftIdleBigMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.bigLeftSwimming);

            Player.Hitbox.SetOffset(Hitboxes.BIG_MARIO_SWIM_OFFSET_X, Hitboxes.BIG_MARIO_SWIM_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            

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
                    Hitboxes.BIG_MARIO_SWIM_WIDTH,
                    Hitboxes.BIG_MARIO_SWIM_HEIGHT
                );
        }

        public void GoLeft()
        {
            Player.State = new SWaterSwimmingLeftBigMario(Player);
        }

        public void GoRight()
        {
            Player.State = new SWaterSwimmingRightBigMario(Player);
        }

        public void GoUp()
        {

        }

        public void GoDown()
        {
            Player.State = new SWaterDuckingLeftBigMario(Player);
        }

        public void GoNowhere()
        {
            if (Player.Velocity.Y == 0)
            {
                Player.State = new SWaterIdleLeftBigMario(Player);
            }
        }

        public void Jump()
        {
            Player.Velocity = new Vector2(Player.Velocity.X, -3f);
            SoundPanel.PlaySoundEffect(Sound.swimEffect);
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
            Player.State = new SMarioTansition(Player, typeof(SWaterSwimmingLeftIdleFireMario), Textures.fireJumpingIdleTransitionLeft);
        }

        public void PowerDown()
        {
            Player.State = new SMarioTansition(Player, typeof(SWaterSwimmingLeftIdleSmallMario), Textures.bigSmallTransitionLeft); 
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }

    }
}