using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public class MovePointerDownCommand : ITechnicalCommand
    {
        Pointer pointer;

        public MovePointerDownCommand(Pointer pointer)
        {
            this.pointer = pointer;
        }

        public void Execute()
        {
            pointer.MoveDown();
        }
    }
}
