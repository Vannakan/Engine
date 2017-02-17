using Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Engine.Events.MouseEvent;
using Engine.Managers.CamManage;
using Engine.Managers.Behaviour;
using Engine.Managers.EntityRelated;
using Engine;

namespace ADS.Entities
{
   public class steermind : Mind
    {



        private Vector2 direction;
        private Vector2 velocityy;
        private Vector2 DesiredVelocity;
        private Vector2 steeringForce;
      
        private float rotationAngle;
        private Vector2 origin = Vector2.Zero;
        private float MaxVelocity = 6f;
        private float MaxForce = 0.5f;
        private float mass = 30;
        private int counter1 = 0;
        int neighbourCount = 0;


        //Steering behaviour weighting for the alignment
        private float alignmentWeight = 1.4f;
        //Steering behaviour weighting for the cohesion
        private float cohesionWeight = 0.8f;
        //steering behaviour weighting for the seperation
        private float seperationWeight = 0.8f;

        private int wanderRange = 1000;

        private Vector2 flockGoal;
        private bool flockset = false;

        private bool wonderSet = false;
        private Vector2 wonderTarget = new Vector2();

        public void Seek(Vector2 Target)
        {
            //Find the direction
            direction = Vector2.Normalize(Target - _pos);
            //Find the desired Velocity
            DesiredVelocity = direction * MaxVelocity;
            //calculate the force we want to apply 
            steeringForce = DesiredVelocity - velocity;
            //Check that the steering force hasnt exceeded the max force
            steeringForce = CheckMax(steeringForce, MaxForce);
            //Apply mass
            steeringForce = steeringForce / mass;
            //Adjust velocity with the steering force
            velocity += steeringForce;
            //Apply velocity to pos
            _pos += velocity;
        }

        public void Flee(Vector2 Target)
        {
            //Find the direction
            direction = Vector2.Normalize(_pos - target.Position);
            //Find the desired Velocity
            DesiredVelocity = direction * MaxVelocity;
            //calculate the force we want to apply 
            steeringForce = DesiredVelocity - velocity;
            //Check that the steering force hasnt exceeded the max force
            steeringForce = CheckMax(steeringForce, MaxForce);
            //Apply mass
            steeringForce = steeringForce / mass;
            //Adjust velocity with the steering force
            velocity += steeringForce;
            //Apply velocity to pos
            _pos += velocity;
        }

        public void Wander()
        {

            int ran = Constants.r.Next(50, 130);

            if (!wonderSet)
            {

                wonderTarget = new Vector2(Constants.r.Next(0, wanderRange), Constants.r.Next(0, wanderRange));
                wonderSet = true;
            }
            counter++;

            if (counter >= ran)
            {
                wonderTarget = new Vector2(Constants.r.Next(0, wanderRange), Constants.r.Next(0, wanderRange));
                counter = 0;
            }

            Seek(wonderTarget);

        }

        public void flock()
        {
            Random random = new Random();
            int ran = 50;

            if (!flockset)
            {

                flockGoal = new Vector2(random.Next(0, wanderRange), random.Next(0, wanderRange));
                flockset = true;
            }
            counter++;

            if (counter >= ran)
            {
                flockGoal = new Vector2(random.Next(0, wanderRange), random.Next(0, wanderRange));
                counter = 0;
            }

            Seek(flockGoal);


        }

        public void Pursue(IMind Target)
        {
            //Find distance from player to missle
            Vector2 distance = Target.Position - _pos;
            //Time until missle hits target. Will be used to steer closer into the target when gap is close. The further away, we try to steer in front of the target
            float T = distance.Length() / MaxVelocity;
            Vector2 futurePosition = Target.Position + Target.Velocity * T;

            Seek(futurePosition);
        }

        public Vector2 flockBehaviour(Vector2 v)
        {
            v += calcAlignment() * alignmentWeight + calcCohesion() * cohesionWeight + calcSeperation() * seperationWeight;
            return v;

        }

        public void setNeighbourhood(List<steermind> list)
        {
            neighbours = list;
        }

        public Vector2 calcAlignment()
        {
            foreach (steermind m in neighbours)
            {
                if (m != this)
                {
                    if (Vector2.Distance(_pos, m.getPosition()) < 50)
                    {
                        velocity += m.getVelocity();
                        neighbourCount++;
                    }
                }
            }

            if (neighbourCount == 0)
                return velocity;

            velocity.X /= neighbourCount;
            velocity.Y /= neighbourCount;
            velocity.Normalize();
            return velocity;
        }

        public Vector2 calcCohesion()
        {
            foreach (steermind m in neighbours)
            {
                if (m != this)
                {
                    if (Vector2.Distance(_pos ,m.getPosition()) < 50)
                    {
                        velocity += m.getPosition();
                        neighbourCount++;
                    }
                }
            }

            if (neighbourCount == 0)
                return velocity;

            velocity.X /= neighbourCount;
            velocity.Y /= neighbourCount;

            velocity = new Vector2(Velocity.X - Position.X, Velocity.Y - Position.Y);
            velocity.Normalize();
            return velocity;
        }

        public Vector2 calcSeperation()
        {
            foreach (steermind m in neighbours)
            {
                if (m != this)
                {
                    if (Vector2.Distance(_pos, m.getPosition()) < 50)
                    {
                        velocity += m.getPosition() - _pos;
                        neighbourCount++;
                    }
                }
            }

            if (neighbourCount == 0)
            {
                return velocity;
            }

            velocity.X /= neighbourCount;
            velocity.Y /= neighbourCount;
            velocity.X *= -1;
            velocity.Y *= -1;
            velocity.Normalize();
            return velocity;
        }


        public Vector2 CheckMax(Vector2 v, float maxValue)
        {
            float x = maxValue / v.Length();

            //Check if X is loswer than the maximum value
            if (x < 1.0)
            {
                x = 1.0f;
            }

            v.X = v.X + x;
            v.Y = v.Y + x;
            return v;
        }

        public Vector2 getVelocity()
        {
            return velocity;
        }

        public Vector2 getPosition()
        {
            return _pos;
        }

        public Vector2 getNormalPos()
        {
            return Vector2.Normalize(_pos);
        }

        public Vector2 getNormalVel()
        {
            return Vector2.Normalize(velocity);

        }

        public Vector2 getNormalDesVel()
        {
            return Vector2.Normalize(DesiredVelocity);
        }

        public Vector2 getNormalSteering()
        {
            return Vector2.Normalize(steeringForce);
        }


        Circle radius;
        int counter = 0;
        bool spawned = false;

        //ready for implementation of new behaviours
        private static List<steermind> neighbours = new List<steermind>();
        IMind target;
        
        IMind b;

        public steermind()
        {
            MouseHandler.Instance.MouseMoved += onMouseMoved;
   
        }

        public override void Initialize(Vector2 Position)
        {
            texPath = "virus1";
            int id = EntityManager.Instance.getCamEntity("Player").UniqueID;
            target = BehaviourManager.Instance.getMind(id);
            neighbours.Add(this);
                        base.Initialize(Position);

        }

        public void onMouseMoved(object Sender, MouseEventArgs m)
        {
            Vector2 world = new Vector2(m.X, m.Y);
          //  target = CameraManager.Instance.getWorldPosition(world);

        }

        public override void Unload()
        {
            neighbours.Remove(this);
            base.Unload();
        }

        public override void Update(GameTime gameTime)
        {
             counter++;


            if (spawned != true)
            {
                if (counter >= 100)
                {
                    radius = new Circle(100, _pos);
                    EntityManager.Instance.createEntityCamDrawable<steerEntity>(radius.randomPos());

                    spawned = true;
                }
            }

            velocity = flockBehaviour(velocity);
            Vector2 distance = target.Position - Position;
            if (distance.Length() < 300)
                Pursue(target);
            else
                flock();

              velocity.Normalize();

            base.Update(gameTime);

        }
    }
}
