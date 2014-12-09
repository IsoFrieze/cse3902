using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class StarCollisionHandler : ICollisionHandler
    {
        IPowerUp subject;
        public StarCollisionHandler(IPowerUp powerup)
        {
            this.subject = powerup;
        }

        public void CollisionAbove(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_STAR;
                subject.IsActive = false;
            }
            else if (type is IBlock && !(type is BlockHidden && type.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)type).Hitbox.Bottom());
                subject.Velocity = new Vector2(subject.Velocity.X, 0.1f);
            }
        }
        public void CollisionBelow(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_STAR;
                subject.IsActive = false;
            }
            else if (type is IBlock && !(type is BlockHidden && type.State is SBlockIdle))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)type).Hitbox.Top() - Hitboxes.STAR_HEIGHT - Hitboxes.STAR_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, -Physics.TERMINAL_VELOCITY_STAR);
            }
        }
        public void CollisionLeft(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_STAR;
                subject.IsActive = false;
            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new SStarBouncingRight(subject);
            }
        }
        public void CollisionRight(ITangible type)
        {
            if (type is IPlayer)
            {
                HUD.SCORE[HUD.currentPlayer] += HotDAMN.SCORE_COLLECT_STAR;
                subject.IsActive = false;
            }
            else if (!(type is IEnemy || type is IPowerUp))
            {
                subject.State = new SStarBouncingLeft(subject);
            }
        }
    }
}
