using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Managers.CamManage
{
    public class CameraManager
    {
        //reference to the camera
        Camera camera;

        //singleton
        private static CameraManager instance;

        public static CameraManager Instance
        {
            get
            {
            if(instance == null)
            instance = new CameraManager();
            return instance;
            }
        }

        public void Initialize(Camera cam)
        {
            camera = cam;
        }

        public Camera getCam()
        {
            return camera;
        }

        


    }
}
