using Engine;
using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine.Managers.Behaviour;

namespace ADS.Entities.Platformer
{
    public class PhysicsEntity : Entity, Engine.IDrawable
    {

        public override void Initialize(Vector2 Pos)
        {
            mind = BehaviourManager.Instance.Create<PhysicsMind>(this);
            base.Initialize(Pos);
            this.Name = "Physics";
        }
    }
}
