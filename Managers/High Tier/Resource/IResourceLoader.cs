using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    public interface IResourceLoader
    {
        ContentManager Content { get; set; }
        Texture2D GetTex(string name);
        SpriteFont GetFont(string name);
        Song GetSong(string path);
        void Initialize();
        bool CheckLibrary(string name);

    }
}
