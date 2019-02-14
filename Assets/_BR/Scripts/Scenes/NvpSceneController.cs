using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class NvpSceneController : ISceneController
{

    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Camera mainCam;




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void RequestScene(string sceneName)
    {
        this.LoadScene(sceneName);
    }

    public void SetMenuCam(Camera mainMenuCam)
    {
        mainCam = mainMenuCam;
    }

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
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);   
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        mainCam.enabled = false;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
