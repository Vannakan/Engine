using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace ADS.Entities
{
    public class pjtMind : Mind, IProjectile
    {
        Direction direction = Direction.left;
        Vector2 target = Vector2.Zero;
        int speed = 7;
        
        public override void Initialize(Vector2 Position, string t)
        {
            base.Initialize(Position, t);

            switch(direction)
            {
                case Direction.left:
                    target = new Vector2(-speed, 0);
                    break;
                case Direction.right:
                    target = new Vector2(speed, 0);
                    break;
                case Direction.up:
                    target = new Vector2(0, -speed);
                    break;
                case Direction.down:
                    target = new Vector2(0, speed);
                    break;
            }
            
        }

        public void setDirection(Direction d)
        {
            direction = d;
        }

        public override void Unload()
        {
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Position += target;
        }

       
    }
}
