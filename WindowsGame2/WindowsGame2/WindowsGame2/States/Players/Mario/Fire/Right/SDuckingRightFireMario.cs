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
    public class SDuckingRightFireMario : IFireMarioState, IDuckingMarioState, IRightMarioState
    {
        public IPlayer Player { get; set; }

        public SDuckingRightFireMario(IPlayer player)
        {
            this.Player = player;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.fireRightDucking);

            Player.Hitbox.SetOffset(Hitboxes.BIG_MARIO_DUCK_OFFSET_X, Hitboxes.BIG_MARIO_DUCK_OFFSET_Y);
            Player.Hitbox.Clear();
            SetHitbox();

            Player.Acceleration = Physics.GRAVITY;
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
                    Hitboxes.BIG_MARIO_DUCK_WIDTH,
                    Hitboxes.BIG_MARIO_DUCK_HEIGHT
                );
        }

        public void GoLeft()
        {

        }

        public void GoRight()
        {

        }

        public void GoUp()
        {

        }

        public void GoDown()
        {
            Player.Velocity = new Vector2(0.9f * Player.Velocity.X, Player.Velocity.Y);
        }

        public void GoNowhere()
        {
            Player.State = new SIdleRightFireMario(Player);
        }

        public void Jump()
        {
            Player.State = new SJumpingRightIdleFireMario(Player);
        }

        public void HoldJump()
        {

        }

        public void Run()
        {
            ((Mario)Player).IsRunning = true;
        }

        public void Climb()
        {
            Player.State = new SClimbingIdleRightFireMario(Player);
        }

        public void PowerUp()
        {

        }

        public void PowerDown()
        {
            Player.State = new SMarioTansition(Player, typeof(SIdleRightSmallMario), Textures.bigSmallTransitionRight);
        }

        public void KillMe()
        {
            Player.State = new SDeadMario(Player);
        }
    }
}
