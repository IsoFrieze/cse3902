using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class Physics
    {
        public static Vector2 GRAVITY = new Vector2(0, 0.1f);
        public static float TERMINAL_VELOCITY_FALLING = 8f;
        public static float TERMINAL_VELOCITY_WALKING = 1.5f;
        public static float TERMINAL_VELOCITY_RUNNING = 3f;

        public static float TERMINAL_VELOCITY_FIREBALL = 5f;
        public static float TERMINAL_VELOCITY_STAR = 5f;
        public static float TERMINAL_VELOCITY_KOOPA = 5f;
    }
}
