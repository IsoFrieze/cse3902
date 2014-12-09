using System;
using System.Collections.Generic;
using System.Threading;

namespace WindowsGame2Tests
{
    static class UnitTests
    {
        static void Main(string[] args)
        {
            WindowsGame2.Textures.LoadTextureMaps();
            int totalFailures = 0;

            Thread.Sleep(1000); // wait so that it's outuput is last in the Console
            

            List<CollisionTests> tests = new List<CollisionTests>()
            {
                new CollisionMarioGoombaTests(),
                new CollisionMarioKoopaTests(),
                new CollisionMario1UpTests(),
                new CollisionMarioMushroomTests(),
                new CollisionMarioFireFlowerTests(),
                new CollisionMarioStarTests(),
                new CollisionMarioCoinTests(),
            };

            foreach(CollisionTests test in tests)
            {
                Console.WriteLine("--- TEST " + test.tangible2.ToString() + " TEST ---");
                totalFailures += test.Test();

            }

            Console.WriteLine("There were " + totalFailures + " failed tests.");
        }
    }
}

