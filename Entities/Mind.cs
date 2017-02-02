using Engine.Managers.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public abstract class Mind : IMind, ICollidable
    {

        //Minds unique ID (Always set to be the same as the entity its possessing)
        public int UniqueID { get; set; }
        //Check whether the object is active or not for updating and drawing
        public bool Active { get; set; }
        //Instance variable for the entity
        protected IEntity e;

        //Velocity for moving the mind
        protected Vector2 velocity = new Vector2(0,0);

        public Vector2 Velocity
        {
            get
                { return velocity; }

            set { velocity = value; }
        }


        public bool isColliding { get; set; }

        public Vector2 tempsteerpos { get { return _pos; } set { _pos = value; } }

        protected Vector2 _pos = new Vector2();
        public Vector2 Position { get { return e.Position; } set { e.Position = value; } }
        protected Vector2 Acceleration = new Vector2(0.01f,0.01f);
        public Rectangle Bounds { get { return new Rectangle((int)e.Position.X, (int)e.Position.Y, e.Texture.Width, e.Texture.Height); } }

        public bool isCollidable { get; set; }


        public Mind()
        {
            
        }

        /// <summary>
        /// Returns the minds possessed IEntity 
        /// </summary>
        /// <returns></returns>
        public IEntity getEntity()
        {
            return e;
        }

        /// <summary>
        /// Returns itself as an ICollidable (For collision management)
        /// </summary>
        /// <returns></returns>
        public ICollidable getCollidable()
        {
            return this as ICollidable;
        }

        public virtual void Initialize( Vector2 Position,string t)
        {
            //this.e = E;
            UniqueID = e.UniqueID;
            setTexture(t);
            e.Position = Position;
            e.isVisible = true;
            Active = true;

        }

  
        public virtual void Unload()
        {

        }
        public void setTexture(string t)
        {
            e.Texture =  ResourceLoader.Instance.GetTex(t);
        }


        public virtual void Update(GameTime gameTime)
        {
            _pos = e.Position;
            _pos += Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
           e.Position = _pos;
            if(!Active)
            {
                e.isVisible = false;
            }
        }

        public void Link(IEntity e)
        {
            this.e = e;
        }
    }
}
