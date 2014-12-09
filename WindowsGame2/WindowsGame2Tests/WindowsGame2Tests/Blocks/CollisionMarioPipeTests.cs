using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame2;

namespace WindowsGame2Tests
{
    public class CollisionMarioPipeTests : CollisionTests
    {
        Collider collider = new Collider(null);

        public CollisionMarioPipeTests()
            : base()
        {
            tangible1 = new Mario();
            tangible2 = new BlockPipe(null, 6, true);
            collisions = new List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>>()
            {
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 0, 1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(40, 5), WindowsGame2.Collider.CollisionFrom.Below),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 5, 0, -1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(40, 0), WindowsGame2.Collider.CollisionFrom.Above),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, -1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(45, 0), WindowsGame2.Collider.CollisionFrom.Left),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 1), new SBlockIdle((IBlock)tangible2), new PhysicsBundle(45, 0), WindowsGame2.Collider.CollisionFrom.Right),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(0, 0), new S1UpMovingLeft((_1Up)tangible2), new PhysicsBundle(40, 0), WindowsGame2.Collider.CollisionFrom.None),
            };
        }
    }
}
