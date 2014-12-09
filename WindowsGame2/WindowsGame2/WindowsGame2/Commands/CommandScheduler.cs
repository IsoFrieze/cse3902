using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class CommandScheduler
    {
        static List<ICommand> commands = new List<ICommand>();
        static IAutoMovement autoMove;

        public static void Queue(ICommand c, IAutoMovement source = null)
        {
            if (source != null)
            {
                commands.Add(c);
                autoMove = source;
            }
            else
            {
                if (autoMove != null && autoMove.IsActive && !(c is ITechnicalCommand))
                {
                    // reject
                }
                else
                {
                    commands.Add(c);
                }
            }
        }

        public static void Queue(List<ICommand> cs, IAutoMovement source = null)
        {
            foreach (ICommand c in cs)
            {
                if (source != null)
                {
                    commands.Add(c);
                    autoMove = source;
                }
                else
                {
                    if (autoMove != null && autoMove.IsActive && !(c is ITechnicalCommand))
                    {
                        // reject
                    }
                    else
                    {
                        commands.Add(c);
                    }
                }
            }
        }

        public static void ExecuteAll()
        {
//            Console.WriteLine("Command: ");
            while (commands.Count > 0)
            {
                commands[0].Execute();
                commands.RemoveAt(0);
            }
        }

        public static bool IsQueued(Type type)
        {
            foreach (ICommand c in commands)
                if (type == c.GetType())
                    return true;

            return false;
        }

        public static bool AnyIsQueued(List<Type> list)
        {
            foreach (Type type in list)
                if (IsQueued(type))
                    return true;

            return false;
        }
    }
}
