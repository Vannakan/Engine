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

        public string Name { get; internal set; }

        //Position variable for the entity
        private Vector2 position;
        //Accessor & Mutator
        public Vector2 Position { get { return position; } set { position = value; } }
        //Accessor & Mutator

        //boundingBoxVisible
        private bool bbV = true;


        public Texture2D Texture { get; set; }

        //Accessor & Mutator
        public Rectangle Bounds
        {
            get { return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height); }
        }

      
        //Accessor & Mutator
        public bool isCollidable { get; set; }


        //To display Bounding Box
        Texture2D t;

        public Entity()
        {
            UniqueID = Constants.ID;
            Constants.ID++;
            t = new Texture2D(Constants.g, 1, 1);
            t.SetData(new[] { Color.White });
        }


        public virtual void Initialize(Vector2 Pos, string Tex)
        {
            if(mind != null)
            mind.Initialize(Pos, Tex);
        }

    

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, Position, Color.White);
            if (bbV)
            {
                spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, 1, Bounds.Height), Color.Yellow); // Left
                spriteBatch.Draw(t, new Rectangle(Bounds.Right, Bounds.Top, 1, Bounds.Height), Color.Yellow); // Right
                spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, 1), Color.Yellow); // Top
                spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Bottom, Bounds.Width, 1), Color.Yellow); // Bottom
            }
        }
    }
}



