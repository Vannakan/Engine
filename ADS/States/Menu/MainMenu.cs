using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ADS.Events.KeyboardEvent;

namespace ADS
{
    class MainMenu : BaseScreen
    {
        #region Variables
        //An index integer for the menus
        private int Selected;
        //A list of the menu item names
        List<string> menuNames = new List<string>();
       //Offset that is added to the Y position of the menu item when it is drawn
        float yOffset = -100;
     //List of the menu items
        List<MenuItem> MenuItems;

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
            KeyHandler.Instance.KeyDown += OnKeyDown;
            menuNames.Add("Play");
            menuNames.Add("Options");
            menuNames.Add("Quiz");
            menuNames.Add("Information & Myths!");
            menuNames.Add("Exit");
            for (int i = 0; i < menuNames.Count; i++)
            {
                yOffset += 75;
                MenuItem item = new MenuItem(menuNames[i],
                new Vector2(Constants.ScreenCentre.X - 50, 160 + yOffset),
                ResourceLoader.Instance.GetFont("mFont"),
                i + 1, ResourceLoader.Instance.GetTex("MenuButton"));
                MenuItems.Add(item);
            }
        }
        #endregion
        #region Draw, Update & Update Related Methods
        /// <summary>
        /// Draws all menu items as well as the Main Menu font
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            foreach(MenuItem item in MenuItems)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.DrawString(ResourceLoader.Instance.GetFont("mFont"), "An Alcohol Awareness game (Prototype)",new Vector2(Constants.ScreenCentre.X - 100, 100), Color.White);
            base.Draw(spriteBatch);
        }

        /// <summary>
        /// Process:
        /// - Make sure that the selected index doesnt go above the amount of menu items currently being displayed 
        /// - Initialize Menu Input
        /// - Highlight menu items based on if they're selected or not
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            CheckLimits();
            MenuSelection();
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
                            ScreenManager.Instance.Add("QuizLevel");
                            break;
                        case 4:
                            ScreenManager.Instance.Add("Information");
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
