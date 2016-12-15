using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine;
using Engine.Entities;
using Engine.Managers.Behaviour;

namespace ADS.Entities
{
    public class Projectile : Entity, IProjectile
    {
        Direction d;
        public Projectile()
            {

            }

        public override void Initialize(Vector2 Pos, string Tex)
        {
            mind = BehaviourManager.Instance.CreateProjectile<pjtMind>(this,d);
            base.Initialize(Pos, Tex);

        }

        public void setDirection(Direction d)
        {
            this.d = d;
        }
    }
}
