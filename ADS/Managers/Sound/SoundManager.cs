using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.Sound
{
    public class SoundManager
    {
        private Dictionary<string, string> songList = new Dictionary<string, string>();
        //Singleton
        private static SoundManager instance;

        public static SoundManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundManager();
                return instance;
            }
        }
        public void Initialize()
        {
            songList.Add("MenuSong", "MainMenu");
        }
        //Play a song that is located within the resource loaders song library
        public void Play(string name)
        {
            MediaPlayer.Play(ResourceLoader.Instance.GetSong(name));
            MediaPlayer.Volume = 0.05f;
        }

        //Stop the media player
        public void Stop()
        {
            MediaPlayer.Stop();
        }

        /// <summary>
        /// Plays screens songs.
        /// </summary>
        public void Update()
        {

        }

        
        
    }
}
