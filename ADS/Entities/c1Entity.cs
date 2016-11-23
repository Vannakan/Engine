using ADS.Managers.Behaviour;
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


    public class c1Entity : IEntity
    {
        //Reference to the mind which possess this Entity
        private IMind mind;



        //Automatic property for the entities unique ID
        public int UniqueID { get; protected set; }

        //bool to check whether entity should be drawn or not
        public bool isVisible { get; set; }

        //Position variable for the entity
        private Vector2 position;
        //Accessor & Mutator
        public Vector2 Position { get { return position; } set { position = value; } }
        //Accessor & Mutator



        public Texture2D Texture { get; set; }

        //Accessor & Mutator
        public Rectangle Bounds
        {
            get { return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height); }
        }

        private bool controllable;

        //Accessor & Mutator
        public bool controlled
        {
            get
            {
                return controllable;
            }
            set { controllable = value; }
        }

        //Accessor & Mutator
        public bool isCollidable { get; set; }


        //To display Bounding Box
        Texture2D t;

        public c1Entity()
        {
            UniqueID = Constants.ID;
            Constants.ID++;
            t = new Texture2D(Constants.g, 1, 1);
            t.SetData(new[] { Color.White });
        }


        public void Initialize(Vector2 Pos, string Tex)
        {
            mind = BehaviourManager.Instance.Create<c1Mind>(this);
            mind.Initialize(Pos, Tex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, 2, Bounds.Height), Color.Black); // Left
            spriteBatch.Draw(t, new Rectangle(Bounds.Right, Bounds.Top, 2, Bounds.Height), Color.Black); // Right
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, 2), Color.Black); // Top
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Bottom, Bounds.Width, 2), Color.Black); // Bottom
        }
    }
}



