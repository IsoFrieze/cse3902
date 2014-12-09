using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class EmptyCollisionHandler: ICollisionHandler
    {
        public EmptyCollisionHandler()
        {
        }

        public void CollisionAbove(ITangible type)
        {


        }
        public void CollisionBelow(ITangible type)
        {

        }
        public void CollisionLeft(ITangible type)
        {

        }
        public void CollisionRight(ITangible type)
        {

        }
    }
    }

