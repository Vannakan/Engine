using Engine;
using Engine.Entities;
using Engine.Managers.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class tEntity : IEntity, Engine.IDrawable
{
    //Reference to the mind which possess this Entity
    private IMind mind;

    
    public string Name { get; set; }
   

    //Automatic property for the entities unique ID
    public int UniqueID { get; protected set; }

    //bool to check whether entity should be drawn or not
    public bool isVisible { get; set; }

    //Position variable for the entity
    private Vector2 position;
    //Accessor & Mutator
    public Vector2 Position { get { return position; } set { position = value; } }
    //Accessor & Mutator

    //boundingBoxVisible
    private bool bbV = false;

    Random r;
    Color c;

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

    public tEntity()
    {
        UniqueID = Constants.ID;
        Constants.ID++;
        t = new Texture2D(Constants.g, 1, 1);
        t.SetData(new[] { Color.White });
    }


    public void Initialize(Vector2 Pos)
    {
        r = Constants.r;
        mind = BehaviourManager.Instance.Create<tMind>(this);
        mind.Initialize(Pos);
        c = new Color(
 (byte)r.Next(0, 255),
 (byte)r.Next(0, 255),
 (byte)r.Next(0, 255));
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        spriteBatch.Draw(Texture, Position, c);
        if (bbV)
        {
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, 2, Bounds.Height), Color.Black); // Left
            spriteBatch.Draw(t, new Rectangle(Bounds.Right, Bounds.Top, 2, Bounds.Height), Color.Black); // Right
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, 2), Color.Black); // Top
            spriteBatch.Draw(t, new Rectangle(Bounds.Left, Bounds.Bottom, Bounds.Width, 2), Color.Black); // Bottom
        }
    }
}


    
