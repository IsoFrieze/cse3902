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
    public class SWaterSwimmingLeftFireMario : IFireMarioState, IJumpingMarioState, ILeftMarioState
    {
        public IPlayer Player { get; set; }

        public SWaterSwimmingLeftFireMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.fireLeftSwimming);

            Player.Hitbox.SetOffset(Hitboxes.BIG_MARIO_SWIM_OFFSET_X, Hitboxes.BIG_MARIO_SWIM_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            

            Player.Acceleration = new Vector2(-0.1f, Player.Acceleration.Y);
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

        }

        public void GoRight()
        {
            Player.State = new SWaterSwimmingRightFireMario(Player);
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
                Player.State = new SWaterIdleLeftFireMario(Player);
            }
            else
            {
                Player.State = new SWaterSwimmingLeftIdleFireMario(Player);
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

        }

        public void PowerDown()
        {
            Player.State = new SMarioTansition(Player, typeof(SWaterSwimmingLeftSmallMario), Textures.bigSmallTransitionLeft);
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }

    }
}