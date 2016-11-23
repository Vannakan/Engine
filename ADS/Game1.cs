using ADS.Entities;
using ADS.Events.KeyboardEvent;
using ADS.Events.MouseEvent;
using ADS.Managers.Behaviour;
using ADS.Managers.CamManage;
using ADS.Managers.Collision;
using ADS.Managers.EntityRelated;
using ADS.Managers.Render;
using ADS.Managers.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace ADS
{
    /// <summary>
    ///Engine V.05
    ///Jack Tomlinson - University of Worcester
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Circle c1, c2;

       public Camera cam;
        Texture2D t1;
        Rectangle rect1, rect2;

        SpriteFont sp;
        Rectangle srect;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";    
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set the mous to visible
            this.IsMouseVisible = true;
           Constants.ScreenCentre = new Vector2(GraphicsDevice.Viewport.Bounds.Width / 2,
           GraphicsDevice.Viewport.Bounds.Height / 2);
            //Initialize Managers
            ResourceLoader.Instance.Content = this.Content;
            ResourceLoader.Instance.Initialize();
            ScreenManager.Instance.Initialize();
            RenderManager.Instance.spriteBatch = spriteBatch;
            Constants.g = GraphicsDevice;

            //TESTING. DONT TOUCH
            cam = new Camera();
            cam.Pos = Constants.ScreenCentre;
            Constants.cam = cam;
            CameraManager.Instance.Initialize(cam);

            c1 = new Circle(90, new Vector2(200, 200));
            c2 = new Circle(90, new Vector2(300, 300));

            //Register Key Listener
            //Register Mouse Listener
           // MouseHandler.Instance.MouseClick += oo.OnMouseDown;
            t1 = ResourceLoader.Instance.GetTex("BackGround");
            SoundManager.Instance.Play("MenuSong");

            //Two shitty rectangles for the infinite background loop
            rect1 = new Rectangle(0, 0, t1.Width, t1.Height);
            rect2 = new Rectangle(rect1.Right, 0, t1.Width, t1.Height);
            base.Initialize();

            srect = new Rectangle(0, 0, 100, 100);
            sp = ResourceLoader.Instance.GetFont("mFont");


        }

  

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


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
       //   if(InputManager.Instance.CheckHeldDown(Keys.D))
        //  {
        //      c1.Centre = new Vector2(c1.Centre.X + 5, c1.Centre.Y);
        //  }

        //  if (InputManager.Instance.CheckHeldDown(Keys.A))
        //  {
        //      c1.Centre = new Vector2(c1.Centre.X - 5, c1.Centre.Y);
        //  }

        //  Console.WriteLine("C1" + c1.Centre + "c2" + c2.Centre);
         // Console.WriteLine(DetectionManger.Instance.circleCollision(c1,c2));


            if (rect1.X + t1.Width <= 0)
                rect1.X = rect2.X + t1.Width;
            if (rect2.X + t1.Width <= 0)
                rect2.X = rect1.X + t1.Width;

            rect1.X -= 1;
            rect2.X -= 1;
            //Get the most recent entity list for the render manager to draw
            //Check For Input
            //Update the managers
            MouseHandler.Instance.Update();
            KeyHandler.Instance.Update();
            InputManager.Instance.Update(gameTime);
            ScreenManager.Instance.Update(gameTime);
            BehaviourManager.Instance.Update(gameTime);
            DetectionManger.Instance.Update(gameTime);
            EntityManager.Instance.Update();



            RenderManager.Instance.getEntityList();

       
           
            //Update the camera
            cam.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        cam.get_transformation(GraphicsDevice));
         //  spriteBatch.Draw(t1, rect1, Color.White);
           // spriteBatch.Draw(t1, rect2, Color.White);
            RenderManager.Instance.Draw(spriteBatch);

            spriteBatch.DrawString(ResourceLoader.Instance.GetFont("mFont"), "V.01 - Alpha Build", new Vector2(cam.Pos.X + 200, cam.Pos.Y + 200), Color.Red);



         //   c1.Draw(spriteBatch, createCircleText((int)c1.Radius));
          //  c2.Draw(spriteBatch, createCircleText((int)c2.Radius));

            spriteBatch.End();
            base.Draw(gameTime);
        }

        Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }

    }
}
