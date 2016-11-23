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
    public class PlayerMind : Mind
    {
        GameTime GameTime;
        int maxSpeed = 1;
        bool input = true;
        bool isColliding = false;
       public PlayerMind()
        {
            isCollidable = true;
            MouseHandler.Instance.MouseClick += OnMouseDown;
            KeyHandler.Instance.KeyDown += OnKeyDown;
            KeyHandler.Instance.KeyHeld += OnKeyHeld;
            DetectionManger.Instance.OnCollision += OnCollision;
        }



        public override void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            applyVelocityRules();
            Friction();
            base.Update(gameTime);
        }


        public override void Unload()
        {
            KeyHandler.Instance.KeyDown -= OnKeyDown;
            KeyHandler.Instance.KeyHeld -= OnKeyHeld;
            MouseHandler.Instance.MouseClick -= OnMouseDown;
        }

        public void Friction()
        {
            //I have no idea how this works, but it simulates friction
            Velocity -= Velocity * new Vector2(.1f, .1f);
        }


      
        public void OnKeyDown(object sender, KeyEventArgs m)
        {
         
        
            
        }

        public void OnKeyHeld(object sender, KeyEventArgs m)
        {
            if (input)
            {
                if (m.key == Keys.D)
                {
                    e.Position = new Vector2(e.Position.X + 2, e.Position.Y);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                  //  velocity.X += Acceleration.X *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                }
                if (m.key == Keys.A)
                {
                    e.Position = new Vector2(e.Position.X - 2, e.Position.Y);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                 //   velocity.X -= Acceleration.X * (float)GameTime.ElapsedGameTime.TotalMilliseconds;

                }
                if (m.key == Keys.S)
                {
                    e.Position = new Vector2(e.Position.X , e.Position.Y+2);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;

                  //  velocity.Y += Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;

                }

                if (m.key == Keys.W)
                {
                    e.Position = new Vector2(e.Position.X , e.Position.Y - 2);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;

                  //  velocity.Y -= Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;
                }

                
            }
        
        }

        public void OnMouseDown(object sender, MouseEventArgs m)
        {
        }

        public void OnCollision(object sender, CollisionEventArgs cae )
        {
           //Position
            if (cae.A == this)
            {
                isColliding = true;
                Position += GetMinimumTranslation(cae.B);
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

        //    if (left > 0 || right < 0) Console.WriteLine("no intersection");
            //if (top > 0 || bottom < 0) Console.WriteLine("no intersection");


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
            }

            // 0 is the axis with the largest translation value/depth
            if (Math.Abs(mtd.X) < Math.Abs(mtd.Y))
            {
                mtd.Y = 0;
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
              
    


