using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Engine.Events.KeyboardEvent;
using Engine.Managers.CamManage;
using Engine.Managers.State;
using Engine.Managers.Render;

namespace Engine
{
    class MainMenu : BaseScreen
    {
        int timer = 0;

        
        #region Variables
        //An index integer for the menus
        private int Selected;
        //A list of the menu item names
        List<string> menuNames = new List<string>();
       //Offset that is added to the Y position of the menu item when it is drawn
        float yOffset = -100;
     //List of the menu items
        List<MenuItem> MenuItems;
        //Fader
        Fader f;

        Texture2D BackGround = ResourceLoader.Instance.GetTex("BackGroundSheet");
        Vector2 BackGroundPosition = CameraManager.Instance.getWorldPosition(new Vector2(0, 0));

        #endregion
        #region Constructor & Initialization
        /// <summary>
        /// Process:
        /// Set the Selected Index to 1 so that there is always something selected
        /// Create a list of menu items
        /// </summary>
        public MainMenu()
        {
            Selected = 1;
            MenuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Initializes items into the string menu list and based on how many entries
        /// relevant items are then created and added to the Item list (names are taken from the string list)
        /// </summary>
        public override void Initialize()
        {
            f = new Fader(new Vector2(1250,800),new Vector2( CameraManager.Instance.getWorldPosition(new Vector2(0,0)).X,CameraManager.Instance.getWorldPosition(new Vector2(0,0)).Y), 0.005f);

            SoundTrack = "SoundTrack4";
            KeyHandler.Instance.KeyDown += OnKeyDown;
            menuNames.Add("Play");
            menuNames.Add("Tile Editor");
            menuNames.Add("Load Map");
            menuNames.Add("Options");
            menuNames.Add("Exit");
            for (int i = 0; i < menuNames.Count; i++)
            {
                yOffset += 75;
                MenuItem item = new MenuItem(menuNames[i],
                yOffset,
                ResourceLoader.Instance.GetFont("mFont"),
                i + 1, ResourceLoader.Instance.GetTex("Menu3"));
                MenuItems.Add(item);
            }
            base.Initialize();

        }
        #endregion
        #region Draw, Update & Update Related Methods
        /// <summary>
        /// Draws all menu items as well as the Main Menu font
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ResourceLoader.Instance.GetTex("AceIcon"), CameraManager.Instance.getWorldPosition(new Vector2(Game1.Instance.graphics.PreferredBackBufferWidth / 2, Game1.Instance.graphics.PreferredBackBufferHeight / 5)), Color.White);
            spriteBatch.Draw(BackGround, BackGroundPosition, Color.Blue);
            spriteBatch.Draw(BackGround, new Vector2(BackGroundPosition.X + BackGround.Bounds.Width, BackGroundPosition.Y), Color.Red);
            foreach(MenuItem item in MenuItems)
            {
                item.Draw(spriteBatch);
            }
         
            f.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Process:
        /// - Make sure that the selected index doesnt go above the amount of menu items currently being displayed 
        /// - Initialize Menu Input
        /// - Highlight menu items based on if they're selected or not
        /// </summary>
        /// <param name="gameTime"></param>
        /// 
        public override void Update(GameTime gameTime)
        {
            f.Update();
            CheckLimits();
            MenuSelection();
            timer++;
          //  Console.WriteLine(timer);
            if (timer < 100)
                BackGroundPosition.X--;
            if (timer > 200)
                BackGroundPosition.X++;

            if (timer > 300)
                timer = 0;
            
           
            base.Update(gameTime);
        }

        /// <summary>
        /// A safety method to avoid removing the menu screen.
        /// </summary>

        public void CheckLimits()
        {
            if(Selected > MenuItems.Count)
            {
                Selected = MenuItems.Count;
            }
            else if (Selected < 1)
            {
                Selected = 1;
            }
        }

        /// <summary>
        /// Listens to the KeyHandler and produces various functionalities based on the pressed key that has been returned
        /// will only apply the function if the screen is active (It's at the top of the stack)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Active)
            {
                if (e.keyState.IsKeyDown(Keys.Up))
                {
                    Selected--;
                }
                if (e.keyState.IsKeyDown(Keys.Down))
                {
                    Selected++;
                }

                if (e.keyState.IsKeyDown(Keys.Enter))
                {
                    switch (Selected)
                    {

                        case 1:
                            ScreenManager.Instance.Add("Level1");
                            break;
                        case 2:
                            ScreenManager.Instance.Add("Options");
                            break;
                        case 3:
                            ScreenManager.Instance.Add("meTest");
                            break;
                        case 4:
                            ScreenManager.Instance.Add("GameOptions");
                            break;
                        
                        case 5:
                            Program.Game.Exit();


                            break;


                    }
                }
            }

        }


    
        /// <summary>
        /// Checks the menu items and checks if the current menu index matches them, then we can check if both indexes
        /// match then the item is currently selected and if enter is pressed, make an action.
        /// 
        /// </summary>
        public void MenuSelection()
        {

            foreach (MenuItem item in MenuItems)
            {
                if (Selected == item.Index)
                {
                    item.IsSelected = true;
                }
                else item.IsSelected = false;
            }
        }
    }
        #endregion
}
