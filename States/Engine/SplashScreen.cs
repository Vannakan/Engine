using Engine.Events.KeyboardEvent;
using Engine.Managers.CamManage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
     class SplashScreen : BaseScreen
    {
         CameraManager cam = CameraManager.Instance;
        float alpha = 0;
        bool hasEnded = false;
        bool transIn = true;
        bool transOut = false;
        public SplashScreen()
        {

        }


        public override void Initialize()
        {
            KeyHandler.Instance.KeyDown += OnKeyDown;

            base.Initialize();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(ResourceLoader.Instance.GetTex("AcePic"), cam.getWorldPosition(new Vector2(275,50)), Color.White * alpha);
            base.Draw(sb);
        }

        public override void Update(GameTime gameTime)
        {

            if(transIn)
            alpha += 0.010f;
            else if(transOut)
             alpha -= 0.010f;

            if(alpha >= 1)
            {
                transOut = true;
                transIn = false;
            }
            if(alpha <= 0 && transOut)
            {
                ScreenManager.Instance.ReplaceScreen("MainMenu");

            }
            base.Update(gameTime);
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.key == Microsoft.Xna.Framework.Input.Keys.Space)
                ScreenManager.Instance.ReplaceScreen("MainMenu");

        }
}
     }
