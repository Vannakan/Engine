using ADS.Managers.Behaviour;
using ADS.Managers.EntityRelated;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Entities
{
    class SpikeTrap : Mind
    {
        int count = 0;
        int count2 = 0;
        IEntity playerRef;

        public SpikeTrap()
        {
            isCollidable = true;
        }


        public override void Initialize(Vector2 Position, string t)
        {
            Vector2 pos = Position;
            string tt = t;
            playerRef = EntityManager.Instance.getPlayer();
               base.Initialize(pos, tt);
        }


        public override void Update(GameTime gameTime)
        {
            count++;
            count2++;
            if (count > 200)
            {
                Fire();
                count = 0;
            }
            if (count2 > 250)
            {
                Fire();
                count2 = 0;
            }


            base.Update(gameTime);


        }




        public void Fire()
        {
            EntityManager.Instance.createEntity<bulletEntity>(_pos, "bullet");
        }


    }
}

              
    



    

