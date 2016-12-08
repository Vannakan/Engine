using Engine.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public class Bullet : Mind
    {

        IEntity target;
        Vector2 distance2player;
        Vector2 playerPos;
        public Bullet()
        {
            isCollidable = false;
        }

        //public override void Initialize(Vector2 Pos, string t, DIRECTION direction)
        public override void Initialize(Vector2 Position, string t)
        {
            target = EntityManager.Instance.getPlayer();
            playerPos = new Vector2(Position.X, Position.Y);// target.Position;
            distance2player = playerPos - _pos;
            distance2player.Normalize();
            base.Initialize(Position, t);
        }
        
     
        public override void Update(GameTime gameTime)
        {

            Position += distance2player * 5f;
            base.Update(gameTime);


        }

     

    
    }
}
              
    



    

