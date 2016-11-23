using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    public class Camera
    {
        bool Follow, Locked = false;
        bool isPossessed = false;
        protected IEntity p;            //Target Entity
        protected float          _zoom; // Camera Zoom
        public Matrix             _transform; // Matrix Transform
        public Vector2          _pos; // Camera Position
        protected float         _rotation; // Camera Rotation
        protected Vector2 _oPos; //Original position;
 
        public Camera()
        {
            _zoom = 1f;
            _rotation = 0f;
            _pos = Vector2.Zero;
        }

    

        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if
                (_zoom < 0.1f) _zoom = 0.1f;
            } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        //move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; _oPos = value; }
        }

        public void setEntity(IEntity e, string Type)
        {
            p = e;
            isPossessed = true;
            switch(Type)
            {
                case "Follow":
                    Locked = true;
                    break;
                case "Locked":
                 //   Locked = true;
                    break;

            }
        }


        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(1, 1, 1)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            return _transform;
        }

        public void Update()
        {
            if(isPossessed)
            {
                if (Follow)
                {
                    if (p.Position.X > _pos.X -200)
                    {
                        _pos.X += 5;
                    }
                    if (p.Position.X < _pos.X - 200)
                    {
                        _pos.X -= 5;
                    }
                }
                if(Locked)
                _pos = p.Position;
            }
            if(InputManager.Instance.CheckHeldDown(Keys.L))
            {
                _pos.X += 3;
            }
            if (InputManager.Instance.CheckHeldDown(Keys.J))
            {
                _pos.X-=3;
            }
            if (InputManager.Instance.CheckHeldDown(Keys.I))
            {
                _pos.Y-=3;
            }
            if (InputManager.Instance.CheckHeldDown(Keys.K))
            {
                _pos.Y+=3;
            }
        }

        public void reset()
        {
            isPossessed = false;
           _pos = Constants.ScreenCentre;
            
        }
   
    }
}
