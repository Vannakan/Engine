using Engine.Entities;
using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using Engine.Managers;
using Engine.Managers.ASTAR;
using Engine.Managers.Behaviour;
using Engine.Managers.CamManage;
using Engine.Managers.Collision;
using Engine.Managers.EntityRelated;
using Engine.Managers.Render;
using Engine.Managers.Sound;
using Engine.Managers.State;
using Engine.Serialization;
using Engine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using ADS.Tilemaps;
using ADS.GUI;

namespace Engine
{
    /// <summary>
    ///Engine V.05
    ///Jack Tomlinson - University of Worcester
    /// </summary>
    public class Game1 : Game
    {
        //List of Update Components
        private List<IUpdateEngineComponent> UpdateList;
        //List of Draw Components
        private List<IDrawEngineComponent> DrawList;
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public static Game1 Instance;

      


            public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
            this.Window.Title = "Medication";


        }


        //Initialize;
        protected override void Initialize()
        { 
            UpdateList = new List<IUpdateEngineComponent>();

            CameraManager.Instance.Initialize();
            SoundManager.Instance.Initialize();
            //Set the mous to visible
            this.IsMouseVisible = true;
            Constants.g = GraphicsDevice;
            Random random = new Random();
            Constants.r = random;
            //Initialize Managers
            ResourceLoader.Instance.Content = this.Content;
            ResourceLoader.Instance.Initialize();
            ScreenManager.Instance.Initialize();
            UpdateList.Add(MouseHandler.Instance);
            UpdateList.Add(KeyHandler.Instance);
            UpdateList.Add(ScreenManager.Instance);
            UpdateList.Add(BehaviourManager.Instance);
            UpdateList.Add(DetectionManger.Instance);
            UpdateList.Add(RenderManager.Instance);
            UpdateList.Add(CameraManager.Instance);
            UpdateList.Add(SoundManager.Instance);
            GuiManager.Instance.Initialize();
            base.Initialize();
        }




        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            RenderManager.Instance.spriteBatch = spriteBatch;
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Not everything has been intergrated to the new input 
            InputManager.Instance.Update(gameTime);

            GraphicsDevice.Clear(Constants.colour);

            //Update items that require it
            foreach (IUpdateEngineComponent ee in UpdateList)
            {
                ee.Update(gameTime);
            }

            GuiManager.Instance.Update();

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Draw Everything
            RenderManager.Instance.Draw();
            base.Draw(gameTime);
        }

      


    }
}
