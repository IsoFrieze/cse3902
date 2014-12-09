using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class SMarioTansition : ISmallMarioState
    {
        public IPlayer Player {get;set;}
        public IMarioState transitionState;
        public Type newState;
        public int count = 0;
        private Vector2 oldVelocity;
        private Vector2 oldAcceleration;
        public SMarioTansition(IPlayer player, Type newState, TextureMap newSprite)
        {
            this.oldAcceleration = player.Acceleration;
            this.oldVelocity = player.Velocity;
            this.Player = player;
            this.newState = newState;
            Player.Acceleration = Vector2.Zero;
            Player.Sprite = new MarioAnimation(HUD.currentPlayer == 0 ? Textures.marioTransition : Textures.luigiTransition, newSprite);
            if (newSprite == Textures.bigSmallTransitionLeft || newSprite == Textures.bigSmallTransitionRight)
            {
                SoundPanel.PlaySoundEffect(Sound.pipeEffect);
            }
            
        }
        public void Update()
        {
            Player.Velocity = Vector2.Zero;
            if (count >= HotDAMN.TICKS_UNTIL_MARIO_TRANSITIONS)
            {
                Object[] args = new Object[] { Player };
                Player.State = (IPlayerState)Activator.CreateInstance(newState, args);
                Player.Velocity = oldVelocity;
                Player.Acceleration = oldAcceleration;
                if (Player.State is ISmallMarioState)
                {
                    Player.Decorator = new BlinkingPlayer(Player);
                    
                }
            }
            count++;
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
