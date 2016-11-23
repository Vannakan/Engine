using Engine.Events.KeyboardEvent;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Managers;
using Microsoft.Xna.Framework;


namespace Engine.Managers.Sound
{
    public class SoundManager : IUpdateEngineComponent
    {

        public bool isMuted = false;

        float defaultVolume = 0.01f;
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
            MediaPlayer.Volume = defaultVolume;
            ScreenManager.Instance.ScreenChange += onScreenChanged;

        }
        //Play a song that is located within the resource loaders song library
        public void Play(string name)
        {
           
            if(ResourceLoader.Instance.CheckLibrary(name) == false)
                Console.WriteLine("SONG DOESNT EXIST");
            else
            MediaPlayer.Play(ResourceLoader.Instance.GetSong(name));
        }

        public void Mute()
        {
            if (!isMuted)
            {
                isMuted = true;
                defaultVolume = 0;

            }
        }

        public void unMute()
        {
            if (isMuted)
            {
                isMuted = false;
                defaultVolume = 0.05f;
            }
        }

        public void Volume(float Volume)
        {
            defaultVolume = Volume;
        }
        //Stop the media player
        public void Stop()
        {
            MediaPlayer.Stop();
        }

        /// <summary>
        /// Plays screens songs.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            if(MediaPlayer.Volume != defaultVolume)
            MediaPlayer.Volume = defaultVolume;
        }
        /*
         * IDEA FOR SOUND MANAGER
         * 
         * Put an event in the screenmanager
         * 
         * OnScreenChanged
         * 
         * fire it when a screen has transitioned.
         * Then put a listener within the sound manager
         * that will find out what screen it has changed it to
         * and play the song relative to the value in the dictionary
         * 
         * 
         * 
         * 
         * */

        public void volUp()
        {
            if (defaultVolume <= 1)
                defaultVolume += 0.02f;
        }

        public void volDown()
        {
              if (defaultVolume >= 0.1f)
                defaultVolume -= 0.02f;
        }
        

       

        public void onScreenChanged(BaseScreen screen)
         {
          if(screen.SoundTrack != null)
                 Play(screen.SoundTrack);
                 
         }
        
    }
} 
