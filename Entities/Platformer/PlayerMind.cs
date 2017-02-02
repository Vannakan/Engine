using ADS.Entities;
using ADS.GUI;
using ADS.Medication.Modifiers;
using Engine.Events.CollisionEvent;
using Engine.Events.KeyboardEvent;
using Engine.Events.MouseEvent;
using Engine.Managers.Collision;
using Engine.Managers.EntityRelated;
using Engine.Managers.Render; //take this out when testing is done
using Engine.Tilemaps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Entities
{
    //This is the blueprint for medications player
    public class PlayerMind : Mind
    {
        //Player Stats
        public Stats stats;
        //Timer for bullets
        int bulletTimer = 0;
        //Dunno why this is here atm
        GameTime GameTime;
        //Check for input
        bool input = true;
        //Check for collision (useless)
        bool isColliding = false;

        
       
       public PlayerMind()
        {
            
            //Create player stats
            stats = new Stats(10, 4, 35, 200, 10) ;
            isCollidable = true;
            //Sign up to handlers
            MouseHandler.Instance.MouseClick += OnMouseDown;
            KeyHandler.Instance.KeyDown += OnKeyDown;
            KeyHandler.Instance.KeyHeld += OnKeyHeld;
            DetectionManger.Instance.OnCollision += OnCollision;
            GuiManager.Instance.setPlayer(this);
            
        }



        public override void Update(GameTime gameTime)
        {
            
            if (bulletTimer > 0)
                bulletTimer = bulletTimer-1;
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
        if(m.key == Keys.P)
            {
                stats.HP -= 10;
                if (stats.HP < 0)
                    stats.HP = 200;
                Console.WriteLine("ye");
            }

        if(m.key == Keys.O)
            {
                stats.EXP += 5;
            }

          




            //pseudo
            // EntityManager.Instance.createProjectileCamDrawable<bulletEntity>(Position, "bullet", this.DIRECTION);


        }

        public void OnKeyHeld(object sender, KeyEventArgs m)
        {
            if (input)
            {

                Keys[] keys = m.keyState.GetPressedKeys();

                if (m.key == Keys.D)
                {
                    e.Position = new Vector2(e.Position.X + stats.mSPD, e.Position.Y);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                  //  velocity.X += Acceleration.X *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                }
                if (m.key == Keys.A)
                {
                    e.Position = new Vector2(e.Position.X - stats.mSPD, e.Position.Y);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                 //   velocity.X -= Acceleration.X * (float)GameTime.ElapsedGameTime.TotalMilliseconds;

                }
                if (m.key == Keys.S)
                {
                    e.Position = new Vector2(e.Position.X , e.Position.Y+ stats.mSPD);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;
                  //  velocity.Y += Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;

                }

                if (m.key == Keys.W)
                {
                    e.Position = new Vector2(e.Position.X , e.Position.Y - stats.mSPD);// *(float)GameTime.ElapsedGameTime.TotalMilliseconds;

                  //  velocity.Y -= Acceleration.Y * (float)GameTime.ElapsedGameTime.TotalMilliseconds;
                }

                if ((m.keyState.IsKeyDown(Keys.Up) && m.keyState.IsKeyDown(Keys.Space)))
                {

                    

                  

                
                }

             

                    if ((m.keyState.IsKeyDown(Keys.Down) && m.keyState.IsKeyDown(Keys.Space)))
                {
                    
                }


                if ((m.keyState.IsKeyDown(Keys.Left) && m.keyState.IsKeyDown(Keys.Space)))
                {
                    
                    

                }


                if ((m.keyState.IsKeyDown(Keys.Right) && m.keyState.IsKeyDown(Keys.Space)))
                {
                    
                }



                ////Console.WriteLine(bulletTimer);
                //if (bulletTimer == 0)
                //{
                //    switch (m.key)
                //    {
                //        case Keys.Left:
                //            bulletTimer = stats.aSPD;
                //            EntityManager.Instance.createProjectile<Projectile>(new Vector2(this.Bounds.Center.X, this.Bounds.Center.Y), "bullet1", ADS.Entities.Direction.left);
                //            break;
                //        case Keys.Right:
                //            bulletTimer = stats.aSPD;
                //            EntityManager.Instance.createProjectile<Projectile>(new Vector2(this.Bounds.Center.X, this.Bounds.Center.Y), "bullet1", ADS.Entities.Direction.right);
                //            break;
                //        case Keys.Up:
                //            bulletTimer = stats.aSPD;
                //            EntityManager.Instance.createProjectile<Projectile>(new Vector2(this.Bounds.Center.X, this.Bounds.Center.Y), "bullet1", ADS.Entities.Direction.up);
                //            break;
                //        case Keys.Down:
                //            bulletTimer = stats.aSPD;
                //            EntityManager.Instance.createProjectile<Projectile>(new Vector2(this.Bounds.Center.X, this.Bounds.Center.Y), "bullet1", ADS.Entities.Direction.down);
                //            break;





                //    }

                //}







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
            if (velocity.X > stats.mSPD)
            {
                velocity.X = stats.mSPD;
            }

            if (velocity.X < -stats.mSPD)
            {
                velocity.X = -stats.mSPD;
            }

            if (velocity.Y > stats.mSPD)
            {
                velocity.Y = stats.mSPD;
            }

            if (velocity.Y < -stats.mSPD)
            {
                velocity.Y = -stats.mSPD;
            }
        }
    }
}
              
    


