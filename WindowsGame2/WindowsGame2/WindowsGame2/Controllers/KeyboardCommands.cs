using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsGame2
{
    public class KeyboardCommands : IController
    {
        public Dictionary<KeyboardState, ICommand> keyCommands;
        KeyboardState state;
        public delegate void Customization();
        public Customization CustomUpdate;

        public KeyboardCommands(Game1 game = null, Pointer pointer = null, 
            Level level = null)
        {
            state = new KeyboardState(null);
            this.keyCommands = new Dictionary<KeyboardState, ICommand>();

            CustomUpdate = () => { };
            if (game != null)
                AddBasicGameKeyboard(game);
            if (pointer != null)
                AddBasicPointerKeyboard(pointer);
            if (level != null)
                AddBasicLevelKeyboard(level);
        }

        public void Update()
        {
            state.Update();
            foreach (KeyValuePair<KeyboardState, ICommand> keyCommand in 
                keyCommands)
                if (state.Contains(keyCommand.Key))
                    CommandScheduler.Queue(keyCommand.Value);
            CustomUpdate();
        }

        void AddBasicGameKeyboard(Game1 game)
        {
            keyCommands.Add(new KeyboardState(isPressed: Keys.Q), 
                new CommandExit(game));
            
            keyCommands.Add(new KeyboardState(justPressed: Keys.R), 
                new ResetCommand(game));
            keyCommands.Add(new KeyboardState(justPressed: Keys.M), 
                new CommandMute());

            keyCommands.Add(new KeyboardState(justReleased: Keys.Enter),
                new PauseGameCommand(game));
            keyCommands.Add(new KeyboardState(justReleased: Keys.T),
                new RandomizeTextures());
            keyCommands.Add(new KeyboardState(justReleased: Keys.S),
                new RandomizeSounds());
            keyCommands.Add(new KeyboardState(justReleased: Keys.N),
                new RandomizeConstants());
            keyCommands.Add(new KeyboardState(justReleased: Keys.H),
                new PersonifyTextures());
        }

        void AddBasicPointerKeyboard(Pointer pointer)
        {
            keyCommands.Add(new KeyboardState(justPressed: Keys.Up), 
                new MovePointerUpCommand(pointer));
            keyCommands.Add(new KeyboardState(justPressed: Keys.Down), 
                new MovePointerDownCommand(pointer));
            keyCommands.Add(new KeyboardState(justPressed: Keys.Left), 
                new MovePointerLeftCommand(pointer));
            keyCommands.Add(new KeyboardState(justPressed: Keys.Right), 
                new MovePointerRightCommand(pointer));
        }

        void AddBasicLevelKeyboard(Level level)
        {
            IPlayer player = level.player;

            keyCommands.Add(new KeyboardState(stillPressed: Keys.Up), 
                new GoUpPlayerCommand(player));
            keyCommands.Add(new KeyboardState(stillPressed: Keys.Down), 
                new GoDownPlayerCommand(player));
            keyCommands.Add(new KeyboardState(stillPressed: Keys.Left), 
                new GoLeftPlayerCommand(player));
            keyCommands.Add(new KeyboardState(stillPressed: Keys.Right), 
                new GoRightPlayerCommand(player));
            keyCommands.Add(new KeyboardState(stillPressed: Keys.Z), 
                new RunPlayerCommand(player));
            keyCommands.Add(new KeyboardState(justPressed: Keys.C),
                new JumpPlayerCommand(player));

            keyCommands.Add(new KeyboardState(justPressed: Keys.C),
                new JumpPlayerCommand(player));
            keyCommands.Add(new KeyboardState(justPressed: Keys.Z), 
                new ThrowFireballCommand(level, player));

            keyCommands.Add(new KeyboardState(stillPressed: Keys.C),
                new HoldJumpPlayerCommand(player));

            CustomUpdate += () =>
            {
                if (!CommandScheduler.AnyIsQueued(new List<Type>()
                {
                    typeof(GoUpPlayerCommand), typeof(GoDownPlayerCommand), 
                    typeof(GoLeftPlayerCommand), typeof(GoRightPlayerCommand)
                })) CommandScheduler.Queue(new NoPlayerActionCommand(player));
            };
        }
    }
}
