using Engine.Events.KeyboardEvent;
using Engine.Managers.CamManage;
using Engine.Managers.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class GameOptions : BaseScreen
    {

        CameraManager c = CameraManager.Instance;

        SpriteFont sf = ResourceLoader.Instance.GetFont("mFont");

        string audio = "Audio Enabled";
        string volume =  "Audio Volume";

        int selected = 1;

        List<string> menuNames;
        List<MenuItem> menuItems;
        public GameOptions()
        {

        }


        public override void Initialize()
        {

        
            SoundTrack = "SoundTrack1";
            base.Initialize();
            KeyHandler.Instance.KeyDown += OnKeyDown;


            menuNames = new List<string>();
            menuItems = new List<MenuItem>();
            menuNames.Add("Mute - Enter");
            menuNames.Add("Volume  +/-");
            menuNames.Add("FullScreen - Enter");

            int yOffset = 0;
            for (int i = 0; i < menuNames.Count; i++)
            {
                yOffset += 75;
                MenuItem item = new MenuItem(menuNames[i],
                yOffset,
                ResourceLoader.Instance.GetFont("mFont"),
                i + 1, ResourceLoader.Instance.GetTex("Menu3"),1.25f);
                menuItems.Add(item);
            }
        }

        public override void Unload()
        {
            KeyHandler.Instance.KeyDown -= OnKeyDown;
            base.Unload();
        }


        /// <summary>
        /// TO DO
        /// 
        /// Remove the switch case and replace it with a list of menu items instead
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {


            foreach (MenuItem item in menuItems)
            {
                item.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }


        public void OnKeyDown(object sender, KeyEventArgs e)
        {

            if (e.keyState.IsKeyDown(Keys.Enter))
            {
                switch (selected)
                {
                    case 1:
                        if (SoundManager.Instance.isMuted == false)
                            SoundManager.Instance.Mute();
                        else
                            SoundManager.Instance.unMute();
                        break;
                    case 3:

                        if (Game1.Instance.graphics.IsFullScreen == false)
                        {
                            Game1.Instance.graphics.PreferredBackBufferWidth = 1920;
                            Game1.Instance.graphics.PreferredBackBufferHeight = 1020;
                            Game1.Instance.graphics.ToggleFullScreen();
                        }
                        else
                        {
                            Game1.Instance.graphics.PreferredBackBufferWidth = 800;
                            Game1.Instance.graphics.PreferredBackBufferHeight = 480;
                            Game1.Instance.graphics.ToggleFullScreen();
                        }
                        break;
                }
            }


            if (e.key == Microsoft.Xna.Framework.Input.Keys.OemPlus && selected == 2)
                SoundManager.Instance.volUp();

            if (e.key == Microsoft.Xna.Framework.Input.Keys.OemMinus && selected == 2)
                SoundManager.Instance.volDown();


            if (e.key == Microsoft.Xna.Framework.Input.Keys.Up && selected > 0)
                selected--;


            if (e.key == Microsoft.Xna.Framework.Input.Keys.Down && selected < 4)
                selected++;
            Console.WriteLine(selected);

        }

        public override void Update(GameTime gameTime)
        {
        
            foreach (MenuItem item in menuItems)
            {
                if (selected == item.Index)
                {
                    item.IsSelected = true;
                }
                else item.IsSelected = false;
            
        }
            base.Update(gameTime);
        }



      
    }
}
