using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class CoinCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public CoinCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_COIN;
                HUD.COINS[HUD.currentPlayer]++;
                SoundPanel.PlaySoundEffect(Sound.coinEffect);
            }

        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {

                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_COIN;
                HUD.COINS[HUD.currentPlayer]++;
                subject.IsActive = false;
                SoundPanel.PlaySoundEffect(Sound.coinEffect);
            }
            if (type is IBlock)
            {
                if ((type.State is SBlockGettingBumped || type.State is SBlockBroken) && !(subject.State is SCoinSpawning))
                {
                    subject.State = new SCoinSpawning(subject);
                    
                }
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_COIN;
                HUD.COINS[HUD.currentPlayer]++;
                SoundPanel.PlaySoundEffect(Sound.coinEffect);
            }

        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                subject.IsActive = false;
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_COIN;
                HUD.COINS[HUD.currentPlayer]++;
                SoundPanel.PlaySoundEffect(Sound.coinEffect);
            }
        }
    }
}
