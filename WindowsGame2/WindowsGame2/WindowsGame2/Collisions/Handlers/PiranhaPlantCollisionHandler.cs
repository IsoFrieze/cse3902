using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class PiranhaPlantCollisionHandler : ICollisionHandler
    {
        IEnemy subject;
        public PiranhaPlantCollisionHandler(IEnemy piranhaPlant)
        {
            this.subject = piranhaPlant;
        }

        public void CollisionAbove(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is IProjectile || (obj.State is SKoopaShellMovingLeft || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_PIRANHAPLANT;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_PIRANHAPLANT));
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                subject.IsActive = false;
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is IProjectile || (obj.State is SKoopaShellMovingLeft || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_PIRANHAPLANT;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_PIRANHAPLANT));
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                subject.IsActive = false;
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is IProjectile || (obj.State is SKoopaShellMovingLeft || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_PIRANHAPLANT;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_PIRANHAPLANT));
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                subject.IsActive = false;
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if ((obj is IPlayer && ((IPlayer)obj).Decorator is StarPlayer) || obj is IProjectile || (obj.State is SKoopaShellMovingLeft || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingRight))
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_KILL_PIRANHAPLANT;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_KILL_PIRANHAPLANT));
                SoundPanel.PlaySoundEffect(Sound.kickEffect);
                subject.IsActive = false;
            }
        }
    }
}
