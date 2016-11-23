using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Events.ConvoEvent
{
    public class ConvoHandler
    {
        //Define our delegates
        public delegate void ConvoEventHandler(object sender, ConvoEventArgs e);
        //Define our events
        public event ConvoEventHandler onConversationStarted;
        public event ConvoEventHandler onConversationEnded;


        //singleton
        private static ConvoHandler instance;

        public static ConvoHandler Instance
        {
        get{
        if(instance == null)
        instance = new ConvoHandler();

        return instance;
    }

    }
        public void Update(GameTime gameTime)
        {

        }

        protected virtual void ConvoStarted()
        {
            if(onConversationStarted != null)
            {
                onConversationStarted(this, new ConvoEventArgs());
            }
        }

        protected virtual void ConvoEnded()
        {
            if(onConversationEnded != null)
            {
                onConversationEnded(this, new ConvoEventArgs());
            }
        }

       
    }
}
