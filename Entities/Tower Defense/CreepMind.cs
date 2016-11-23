using Engine.Events.CollisionEvent;
using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using Engine.Managers.Collision;
using Engine.Managers.EntityRelated;
using Engine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    public enum Direction { left,right,up,down}
    public class CreepMind : Mind
    {
        public Direction direction;
        GameTime GameTime;
        int maxSpeed = 1;
        bool input = true;
        bool isColliding = false;
        public CreepMind()
        {
            isCollidable = true;
            DetectionManger.Instance.OnCollision += OnCollision;
            DetectionManger.Instance.OnDirectionSwitch += OnDirectionChange;

            direction = Direction.right;
            Acceleration.X = 0.01f;

        }
        public void directionChoose()
        {
            switch (direction)
            {
                case Direction.right:
                    velocity.Y = 0;
            velocity.X += Acceleration.X * (float)GameTime.ElapsedGameTime.TotalMilliseconds; 
                    break;
                case Direction.left:
                    velocity.Y = 0;

                    velocity.X -= Acceleration.X * (float)GameTime.ElapsedGameTime.TotalMilliseconds;
                    break;
                case Direction.down:
                    velocity.X = 0;

                    velocity.Y += Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;
                    break;
                case Direction.up:
                    velocity.X = 0;

                    velocity.Y -= Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;
                    break;

            }
        }

        public void directionSwitch()
        {
            if(direction == Direction.right)
            {
                direction = Direction.left;
            }
            else
                direction = Direction.right;

        }

        int counter = 0;
        public override void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            directionChoose();
            if(velocity.X > 0.1)
            {
                velocity.X = 0.1f;
            }

            if (velocity.X < -0.1)
            {
                velocity.X = -0.1f;
            }
            if (velocity.Y > 0.1)
            {
                velocity.Y = 0.1f;
            }

            if (velocity.Y < -0.1)
            {
                velocity.Y = -0.1f;
            }

         
            base.Update(gameTime);
        }


        public override void Unload()
        {
     
        }

        public void OnCollision(object sender, CollisionEventArgs cae)
        {
            //Position

            if (cae.A == this)
            {
                isColliding = true;
                Position += GetMinimumTranslation(cae.B);
            }


        }
        public void OnDirectionChange(object sender, CollisionEventArgs cae)
        {
            if (this.Bounds.Center == cae.B.Bounds.Center)
            {
                this.direction = cae.D;
                Console.WriteLine(cae.D);
            }
        }
 

        public Vector2 GetMinimumTranslation(ICollidable B1)
        {
            //Vector for the minimum translation distance
            Vector2 mtd = new Vector2();
            Rectangle A = this.Bounds;
            Rectangle B = B1.Bounds;
            //Calculate corners of both Bounding Boxes
            float xAMin = A.X;
            float xAMax = A.X + A.Width;
            float yAMin = A.Y;
            float yAMax = A.Y + A.Height;

            float xBMin = B.X;
            float xBMax = B.X + B.Width;
            float yBMin = B.Y;
            float yBMax = B.Y + B.Height;


            float left = (xBMin - xAMax);
            float right = (xBMax - xAMin);
            float top = (yBMin - yAMax);
            float bottom = (yBMax - yAMin);

          //  if (left > 0 || right < 0) Console.WriteLine("no intersection");
          //  if (top > 0 || bottom < 0) Console.WriteLine("no intersection");


            //Select direction that we need to move the ICollidable back by
            if (Math.Abs(left) < right)
            {
                mtd.X = left;

            }
            else
            {

                mtd.X = right;

            }

            if (Math.Abs(top) < bottom)
            {
                mtd.Y = top;

            }
            else
            {
                mtd.Y = bottom;
                velocity.X = 0;
            }

            // 0 is the axis with the largest translation value/depth
            if (Math.Abs(mtd.X) < Math.Abs(mtd.Y))
            {
                mtd.Y = 0;
                //directionSwitch();

            }
            else
            {
                mtd.X = 0;

            }


            return mtd;
        }


        public void applyVelocityRules()
        {
            if (velocity.X > maxSpeed)
            {
                velocity.X = maxSpeed;
            }

            if (velocity.X < -maxSpeed)
            {
                velocity.X = -maxSpeed;
            }

            if (velocity.Y > maxSpeed)
            {
                velocity.Y = maxSpeed;
            }

            if (velocity.Y < -maxSpeed)
            {
                velocity.Y = -maxSpeed;
            }
        }
    }
}




