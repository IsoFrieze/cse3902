using System.Linq;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace WindowsGame2
{
    public class KeyboardState
    {
        public Keys[] wasPressed, isPressed, justPressed, stillPressed, 
            justReleased;

        public KeyboardState(Keys[] wasPressed = null, Keys[] isPressed = null, 
            Keys[] justPressed = null, Keys[] stillPressed = null, 
            Keys[] justReleased = null)
        {
            this.wasPressed = (wasPressed != null) ? wasPressed : new Keys[0];
            this.isPressed = (isPressed != null) ? isPressed : new Keys[0];
            this.justPressed = (justPressed != null) ? justPressed : new Keys[0];
            this.stillPressed = (stillPressed != null) ?
                stillPressed : new Keys[0];
            this.justReleased = (justReleased != null) ?
                justReleased : new Keys[0];
        }

        public KeyboardState(Keys wasPressed = Keys.None, 
            Keys isPressed = Keys.None, Keys justPressed = Keys.None, 
            Keys stillPressed = Keys.None, Keys justReleased = Keys.None)
        {
            this.wasPressed = (wasPressed != Keys.None) ? 
                new[] { wasPressed } : new Keys[0];
            this.isPressed = (isPressed != Keys.None) ?
                new[] { isPressed } : new Keys[0];
            this.justPressed = (justPressed != Keys.None) ?
                new[] { justPressed } : new Keys[0];
            this.stillPressed = (stillPressed != Keys.None) ?
                new[] { stillPressed } : new Keys[0];
            this.justReleased = (justReleased != Keys.None) ?
                new[] { justReleased } : new Keys[0];
        }

        public bool Contains(KeyboardState state)
        {
            return Contains(wasPressed, state.wasPressed) && 
                Contains(isPressed, state.isPressed) && 
                Contains(justPressed, state.justPressed) && 
                Contains(stillPressed, state.stillPressed) && 
                Contains(justReleased, state.justReleased);
        }

        bool Contains(Keys[] keys1, Keys[] keys2)
        {
            foreach (Keys key2 in keys2)
                if (!keys1.Contains(key2))
                    return false;
            return true;
        }

        public void Update()
        {
            wasPressed = isPressed;
            isPressed = Keyboard.GetState().GetPressedKeys();

            justPressed = isPressed.Except(wasPressed).ToArray();
            stillPressed = isPressed.Intersect(wasPressed).ToArray();
            justReleased = wasPressed.Except(isPressed).ToArray();
        }
    }
}