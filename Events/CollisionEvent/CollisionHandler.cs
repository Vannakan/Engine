using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Events.CollisionEvent
{
    public class CollisionHandler
    {

        public delegate void CollisionEventHandler(object sender, CollisionEventArgs e);

        public event CollisionEventHandler OnCollision;

        //singleton 
        private static CollisionHandler instance;

        public static CollisionHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new CollisionHandler();
                return instance;
            }

        }


        public void Update()
        {

        }

        public void Collision()
        {

        }

    }
}

