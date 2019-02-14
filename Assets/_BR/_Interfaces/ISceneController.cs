using UnityEngine;

namespace nvp.interfaces
{
    public interface ISceneController
    {
        void RequestScene(string sceneName);
        void SetMenuCam(Camera mainMenuCam);
    }
}