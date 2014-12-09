using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MushroomCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public MushroomCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_MUSHROOM;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_MUSHROOM));
                subject.IsActive = false;
                
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_MUSHROOM;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_MUSHROOM));
                subject.IsActive = false;
            
            }
            else if (type is IBlock && !(type is BlockHidden && type.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)type).Hitbox.Top() - Hitboxes.MUSHROOM_HEIGHT - Hitboxes.MUSHROOM_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_MUSHROOM;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_MUSHROOM));
                subject.IsActive = false;
                
            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new SMushroomMovingRight(subject);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_MUSHROOM;
                HUD.level.AddParticle(new Score(subject.Position, HotDAMN.SCORE_COLLECT_MUSHROOM));
                subject.IsActive = false;
             
            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new SMushroomMovingLeft(subject);
            }
        }
    }
}
