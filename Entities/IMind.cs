using Engine.Managers.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public interface IMind
    {
        //Check if the minds is active (To check whether it should be drawn and update or not)
        bool Active { get; set; }
        //Update the Entity
        void Update(GameTime gameTime);

        Vector2 Velocity { get; set; }

        Vector2 Position { get; set; }
        
        Vector2 tempsteerpos { get; set; }

        int UniqueID { get; }

        //Initialize the entity in which the mind is controlling
        void Initialize(Vector2 Position, string t);
        //
        //void Initialize<T>(Vector2 Position, string t);

        void Unload();

        //Will return the entity which the mind is controlling
        IEntity getEntity();

        ICollidable getCollidable();

        void Link(IEntity e);
    }
}
