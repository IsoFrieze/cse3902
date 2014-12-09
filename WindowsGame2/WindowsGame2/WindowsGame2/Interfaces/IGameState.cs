using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public interface IGameState
    {
        Game1 Game { get; set; }
        void Update();
        void Draw(SpriteBatch sb);

        void Pause();
        void UnPause();
    }
}
