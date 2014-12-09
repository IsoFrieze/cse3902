using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class RopeCollisionHandler : ICollisionHandler
    {
        IRope subject;
        public RopeCollisionHandler(IRope rope)
        {
            this.subject = rope;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer && subject is Vine && ((IPlayer)type).Position.Y < 0)
            {
                LevelTransition((IPlayer)type);
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer && subject is Vine && ((IPlayer)type).Position.Y < 0)
            {
                LevelTransition((IPlayer)type);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer && subject is Vine && ((IPlayer)type).Position.Y < 0)
            {
                LevelTransition((IPlayer)type);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer && subject is Vine && ((IPlayer)type).Position.Y < 0)
            {
                LevelTransition((IPlayer)type);
            }
        }

        public void LevelTransition(IPlayer player)
        {
            String go = ((Vine)subject).go;

            HUD.MARIO_STATE[HUD.currentPlayer] = (IPlayerState)player.State;
            int time = HUD.TIME;

            HUD.level.game.state = new SInLevel(HUD.level.game, go);

            SoundPanel.PlaySoundEffect(Sound.vineEffect);
            HUD.TIME = time;
        }
    }
}
