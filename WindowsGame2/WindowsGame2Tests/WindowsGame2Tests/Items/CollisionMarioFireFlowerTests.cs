using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame2;

namespace WindowsGame2Tests
{
    public class CollisionMarioFireFlowerTests : CollisionTests
    {
        Collider collider = new Collider(null);

        public CollisionMarioFireFlowerTests()
            : base()
        {
            tangible1 = new Mario();
            tangible2 = new FireFlower();
            collisions = new List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>>()
            {
                // mario FireFlower above collision
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 0, 1), new SFireFlowerIdle((FireFlower)tangible2), new PhysicsBundle(40, 5), WindowsGame2.Collider.CollisionFrom.Below),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 5, 0, -1), new SFireFlowerIdle((FireFlower)tangible2), new PhysicsBundle(40, 0), WindowsGame2.Collider.CollisionFrom.Above),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, -1), new SFireFlowerIdle((FireFlower)tangible2), new PhysicsBundle(45, 0), WindowsGame2.Collider.CollisionFrom.Left),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(40, 0, 1), new SFireFlowerIdle((FireFlower)tangible2), new PhysicsBundle(45, 0), WindowsGame2.Collider.CollisionFrom.Right),
                Tuple.Create<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>(
                    new SIdleLeftBigMario((Mario)tangible1), new PhysicsBundle(0, 0), new SFireFlowerIdle((FireFlower)tangible2), new PhysicsBundle(40, 0), WindowsGame2.Collider.CollisionFrom.None),
            };
        }
    }
}
