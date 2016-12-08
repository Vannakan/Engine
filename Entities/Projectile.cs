using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine;

namespace ADS.Entities
{
    public class Projectile : IEntity
    {

        //Projectiles Target
        private Vector2 Target;
        //Position variable for the entity
        private Vector2 position;
        //Accessor & Mutator
        public Vector2 Position { get { return position; } set { position = value; } }
        //Accessor & Mutator

        //private direction = direction.none;

        //boundingBoxVisible
        private bool bbV = false;
        public Projectile()
            {

            }

        public void Initialize(Vector2 Pos, string Tex)
        {
        }
    }
}
