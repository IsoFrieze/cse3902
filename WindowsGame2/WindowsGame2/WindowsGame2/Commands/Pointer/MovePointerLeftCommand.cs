using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MovePointerLeftCommand : ITechnicalCommand
    {
        Pointer pointer;

        public MovePointerLeftCommand(Pointer pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            pointer.MoveLeft();
        }
    }
}
