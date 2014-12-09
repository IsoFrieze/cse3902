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
    public class SDeadMario : IMarioState
    {
        public bool IsActive { get; set; }
        public IPlayer Player { get; set; }
        private bool showMario;
        private int counter;

        public SDeadMario(IPlayer player, bool showMario = true)
        {
            this.showMario = showMario;
            this.Player = player;
            this.counter = 0;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.mario0 : Textures.luigi0, Textures.smallDead);

            Player.Hitbox.Clear();
            SetHitbox();

            Player.Velocity = Vector2.Zero;
            Player.Acceleration = Vector2.Zero;
            SoundPanel.PlaySong(Sound.deadTheme, false);
            HUD.LIVES[HUD.currentPlayer]--;
            HUD.MARIO_STATE[HUD.currentPlayer] = null;
            HUD.firstLevelEntrance[HUD.currentPlayer] = false;
            HUD.nextPlayer++;
        }

        public void Update()
        {
            if (counter == HotDAMN.TICKS_UNTIL_MARIO_DEAD_MOVES && showMario)
            {
                Player.Velocity = new Vector2(0, -5f);
                Player.Acceleration = new Vector2(0, 0.25f);
            }
            if (counter == HotDAMN.TICKS_UNTIL_DEAD_ENEMY_REMOVE)
            {
                Player.IsActive = false;
            }
            counter++;
            Player.Hitbox.Cycle();
            SetHitbox();
        }

        private void SetHitbox()
        {
            Player.Hitbox.AddRectHitbox(
                    (int)Player.Position.X,
                    (int)Player.Position.Y,
                    0,
                    0
                );
        }

        public void GoLeft() { }
        public void GoRight() { }
        public void GoUp() { }
        public void GoDown() { }
        public void GoNowhere() { }
        public void Jump() { }
        public void HoldJump() { }
        public void Run() { }
        public void Climb() { }
        public void PowerUp() { }
        public void PowerDown() { }
        public void KillMe() { }
    }
}
