using Engine.Entities;
using Engine.Entities.TopDownShooter;
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
        Random random;
        public static Game1 Instance;

        int radius = 200;
        int cx = 1;
        int cy = 1;
        int i = 0;
        Circle circle;
        
        Vector2[] test = new Vector2[7];
        int[] IDSTOREMOVE = new int[7];

        public Vector2 testMethod()
        {
            int x = cx + radius * (int)Math.Cos(random.Next());
            int y = cy + radius * (int)Math.Sin(random.Next());

            if (x > cx)
                x = cx - (random.Next() % radius);
            else
                x = cx + (random.Next() % radius);

            if (y > cy)
                y = cy - (random.Next() % radius);
            else
                y = cy + (random.Next() % radius);

            return new Vector2(x, y);
            

        }

     
        saveDataTest dd;
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
            random = new Random();
            Constants.r = random;

            circle = new Circle(150, new Vector2(cx, cy));
           
            UpdateList = new List<IUpdateEngineComponent>();

            CameraManager.Instance.Initialize();
            SoundManager.Instance.Initialize();

            //Code for creating a file
            //using(FileSteam fs = File.Create(path)
            //{

            //}
            //Code for saving my entity list. from this list i can edit it to add more
            //Dictionary<string, int> test = new Dictionary<string, int>();
            //FileStream fs = new FileStream("", FileMode.Open, FileAccess.Read);
            // StreamReader inFile = new StreamReader(fs);

            //var binaryform = new BinaryFormatter();
            //binaryform.Serialize(fs, test);

            //using(XmlWriter)

            //Set the mous to visible
            this.IsMouseVisible = true;
            Constants.g = GraphicsDevice;
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

            KeyHandler.Instance.KeyDown += OnKeyDown;


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


            // TODO: use this.Content to load your game content here
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

            

            foreach (IUpdateEngineComponent ee in UpdateList)
            {
                ee.Update(gameTime);
            }


           
base.Update(gameTime);
        }

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            RenderManager.Instance.Draw();

          

            base.Draw(gameTime);
        }

        public void OnKeyDown(object source, KeyEventArgs kae)

        {
            if (kae.key == Keys.N)
            {

                for (int i = 0; i < 7; i++)
                {
                   for(int j = 0; j < IDSTOREMOVE.GetLength(0);j++)
                    {
                        //Testing for player ID
                        if (IDSTOREMOVE[i] == 0)
                            continue;
                        else
                        EntityManager.Instance.removeCamEntity(IDSTOREMOVE[i]);
                    }
                    test[i] = testMethod();
                    IDSTOREMOVE[i] = EntityManager.Instance.createEntityCamDrawable<tEntity>(testMethod(), "player").UniqueID;
                    
                }
                }
                

            }
        }



    }
