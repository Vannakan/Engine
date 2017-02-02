using ADS.Entities;
using Engine.Managers.Behaviour;
using Engine.Managers.CamManage;
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
   

    public class pEntity : Entity, IDrawable
    {
        

        public override void Initialize(Vector2 Pos, string Tex) 
        {
            mind =BehaviourManager.Instance.Create<PlayerMind>(this);
            base.Initialize(Pos, Tex);
            CameraManager.Instance.getCam().setEntity(this, "Follow");
        }




      
    }
}

    

