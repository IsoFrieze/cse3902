using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2 
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch sb;

        public IGameState state;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); 
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = HotDAMN.WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = HotDAMN.WINDOW_HEIGHT;
        }

        protected override void Initialize() 
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Sound.InitializeSounds(Content);
            sb = new SpriteBatch(GraphicsDevice);
            Textures.InitializeTextures(Content);

            InitializeObjects();
        }

        public void InitializeObjects()
        {
            MediaPlayer.Volume = 0.2f;
            SoundEffect.MasterVolume = 0.2f;
            HUD.Initialize();
            state = new STitleScreen(this);
        }

        protected override void UnloadContent()
        {
            // nothing here
            // another test comment
        }

        protected override void Update(GameTime gameTime)
        {
            state.Update();
            base.Update(gameTime);
            
        }
        protected override void Draw(GameTime gameTime)
        {
            sb.Begin();

            state.Draw(sb);

            sb.End();
            base.Draw(gameTime);
        }
    }
}
