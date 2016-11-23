using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Managers.State
{
    public enum Transition { In,Out}
    public class Fader : IDrawable
    {
        Transition trans = Transition.Out;
     
       public  bool ready = false;

        Texture2D t;
        Rectangle draw;
        float alpha = 1f;
        float Speed = 0.010f;

        public Fader(Vector2 Size)
        {

            t = new Texture2D(Constants.g,1,1);
            t.SetData(new[] { Color.Black * alpha});
            draw = new Rectangle(0, 0, (int)Size.X, (int)Size.Y);
        }

        public Fader(Vector2 Size, Vector2 p)
        {

            t = new Texture2D(Constants.g, 1, 1);
            t.SetData(new[] { Color.Black * alpha });
            draw = new Rectangle((int)p.X,(int) p.Y, (int)Size.X, (int)Size.Y);
        }

        public Fader(Vector2 Size, Vector2 p, float speed)
        {
            Speed = speed;
            t = new Texture2D(Constants.g, 1, 1);
            t.SetData(new[] { Color.Black * alpha });
            draw = new Rectangle((int)p.X, (int)p.Y, (int)Size.X, (int)Size.Y);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(t, draw, Color.Black);
        }

        int timer = 0;

        public void Update()
        {
            timer++;
            if (trans == Transition.In)
                alpha += Speed;
            else if (trans == Transition.Out)
                alpha -= Speed;

            if (alpha <= 0 && trans == Transition.Out)
            { 
                ready = true;
                alpha = 0;
            }

            if (alpha >= 1 && timer >= 100)
            {
                alpha = 1;
                trans = Transition.Out;
            }
            t.SetData(new[] { Color.Black * alpha });

        }



    }
}
