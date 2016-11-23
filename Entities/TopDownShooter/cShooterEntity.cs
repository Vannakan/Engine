using Engine.Managers.Behaviour;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities.TopDownShooter
{
    public class cShooterEntity : Entity
    {

        public cShooterEntity() : base()
        {

        }

        public override void Initialize(Vector2 Pos, string Tex)
        {
            mind = BehaviourManager.Instance.Create<cShooterMind>(this);
            base.Initialize(Pos, Tex);
        }
    }
}
