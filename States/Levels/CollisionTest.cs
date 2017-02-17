using ADS.Entities.Platformer;
using ADS.Entities.SATTEST;
using ADS.Utilities;
using Engine.Entities;
using Engine.Managers.Behaviour;
using Engine.Managers.EntityRelated;
using Engine.Managers.Render;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.States.Levels
{
    public class CollisionTest
    {

        Circle ac;
        Circle bc;

        PhysicsMind a;
        PhysicsMind b;

        public CollisionTest()
        {
            EntityManager.Instance.createEntity<PhysicsEntity>(Vector2.Zero);
            EntityManager.Instance.createEntity<PhysicsEntity>(new Vector2(300, 300));
            DrawLine.newLine(new Vector2(0, 400), new Vector2(350, 400), Color.Black);

            DrawLine.newLine(new Vector2(175, 200), new Vector2(175, 600), Color.Black);


            a = (PhysicsMind)BehaviourManager.Instance.getMind(0);
            b = (PhysicsMind)BehaviourManager.Instance.getMind(1);
        }

        public void Update()
        {
            RenderManager.Instance.addString(new ADS.Utilities.GameText("AABB AABB Collision = " + testAABBABB(), "mFont", new Vector2(300, 50), Color.Black, 1f));
            RenderManager.Instance.addString(new ADS.Utilities.GameText("CIRCLE CIRCLE Collision = " + TestCIRCLECIRCLE(), "mFont", new Vector2(300, 75), Color.Black, 1f));
            RenderManager.Instance.addString(new ADS.Utilities.GameText("AABB CIRCLE Collision = " + overlap(new Vector2(a.aabb.min.X, a.aabb.min.Y), b.radius.Centre), "mFont", new Vector2(300, 100), Color.Black, 1f));

        }


        public float DotProduct(Vector2 a, Vector2 b)
        {

            return (float)a.X * b.X + a.Y * b.Y;
        }


        public Vector2 Projection(Vector2 a, Vector2 b, float dot)
        {

            //    proj.X = (dot / (b.X * b.X + b.Y * b.Y)) * b.X;
            // proj.Y = (dot / (b.X * b.X + b.Y * b.Y)) * b.Y;



            //  proj.X = dot*b.X;
            //  proj.X = dot * b.Y;

            Vector2 proj = new Vector2(dot * b.X, dot * b.Y);

            return proj;
        }

        public bool overlap(Vector2 a, Vector2 b)
        {
            Vector2 offset = new Vector2(b.X - a.X, b.Y - a.Y);
            if (offset.Length() < a.Length())
                return true;
            else
                return false;
        }




        public int testAABBABB()
        {
            if (a.aabb.max.X < b.aabb.min.X || a.aabb.min.X > b.aabb.max.X) return 0;
            if (a.aabb.max.Y < b.aabb.min.Y || a.aabb.min.Y > b.aabb.max.Y) return 0;
            else return 1;
        }

        public int TestCIRCLECIRCLE()
        {
            Vector2 d = a.radius.Centre - b.radius.Centre;
            //  float dist2 = DotProduct(d, d);
            float dist2 = Vector2.Dot(d, d);
            float radiusSum = a.radius.Radius + b.radius.Radius;


            if (dist2 <= radiusSum * radiusSum)
            {
                return 1;
            }

            else return 0;
        }

        public void testobbobb(OBB a, OBB b)
        {
            //Rotation values for each OBB
            float ra, rb;
            //Rotation Matrix
            Matrix R, AbsR;

            R = new Matrix();
            AbsR = new Matrix();

            //Compute Rotation Matrix expressing b in a's co-ordinate frame
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    R[i, j] = DotProduct(a.u[i], b.u[i]);

            //Compute Translation Vector
            Vector2 t = b.c.ToVector2() - a.c.ToVector2();

            //Bring translation into a's coordinate frame
            t = new Vector2(DotProduct(t, a.u[0]), DotProduct(t, a.u[1]));


            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    AbsR[i, j] = AbsR[i, j] + float.Epsilon;


            for (int i = 0; i < 2; i++)
            {
                if (i < 2)
                {
                    ra = a.e.X;
                    // return 0;
                }
                else
                {
                    ra = a.e.Y;
                    //return 0;
                }


            }


        }
    }
}


