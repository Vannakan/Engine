using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS
{
    public interface IResourceLoader
    {
        ContentManager Content { get; set; }
        void LoadTexture(string path);
        void LoadFont(string path);
        Texture2D GetTex(string name);
        SpriteFont GetFont(string name);
        void LoadSong(string path);
        Song GetSong(string path);
        void Initialize();

    }
}
