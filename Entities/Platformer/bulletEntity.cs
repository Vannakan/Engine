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


    public class bulletEntity : Entity
    {





        public override void Initialize(Vector2 Pos)
        {
            mind = BehaviourManager.Instance.Create<Bullet>(this);
            base.Initialize(Pos);
        }
    }
      
}



