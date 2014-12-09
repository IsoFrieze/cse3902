using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame2
{
    public static class SoundPanel
    {
        private static bool muted = false;

        public static void PlaySoundEffect(SoundEffect effect)
        {
            effect.Play();
        }

        public static void PlaySong(Song song, bool loop = true)
        {
            try
            {
                MediaPlayer.Stop();
                MediaPlayer.IsRepeating = loop;
                MediaPlayer.Play(song);
            }
            catch
            {

            }
        }

        public static bool IsPlaying()
        {
            return MediaPlayer.State != MediaState.Stopped;
        }

        public static void StopSong()
        {
            MediaPlayer.Stop();
        }

        public static void PauseSong()
        {
            MediaPlayer.Pause();
        }

        public static void UnpauseSong()
        {
            MediaPlayer.Resume();
        }

        public static void ToggleMute()
        {
            muted = !muted;
            MediaPlayer.Volume = muted ? 0 : 0.2f;
            SoundEffect.MasterVolume = muted ? 0 : 0.2f;
        }
    }
}
