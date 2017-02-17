using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Engine
{
   public class ResourceLoader : IResourceLoader
    {

       #region Properties
        //Resource loaders Content Manager 
        public ContentManager Content { get; set; }
       //Dictionary for the type of SpriteFont
        public Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
       //Dictionary for the type of Texture2D
        public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
       //Dictionray for the type of Song
        public Dictionary<string, Song> Music = new Dictionary<string, Song>();

        #endregion

       #region Singleton
        //singleton
        private static IResourceLoader instance;

       public static IResourceLoader Instance
       {
           get
           {
               if(instance == null)
               {
                   instance = new ResourceLoader();
               }
               return instance;
           }
       }
        #endregion

       #region Initialize
        /// <summary>
        /// Load all desired content
        /// Split into X method calls each one goes through the relevant directory (e.g \\Tiles or \\Sound 
        /// and loads each object into the content pipeline. Although make sure that the files have been 
        /// added to the content pipeline first pl0x
        /// </summary>
        public void Initialize()
       {
            LoadGUI();
            LoadTiles();
            LoadSound();
            LoadEntity();
            LoadMisc();   
       }
        #endregion

       #region Textures
        public void LoadTexture(string path)
       {

            Texture2D texture = Content.Load<Texture2D>(path);
            texture.Name = path;
            Textures.Add(path, texture);


        }

        public void LoadTexture(string start, string name)
        {

            Texture2D texture = Content.Load<Texture2D>(start+name);
            texture.Name = name;
            Textures.Add(name, texture);
        }

       public Texture2D GetTex(string name)
       {
          if(Textures.ContainsKey(name))
          {
              Texture2D tex = Textures[name];
                  return tex;
          }

          return null;
           

           

       }

       

       #endregion
        
       #region Fonts

       /// <summary>
       /// Load a SpriteFont from the content pipeline via a string and add it into the dictionary
       /// </summary>
       /// <param name="path"></param>
       public void LoadFont(string start,string name)
       {
           SpriteFont font = Content.Load<SpriteFont>(start+name); 
           Fonts.Add(name, font);
           
       }

       /// <summary>
       /// Check the given string through the dictionary and return that SpriteFont
       /// </summary>
       /// <param name="Name"></param>
       /// <returns></returns>
       public SpriteFont GetFont(string Name)
       {
           if(Fonts.ContainsKey(Name))
           {
               SpriteFont font = Fonts[Name];
               return font;
           }
           return null;
       }
        #endregion

       #region Music

        public bool CheckLibrary(string name)
        {
            if (Music.ContainsKey(name))
            {

                return true;
            }
            else
                return false;
        }

        //Load a song into the content pipeline 
        public void LoadSong(string start,string name)
        {
            Song song = Content.Load<Song>(start+name);
            if(!Music.ContainsKey(name))
            Music.Add(name, song);
        }

        
        public Song GetSong(string name)
       {
           if(Music.ContainsKey(name))
           {
               Song song = Music[name];
               return song;
           }
           return null;
       }
        #endregion

       #region LoadInMethods
        public void LoadTiles()
        {
            string[] filePaths = Directory.GetFiles("Content\\Tiles");

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
                LoadTexture("Tiles\\", filePaths[i]);
            }
        }

        public void LoadSound()
        {
            string[] filePaths = Directory.GetFiles("Content\\Sound");

            string safety = "";
            for (int i = 0; i < filePaths.Length; i++)
            {
                
                filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
                
                LoadSong("Sound\\", filePaths[i]);
            }
        }

        public void LoadEntity()
        {
            string[] filePaths = Directory.GetFiles("Content\\Entity");

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);             
                LoadTexture("Entity\\", filePaths[i]);
            }

        }

        public void LoadMisc()
        {
            string[] filePaths = Directory.GetFiles("Content\\Misc");

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
                LoadTexture("Misc\\", filePaths[i]);
            }
        }

        public void LoadGUI()
        {
            string[] filePaths = Directory.GetFiles("Content\\GUI");
            string[] filePaths1 = Directory.GetFiles("Content\\Fonts");

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
              
                LoadTexture("GUI\\", filePaths[i]);
            }
            for(int i = 0; i< filePaths1.Length; i++)
            {
                filePaths1[i] = Path.GetFileNameWithoutExtension(filePaths1[i]);

                LoadFont("Fonts\\", filePaths1[i]);

            }
        }
        #endregion
    }
}
