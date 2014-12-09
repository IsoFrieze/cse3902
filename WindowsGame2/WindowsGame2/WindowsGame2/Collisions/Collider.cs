using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsGame2
{
    public class Collider
    {
        List<String> levelTransition;
        List<Tuple<ITangible, ITangible, CollisionFrom>> collisions;

        Level level;
        public static List<ITangible> statics;
        List<ITangible> dynamics;
        public enum CollisionFrom { None, Above, Below, Left, Right }

        public Collider(Level level)
        {
            if (level != null)
            {
                this.level = level;
                statics = level.statics;
                this.dynamics = level.dynamics;
            }
        }

        public void Update()
        {
            levelTransition = new List<String>();
            collisions = new List<Tuple<ITangible, ITangible, CollisionFrom>>();

            ThreadedCollisionDetection(0);

            foreach (Tuple<ITangible, ITangible, CollisionFrom> t in collisions)
            {
                ActuallyPerformCollision(t);
            }

            BlockPipe wall = new BlockPipe(
                null,
                200 * HotDAMN.SCREEN_BOUNDARY_OFFSET + (HotDAMN.WINDOW_HEIGHT / HotDAMN.GRID),
                false,
                level.camera.Viewport.Left - Hitboxes.PIPE_WIDTH + HotDAMN.SCREEN_MARIO_CUSION,
                -HotDAMN.SCREEN_BOUNDARY_OFFSET
                    );
            CollisionFrom direction = CollisionDirection(level.player, wall);
            if (direction != CollisionFrom.None) { level.player.CollisionHandler.CollisionLeft(wall); }
            wall = new BlockPipe(
                null,
                200 * HotDAMN.SCREEN_BOUNDARY_OFFSET + (HotDAMN.WINDOW_HEIGHT / HotDAMN.GRID),
                false,
                level.camera.Viewport.Right - HotDAMN.SCREEN_MARIO_CUSION,
                -HotDAMN.SCREEN_BOUNDARY_OFFSET
                    );
            direction = CollisionDirection(level.player, wall);
            if (direction != CollisionFrom.None) { level.player.CollisionHandler.CollisionRight(wall); }

            level.RemoveInactives(dynamics);
            level.RemoveInactives(statics);
        }

        public void ThreadedCollisionDetection(int start)
        {
            for (int i = start; i < dynamics.Count; i++)
            {
                for (int j = 0; j < statics.Count; j++)
                {
                    TestCollision(dynamics[i], statics[j]);
                }

                for (int j = i + 1; j < dynamics.Count; j++)
                {
                    TestCollision(dynamics[i], dynamics[j]);
                }
            }
        }

        public void TestCollision(ITangible dyn, ITangible obj)
        {
            CollisionFrom direction = CollisionDirection(dyn, obj);

            if (direction != CollisionFrom.None)
            {
                collisions.Add(new Tuple<ITangible, ITangible, CollisionFrom>(dyn, obj, direction));
            }
        }

        public void ActuallyPerformCollision(Tuple<ITangible, ITangible, CollisionFrom> tuple)
        {
            ITangible dyn = tuple.Item1;
            ITangible obj = tuple.Item2;
            CollisionFrom direction = tuple.Item3;

            switch (direction)
            {
                case CollisionFrom.Above:
                    dyn.CollisionHandler.CollisionAbove(obj);
                    obj.CollisionHandler.CollisionBelow(dyn);
                    break;
                case CollisionFrom.Below:
                    dyn.CollisionHandler.CollisionBelow(obj);
                    obj.CollisionHandler.CollisionAbove(dyn);
                    break;
                case CollisionFrom.Left:
                    dyn.CollisionHandler.CollisionLeft(obj);
                    obj.CollisionHandler.CollisionRight(dyn);
                    break;
                case CollisionFrom.Right:
                    dyn.CollisionHandler.CollisionRight(obj);
                    obj.CollisionHandler.CollisionLeft(dyn);
                    break;
                default:
                    break;
            }

            if (obj is LevelTransitionPoint && dyn is IPlayer && direction != CollisionFrom.None)
            {
                String go = ((LevelTransitionPoint)obj).Go;
                if (levelTransition.Contains(go) && ((LevelTransitionPoint)obj).IsCorrectDirection((IPlayerState)(dyn.State)))
                {
                    if (((IPlayer)dyn).AutoMove != null)
                    {
                        ((IPlayer)dyn).AutoMove.IsActive = false;
                    }
                    HUD.MARIO_STATE[HUD.currentPlayer] = (IPlayerState)(dyn.State);
                    int time = HUD.TIME;
                    if (go.IndexOf(HotDAMN.TAG_SUBLEVEL) == -1 && go.IndexOf(HotDAMN.TAG_NAME) == -1)
                    {
                        level.game.state = new SLevelIntro(level.game, go);
                    }
                    else
                    {
                        level.game.state = new SInLevel(level.game, go);
                    }
                    SoundPanel.PlaySoundEffect(Sound.pipeEffect);
                    HUD.TIME = time;
                }
                else
                {
                    levelTransition.Add(go);
                }
            }
            if (((dyn is FlagpoleFlag && obj is IPlayer) ||
                (obj is FlagpoleFlag && dyn is IPlayer)) &&
                direction != CollisionFrom.None
                )
            {
                level.game.state = new SLevelComplete(level.game, ((SInLevel)level.game.state));
            }
            if (((dyn is Axe && obj is IPlayer) ||
                (obj is Axe && dyn is IPlayer)) &&
                direction != CollisionFrom.None
                )
            {
                level.game.state = new SCastleComplete(level.game, ((SInLevel)level.game.state));
            }
        }

        public CollisionFrom CollisionDirection(ITangible obj1, ITangible obj2)
        {
            if (!level.camera.IsInView(obj1) || !level.camera.IsInView(obj2))
            {
                return CollisionFrom.None;
            }

            CollisionFrom direction = CollisionFrom.None;
            for (double i = HotDAMN.COLLISION_RESOLUTION; i <= 1.0 && direction == CollisionFrom.None; i += HotDAMN.COLLISION_RESOLUTION)
            {
                Rectangle r1 = TweenRectangles(obj1.Hitbox.hitboxThen, obj1.Hitbox.hitboxNow, i);
                Rectangle r2 = TweenRectangles(obj2.Hitbox.hitboxThen, obj2.Hitbox.hitboxNow, i);

                Rectangle zone = Rectangle.Intersect(r1, r2);

                if (zone.IsEmpty)
                {
                    continue;
                }

                if (zone.Width + 2 < zone.Height)
                {
                    if ((zone.Left + zone.Right) / 2 < (r1.Left + r1.Right) / 2)
                    {
                        return CollisionFrom.Left;
                    }
                    else
                    {
                        return CollisionFrom.Right;
                    }
                }
                else
                {
                    if ((zone.Top + zone.Bottom) / 2 < (r1.Top + r1.Bottom) / 2)
                    {
                        return CollisionFrom.Above;
                    }
                    else
                    {
                        return CollisionFrom.Below;
                    }
                }
            }
            return CollisionFrom.None;
        }

        private Rectangle TweenRectangles(Rectangle a, Rectangle b, double percent)
        {
            double x = (b.X - a.X) * percent + a.X;
            double y = (b.Y - a.Y) * percent + a.Y;
            double w = (b.Width - a.Width) * percent + a.Width;
            double h = (b.Height - a.Height) * percent + a.Height;

            return new Rectangle((int)x, (int)y, (int)w, (int)h);
        }
    }
}
