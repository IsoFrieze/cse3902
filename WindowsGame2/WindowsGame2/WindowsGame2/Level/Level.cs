using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System.Timers;

namespace WindowsGame2
{
    public class Level
    {
        public LevelLoader loader;
        public IPlayer player;
        public List<ITangible> dynamics;
        public List<ITangible> statics;
        public List<IBackground> scenery;
        public List<IParticle> particles;
        public List<Song> songs;
        public Collider collider;
        public ICamera camera;
        public Rectangle Size { get; set; }
        public int midpoint;
        public String fallOffScreenLevel;
        public Game1 game;

        private int fireballCount;
        public int camXNow, camXThen;

        public Level(Game1 game, String levelName)
        {
            this.game = game;
            this.loader = new LevelLoader(levelName);
        }

        public void InitializeObjects()
        {
            Size = loader.Reset();

            fireballCount = 0;

            this.songs = new List<Song>();
            dynamics = new List<ITangible>();
            statics = new List<ITangible>();
            scenery = new List<IBackground>();
            particles = new List<IParticle>();
            collider = new Collider(this);
            camera = new Camera1(this, HotDAMN.CAMERA_OFFSET_X, HotDAMN.CAMERA_OFFSET_Y, HotDAMN.WINDOW_WIDTH, HotDAMN.WINDOW_HEIGHT);
            HUD.level = this;

            camXNow = camera.Viewport.Right / HotDAMN.GRID;
            camXThen = -HotDAMN.OFFSCREEN_LEVEL_LOAD_BLOCKS;
            loader.SetLevelSettings(this);

            HUD.SONG_INDEX = 0;
            SoundPanel.PlaySong(songs[HUD.SONG_INDEX]);
        }

        public void Update()
        {
            loader.Update(this);

            if (game.state is SInLevel)
            {
                if (HUD.SONG_INDEX == 0 && HUD.TIME == HotDAMN.TIME_UNTIL_HURRY_UP)
                {
                    HUD.SONG_INDEX++;
                    SoundPanel.PlaySong(songs[HUD.SONG_INDEX], false);
                }
                else if (HUD.SONG_INDEX == 1 && !SoundPanel.IsPlaying())
                {
                    HUD.SONG_INDEX++;
                    SoundPanel.PlaySong(songs[HUD.SONG_INDEX]);
                }
                else if (!SoundPanel.IsPlaying() && HUD.TIME > 0)
                {
                    SoundPanel.PlaySong(songs[HUD.SONG_INDEX]);
                }
            }

            foreach (IBackground s in this.scenery)
            {
                s.Update();
            }
            for (int i = 0; i < particles.Count; i++) {
                particles[i].Update();
                if (!particles[i].IsActive) {
                    particles.RemoveAt(i);
                    i--;
                }
            }
            for (int count = 0; count < dynamics.Count; count++)
            {
                if (dynamics[count] is IPlayer)
                {
                    ((IPlayer)dynamics[count]).Decorator.Update();
                }
                else
                {
                    if (camera.IsInView(dynamics[count]) || !(dynamics[count] is IEnemy))
                    {
                        dynamics[count].Update();
                    }
                }
            }
            for (int count = 0; count < statics.Count; count++)
            {
                if (statics[count] is IPlayer)
                {
                    ((IPlayer)statics[count]).Decorator.Update();
                }
                else
                {
                    statics[count].Update();
                }
            }

            if (player.Position.X > midpoint * 16)
            {
                HUD.midpointHit[HUD.currentPlayer] = true;
            }

            if (!player.IsActive)
            {
                ResetLevel();
            }

            camera.Update();
            collider.Update();
            player.IsRunning = false;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (IBackground s in scenery)
            {
                s.Draw(sb, camera.Viewport);
            }

            IPlayer player = null;
            for (int count = 0; count < dynamics.Count; count++ )
            {
                if (dynamics[count] is IPlayer)
                {
                    player = (IPlayer)dynamics[count];
                }
                else
                {
                    dynamics[count].Draw(sb, camera.Viewport);
                }
            }
            for (int count = 0; count < statics.Count; count++)
            {
                if (statics[count] is IPlayer)
                {
                    player = (IPlayer)statics[count];
                }
                else
                {
                    statics[count].Draw(sb, camera.Viewport);
                }
            }

            foreach (IParticle p in particles)
            {
                p.Draw(sb, camera.Viewport);
            }
            player.Decorator.Draw(sb, camera.Viewport);
        }

        public void PlayerFallsOffScreen()
        {
            if (fallOffScreenLevel == null)
            {
                player.State = new SDeadMario(player, false);
            }
            else
            {
                HUD.MARIO_STATE[HUD.currentPlayer] = (IPlayerState)(player.State);
                int time = HUD.TIME;
                this.game.state = new SInLevel(this.game, fallOffScreenLevel);
                HUD.TIME = time;
            }
        }

        public void TryAddFireball(bool left, int x, int y)
        {
            if (fireballCount < HotDAMN.MAX_FIREBALL_COUNT)
            {
                dynamics.Add(new Fireball(left, x, y));
                fireballCount++;
            }
        }

        public void AddDynamicObject(ITangible tangible)
        {
            dynamics.Add(tangible);
        }

        public void AddParticle(IParticle particle)
        {
            particles.Add(particle);
        }

        public void RemoveInactives(List<ITangible> tangibles)
        {
            tangibles.RemoveAll(FindInactive);
        }

        public void ResetLevel()
        {
            if (HUD.LIVES[HUD.currentPlayer] == 0)
            {
                game.state = new SGameOver(game);
            }
            else
            {
                HUD.currentPlayer = HUD.nextPlayer % HUD.numOfPlayers;
                game.state = new SLevelIntro(game, HUD.worldNum[HUD.currentPlayer] + "-" + HUD.levelNum[HUD.currentPlayer]);
            }
        }

        bool FindInactive(ITangible obj)
        {
            if (obj is Fireball && (!obj.IsActive || !camera.IsInView(obj)))
            {
                fireballCount = fireballCount < 0 ? 0 : fireballCount - 1;
            }
            return !obj.IsActive;
        }
    }
}
