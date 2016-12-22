using Engine;
using Engine.Entities;
using Engine.Managers.Render;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.GUI
{

    //This class will soon allow for drawing certain objects to the screen (will change into rendermanager eventually) that ignore the cameras matrix transformations
    public class GuiManager
    {
        //Lets the GUI manager draw player stats.
        private PlayerMind player;
        //Temporary texture for Players HP
        Texture2D HPTEST;
        //Temporary Rectangle for Player HP
        Rectangle rectangl;
        Rectangle EXP;

        private static GuiManager instance;

            public static GuiManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GuiManager();


                return instance;
            }
        }


        public void Initialize()
        {
            HPTEST = ResourceLoader.Instance.GetTex("Tile1");
        }

        public void setPlayer(PlayerMind player)
        {
            this.player = player;
            rectangl = new Rectangle(30, 30, player.stats.HP, 20);
            EXP = new Rectangle(30, 50, player.stats.EXP, 20);

        }

        public void DrawGUI()
        {
            if (player != null)
            {
                if (rectangl != null)
                    RenderManager.Instance.Draw(HPTEST, rectangl, Color.Green);
                if (EXP != null)
                    RenderManager.Instance.Draw(HPTEST, EXP, Color.Yellow);
            }
        }

        //Only temporary. We want our GUI to be event based. I.e
        //If player takes damage, update the GUI at that point rather
        //than continously checking for player damage
        public void Update()
        {
            if (player != null)
            {
                rectangl.Width = player.stats.HP;
                EXP.Width = player.stats.EXP;
            }
            
        }
    }
}
