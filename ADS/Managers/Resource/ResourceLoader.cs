using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
   public class ResourceLoader : IResourceLoader
    {
       //Resource loaders Content Manager 
        public ContentManager Content { get; set; }
       //Dictionary for the type of SpriteFont
        public Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
       //Dictionary for the type of Texture2D
        public Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
       //Dictionray for the type of Song
        public Dictionary<string, Song> Music = new Dictionary<string, Song>();

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


       /// <summary>
       /// Load all desired content (COULD ADD SERIALIZATION HERE?)
       /// </summary>
       public void Initialize()
       {
           LoadTexture("enemy");
           LoadFont("mFont");
           LoadTexture("MenuButton");
          LoadTexture("Tile1");
           LoadTexture("Tile2");
           LoadTexture("Tile3");
           LoadTexture("Tile4");
           LoadTexture("Tile5");
           LoadTexture("Tile6");
           LoadTexture("Tile7");
           LoadTexture("Tile8");
           LoadTexture("Tile20");
           LoadTexture("player");
           LoadTexture("Spiketrap");
           LoadTexture("bullet");
           LoadSong("MenuSong");
           LoadTexture("BackGround");
           LoadTexture("c1");
           LoadTexture("c2");
           LoadTexture("c3");
           LoadTexture("c4");
           LoadTexture("c5");




           
       }



       #region Textures
       public void LoadTexture(string path)
       {
           Texture2D texture = Content.Load<Texture2D>(path);
           texture.Name = path;
           Textures.Add(path, texture);
          
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
       public void LoadFont(string path)
       {
           SpriteFont font = Content.Load<SpriteFont>(path);
           Fonts.Add(path, font);
           
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
       public void LoadSong(string path)
       {
           Song song = Content.Load<Song>(path);
           Music.Add(path, song);
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

    }
}
