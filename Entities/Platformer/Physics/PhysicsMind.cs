using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine;
using Engine.Managers.Render;
using Engine.Events.KeyboardEvent;
using Microsoft.Xna.Framework.Input;

namespace ADS.Entities.Platformer
{

   public struct AABB
    {
        public Point min;
        public Point max;
        

        public AABB(Point min, Point max)
        {
            this.min = min;
            this.max = max;
        }
    }


    public struct OOB
    {
        float a;
        float b;

        float width;
        float height;

        Vector2[] vertices;
    }
    public class PhysicsMind : Mind
    {
        //For Physics
        public float Mass = 50f;
        public Vector2 acceleration = new Vector2(0, 0);
        public Vector2 Energy;
        public Vector2 Force = new Vector2(0f, 0f);
        public float Damping = 0.9f;
        private static List<PhysicsMind> list = new List<PhysicsMind>();
        public float restitution = 0.1f;

        bool wasd = false;


        //FOR SAT
        //Top left and right, as well as bottom left and right used in the projection of the axis.
        //public float topLeft {  get { return Bounds.X; } }
        //public float topRight {  get { return Bounds.X + Bounds.Width; } }
        //public float bottomLeft { get { return Bounds.X - Bounds.Height; } }
        //public float bottomRight {  get { return Bounds.X - Bounds.Height } }

        //public Point topLeft { get { return Bounds.X; } }
        //public Point topRight { get { return Bounds.X + Bounds.Width; } }
        //public Point bottomLeft { get { return Bounds.X - Bounds.Height; } }
        //public Point bottomRight { get { return Bounds.X - Bounds.Height } }


        public Circle radius;
        public AABB aabb;


        public PhysicsMind()
        {
            KeyHandler.Instance.KeyDown += OnKeyDown;
            KeyHandler.Instance.KeyHeld += OnKeyHeld;
      
          //  Rect = new Rectangle((int)Position.X, (int)Position.Y, e.Texture.Width, e.Texture.Height);
            if (list.Count < 1)
                wasd = true;
            list.Add(this);



        }

        public override void Initialize(Vector2 Position)
        {
            texPath = "AntiBody";
            base.Initialize(Position);
            radius = new Circle(64, Position);
            aabb.min = new Point((int)_pos.X, (int)_pos.Y);
            aabb.max = new Point((int)_pos.X + e.Texture.Width, (int)_pos.Y + e.Texture.Height);
            RenderManager.Instance.addDrawable(radius);

        }

        public override void Update(GameTime gameTime)
        {
            radius.Centre = _pos;
            aabb.min = new Point((int)_pos.X, (int)_pos.Y);
            aabb.max = new Point((int)_pos.X + e.Texture.Width, (int)_pos.Y + e.Texture.Height);
            //The rate of change of velocity.
            acceleration = Force / this.Mass;

            velocity *= Damping;
            velocity += acceleration;
            _pos += velocity;

           




            acceleration = Vector2.Zero;

           



            // if (_pos.X > Constants.g.Viewport.Width / 2)
            // Force = Vector2.Zero;
            Force = Vector2.Zero;


            tempGUI();
            base.Update(gameTime);
        }

        public void OnKeyDown (object sender, KeyEventArgs m)
        {
        
         

        }

        public void OnKeyHeld(object sender, KeyEventArgs m)
        {

            if (wasd)
            {
                if (m.key == Keys.D)
                {
                    Force = new Vector2(20, Force.Y);
                }

                if (m.key == Keys.A)
                {
                    Force = new Vector2(-20, Force.Y);

                }

                if (m.key == Keys.W)
                {
                    Force = new Vector2(Force.X, -20);
                }

                if (m.key == Keys.S)
                {
                    Force = new Vector2(Force.X, 20);

                }
            }

            else if (!wasd)
            {
                if (m.key == Keys.Right)
                {
                    Force = new Vector2(20, Force.Y);
                }

                if (m.key == Keys.Left)
                {
                    Force = new Vector2(-20, Force.Y);

                }

                if (m.key == Keys.Up)
                {
                    Force = new Vector2(Force.X, -20);
                }

                if (m.key == Keys.Down)
                {
                    Force = new Vector2(Force.X, 20);

                }
            }
        }

        public override void Unload()
        {
            base.Unload();
        }

        public void tempGUI()
        {
            if (wasd)
            {
                RenderManager.Instance.addString(new ADS.Utilities.GameText("Entity A " + acceleration.ToString(), "mFont", new Vector2(0, 25), Color.Black, 1f));

                RenderManager.Instance.addString(new ADS.Utilities.GameText("ACCELERATION " + acceleration.ToString(), "mFont", new Vector2(0, 50), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("FORCE " + Force.ToString(), "mFont", new Vector2(0, 75), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("VELOCITY " + Math.Round((double)velocity.Length()), "mFont", new Vector2(0, 100), Color.Black, 1f));

                RenderManager.Instance.addString(new ADS.Utilities.GameText("POSITION " + new Vector2((float)Math.Round(Position.X), (float)Math.Round(Position.Y)), "mFont", new Vector2(0, 125), Color.Black, 1f));


                RenderManager.Instance.addString(new ADS.Utilities.GameText("A MIN " + aabb.min, "mFont", new Vector2(0, 150), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("A MAX " + aabb.max, "mFont", new Vector2(0, 175), Color.Black, 1f));
            }

            else
          if (!wasd)
            {
                RenderManager.Instance.addString(new ADS.Utilities.GameText("Entity B " + acceleration.ToString(), "mFont", new Vector2(575, 25), Color.Black, 1f));

                RenderManager.Instance.addString(new ADS.Utilities.GameText("ACCELERATION " + acceleration.ToString(), "mFont", new Vector2(575, 50), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("FORCE " + Force.ToString(), "mFont", new Vector2(575, 75), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("VELOCITY " + Math.Round((double)velocity.Length()), "mFont", new Vector2(575, 100), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("POSITION " + new Vector2((float)Math.Round(Position.X), (float)Math.Round(Position.Y)), "mFont", new Vector2(575, 125), Color.Black, 1f));


                RenderManager.Instance.addString(new ADS.Utilities.GameText("B MIN " + aabb.min, "mFont", new Vector2(575, 150), Color.Black, 1f));
                RenderManager.Instance.addString(new ADS.Utilities.GameText("B MAX " + aabb.max, "mFont", new Vector2(575, 175), Color.Black, 1f));
            }
        }
    }
}
