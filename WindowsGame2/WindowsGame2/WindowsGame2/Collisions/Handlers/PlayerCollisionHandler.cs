using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        IPlayer subject;
        public PlayerCollisionHandler(IPlayer player)
        {
            this.subject = player;
        }

        public void CollisionAbove(ITangible obj)
        {
            if (obj is BowserFireball || obj is Hammer)
            {
                ICommand c = new PowerDownPlayerCommand(subject);
                CommandScheduler.Queue(c);
            }
            if (obj is Axe)
            {
                DestroyBowserBridge();
                subject.Velocity = new Vector2(subject.Velocity.X, 0f);
                subject.AutoMove = new FinishCastleAutoMovement(subject);
            }
            if (obj is FlagpoleFlag)
            {
                subject.AutoMove = new FinishLevelAutoMovement(subject);
                SoundPanel.PlaySoundEffect(Sound.flagpoleEffect);
            }
            else if (obj is FireFlower || (obj is Mushroom && subject.State is ISmallMarioState))
            {
                ICommand c = new PowerUpPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is Star)
            {
                ICommand c = new StarPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is IEnemy)
            {
                if (!(obj.State is SHammerBroDead || obj.State is SKoopaShelled || obj.State is SKoopaShelledUpsideDown || obj.State is SGoombaStomped || obj.State is SBuzzyBeetleShelled || obj.State is SBuzzyBeetleShelledUpsideDown))
                {
                    ICommand c = new PowerDownPlayerCommand(subject);
                    CommandScheduler.Queue(c);
                }
            }
            else if (obj is IBlock && !(obj is LevelTransitionPoint || obj is MazeCheckpoint || obj is MazeFinish))
            {
                if (subject.State is ISmallMarioState)
                {
                    subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Bottom() - Hitboxes.SMALL_MARIO_IDLE_OFFSET_Y);
                }
                else
                {
                    subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Bottom() - Hitboxes.BIG_MARIO_IDLE_OFFSET_Y);
                }
                subject.Velocity = new Vector2(subject.Velocity.X, 1f);
            }
        }

        public void CollisionBelow(ITangible obj)
        {
            if (obj is BowserFireball || obj is Hammer)
            {
                ICommand c = new PowerDownPlayerCommand(subject);
                CommandScheduler.Queue(c);
            }
            if (obj is Axe)
            {
                DestroyBowserBridge();
                subject.Velocity = new Vector2(subject.Velocity.X, 0f);
                subject.AutoMove = new FinishCastleAutoMovement(subject);
            }
            if (obj is FlagpoleFlag)
            {
                subject.AutoMove = new FinishLevelAutoMovement(subject);
                SoundPanel.PlaySoundEffect(Sound.flagpoleEffect);
            }
            else if (obj is FireFlower || (obj is Mushroom && subject.State is ISmallMarioState))
            {
                ICommand c = new PowerUpPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is Star)
            {
                ICommand c = new StarPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if ((obj is Goomba && !(obj.State is SGoombaStomped)) || (obj is Koopa && !(obj.State is SKoopaShelled || obj.State is SKoopaShelledUpsideDown)))
            {
                subject.Velocity = new Vector2(subject.Velocity.X, -6f);
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle) && !(obj is LevelTransitionPoint || obj is MazeCheckpoint || obj is MazeFinish))
            {
                subject.Position = new Vector2(subject.Position.X, ((IBlock)obj).Hitbox.Top() - Hitboxes.BIG_MARIO_IDLE_HEIGHT - Hitboxes.BIG_MARIO_IDLE_OFFSET_Y);
                subject.Velocity = new Vector2(subject.Velocity.X, 0);
                if (subject.State is IJumpingMarioState)
                {
                    ((IPlayerState)subject.State).GoNowhere();
                }
            }
        }

        public void CollisionLeft(ITangible obj)
        {
            if (obj is BowserFireball || obj is Hammer)
            {
                ICommand c = new PowerDownPlayerCommand(subject);
                CommandScheduler.Queue(c);
            }
            if (obj is Axe)
            {
                DestroyBowserBridge();
                subject.Velocity = new Vector2(subject.Velocity.X, 0f);
                subject.AutoMove = new FinishCastleAutoMovement(subject);
            }
            if (obj is FlagpoleFlag)
            {
                subject.AutoMove = new FinishLevelAutoMovement(subject);
                SoundPanel.PlaySoundEffect(Sound.flagpoleEffect);
            }
            else if (obj is FireFlower || (obj is Mushroom && subject.State is ISmallMarioState))
            {
                ICommand c = new PowerUpPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is Star)
            {
                ICommand c = new StarPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is IEnemy)
            {
                if (!(obj.State is SHammerBroDead || obj.State is SKoopaShelled || obj.State is SKoopaShelledUpsideDown || obj.State is SGoombaStomped || obj.State is SKoopaWarning || obj.State is SKoopaWarningUpsideDown || obj.State is SBuzzyBeetleShelled || obj.State is SBuzzyBeetleShelledUpsideDown || obj.State is SKoopaShellMovingLeft || obj.State is SKoopaUpsideDownShellMovingLeft || obj.State is SBuzzyBeetleShellMovingLeft || obj.State is SBuzzyBeetleUpsideDownShellMovingLeft))
                {
                    ICommand c = new PowerDownPlayerCommand(subject);
                    CommandScheduler.Queue(c);
                }
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle) && !(obj is LevelTransitionPoint || obj is MazeCheckpoint || obj is MazeFinish))
            {
                // handle block collision
                subject.Position = new Vector2(((IBlock)obj).Hitbox.Right() - Hitboxes.SMALL_MARIO_IDLE_OFFSET_X, subject.Position.Y);
                subject.Velocity = new Vector2(0f, subject.Velocity.Y);
            }
            if (obj is IRope)
            {
                if (!(subject.State is IClimbingMarioState) && subject.State is ILeftMarioState)
                {
                    subject.Position = new Vector2(((IRope)obj).Hitbox.Right() - 2, subject.Position.Y);
                    ((IPlayerState)subject.State).Climb();
                }
                else if (obj.Hitbox.Top() - subject.Hitbox.Bottom() > -5 || subject.Hitbox.Top() - obj.Hitbox.Bottom() > -5)
                {
                    subject.Position = new Vector2(subject.Position.X, subject.Position.Y + 1);
                }
            }
        }

        public void CollisionRight(ITangible obj)
        {
            if (obj is BowserFireball || obj is Hammer)
            {
                ICommand c = new PowerDownPlayerCommand(subject);
                CommandScheduler.Queue(c);
            }
            if (obj is Axe)
            {
                DestroyBowserBridge();
                subject.Velocity = new Vector2(subject.Velocity.X, 0f);
                subject.AutoMove = new FinishCastleAutoMovement(subject);
            }
            if (obj is FlagpoleFlag)
            {
                subject.AutoMove = new FinishLevelAutoMovement(subject);
                SoundPanel.PlaySoundEffect(Sound.flagpoleEffect);
            }
            else if (obj is FireFlower || (obj is Mushroom && subject.State is ISmallMarioState))
            {
                ICommand c = new PowerUpPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is Star)
            {
                ICommand c = new StarPlayerCommand(subject);
                CommandScheduler.Queue(c);
                SoundPanel.PlaySoundEffect(Sound.powerupEffect);
            }
            else if (obj is IEnemy)
            {
                if (!(obj.State is SHammerBroDead || obj.State is SKoopaShelled || obj.State is SKoopaShelledUpsideDown || obj.State is SKoopaWarning || obj.State is SKoopaWarningUpsideDown || obj.State is SGoombaStomped || obj.State is SBuzzyBeetleShelled || obj.State is SBuzzyBeetleShelledUpsideDown || obj.State is SKoopaShellMovingRight || obj.State is SKoopaUpsideDownShellMovingRight || obj.State is SBuzzyBeetleShellMovingRight || obj.State is SBuzzyBeetleUpsideDownShellMovingRight))
                {
                    ICommand c = new PowerDownPlayerCommand(subject);
                    CommandScheduler.Queue(c);
                }
            }
            else if (obj is IBlock && !(obj is BlockHidden && obj.State is SBlockIdle) && !(obj is LevelTransitionPoint || obj is MazeCheckpoint || obj is MazeFinish))
            {
                // handle block collision
                subject.Position = new Vector2(((IBlock)obj).Hitbox.Left() - Hitboxes.BLOCK_WIDTH + Hitboxes.SMALL_MARIO_IDLE_OFFSET_X, subject.Position.Y);
                subject.Velocity = new Vector2(0f, subject.Velocity.Y);
            }
            if (obj is IRope)
            {
                if (!(subject.State is IClimbingMarioState) && subject.State is IRightMarioState)
                {
                    subject.Position = new Vector2(((IRope)obj).Hitbox.Left() - Hitboxes.SMALL_MARIO_CLIMBING_WIDTH, subject.Position.Y);
                    ((IPlayerState)subject.State).Climb();
                }
                else if (obj.Hitbox.Top() - subject.Hitbox.Bottom() > -5 || subject.Hitbox.Top() - obj.Hitbox.Bottom() > -5)
                {
                    subject.Position = new Vector2(subject.Position.X, subject.Position.Y + 1);
                }
            }
        }
        public void DestroyBowserBridge() {
            int start = 0;
            while (start < Collider.statics.Count)
            {
                if (Collider.statics[start] is BowserBridge)
                 {
                     Collider.statics[start].IsActive = false;
                 }
                start++;
            }
        }
    }
}
