using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame2;

namespace WindowsGame2Tests
{
    public class CollisionTests
    {
        public class PhysicsBundle
        {
            public Vector2 position;
            public Vector2 velocity;
            public Vector2 acceleration;

            public PhysicsBundle(int pX, int pY, int vX = 0, int vY = 0, int aX = 0, int aY = 0)
            {
                WindowsGame2.Textures.LoadTextureMaps();
                position = new Vector2(pX, pY);
                velocity = new Vector2(vX, vY);
                acceleration = new Vector2(aX, aY);
            }
        }

        Collider collider = new Collider(null);
        public List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>> collisions;
        public ITangible tangible1;
        public ITangible tangible2;

        public CollisionTests()
        {
            tangible1 = new Mario();
            tangible2 = new Goomba();
            collisions = new List<Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom>>();
        }

        public int Test()
        {
            int fails = 0;
            foreach (Tuple<ITangibleState, PhysicsBundle, ITangibleState, PhysicsBundle, Collider.CollisionFrom> tuple in collisions)
            {
                SetTangible(tangible1, tuple.Item1, tuple.Item2);
                SetTangible(tangible2, tuple.Item3, tuple.Item4);
                if (!TestCollision(tangible1, tangible2, tuple.Item5))
                {
                    fails++;
                }
            }
            return fails;
        }

        public void SetTangible(ITangible tangible, ITangibleState state, PhysicsBundle physics)
        {
            tangible.State = state;
            tangible.Position = physics.position;
            tangible.Velocity = physics.velocity;
            tangible.Acceleration = physics.acceleration;
        }

        public Boolean TestCollision(ITangible tangible1, ITangible tangible2, WindowsGame2.Collider.CollisionFrom expected)
        {
            tangible1.Update();
            tangible2.Update();

            WindowsGame2.Collider.CollisionFrom returned = collider.CollisionDirection(tangible1, tangible2);
            Console.WriteLine("Expected " + expected.ToString() + ", and got " + returned.ToString());
            return expected == returned;
        }
    }
}
