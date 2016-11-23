using ADS.Managers.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Entities
{
    public abstract class Mind : IMind, ICollidable
    {
        public IMind gMind { get { return this; } }

        protected float test = 1f;
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

        protected Vector2 _pos = new Vector2();
        public Vector2 Position { get { return e.Position; } set { e.Position = value; } }
        protected float Acceleration = 0.1f;
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
            return this;
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
           _pos += Velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds * test;
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
