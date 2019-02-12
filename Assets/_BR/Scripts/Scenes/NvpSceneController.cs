using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NvpSceneController : ISceneController
{ 

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    

    // +++ class methods (static) +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void RequestScene(string sceneName)
    {
        this.LoadScene(sceneName);
    }


    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void LoadScene(string sceneName)
    {
        switch (sceneName)
        {
            case "Game":
                LoadGameSceneAdditive();
                break;
        }
    }

    private void LoadGameSceneAdditive()
    {
        Camera mainCam = GameObject.FindObjectOfType<Camera>();

        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
        mainCam.enabled = false;
    }
}
