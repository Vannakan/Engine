using Engine.Managers.Behaviour;
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


    public class Entity : IEntity, IDrawable
    {
        //Reference to the mind which possess this Entity
        protected IMind mind;


        //Automatic property for the entities unique ID
        public int UniqueID { get; protected set; }

        //bool to check whether entity should be drawn or not
        public bool isVisible { get; set; }

        public string Name { get { return name; }  set { name = value; } }

        private string name = "";
        //Position variable for the entity
        //Accessor & Mutator
        public Vector2 Position { get { return mind.Position; } set { mind.Position = value; } }
        //Accessor & Mutator

        //boundingBoxVisible
        private bool bbV = true;


        public Texture2D Texture { get; set; }

        //Accessor & Mutator
        public Rectangle Bounds
        {
            get { return new Rectangle((int)mind.Position.X, (int)mind.Position.Y, Texture.Width, Texture.Height); }
        }

      
        //Accessor & Mutator
        public bool isCollidable { get; set; }


     

        public Entity()
        {
            UniqueID = Constants.ID;
            Constants.ID++;
            Name = this.GetType().ToString();
          
        }


        public virtual void Initialize(Vector2 Pos)
        {
            if(mind != null)
            mind.Initialize(Pos);

            
        }

    
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, mind.Position, Color.White);

            //If the option to draw the bounding box is open, call the draw primitives utility to draw the rectangle.
            if (bbV)
            {    
                ADS.Utility.DrawPrimitives.DrawRect(spriteBatch, Bounds, Color.Blue);
            }
        }
    }
}



