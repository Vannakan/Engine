using Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Entities
{
    interface IPhysicsEntity
    {
        Vector2 Acceleration { get; set; }
        Vector2 Force { get; set; }
        Vector2 Energy { get; set; }
        float Damping { get; set; }
        float Mass { get; set; }
        float Restitution { get; set; }
        Rectangle AABB { get; set; }
        Circle OOBB { get; set; }
    }
}
