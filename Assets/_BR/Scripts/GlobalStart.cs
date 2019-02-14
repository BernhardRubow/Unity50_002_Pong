using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GlobalStart : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    private ISceneController _sceneController;

    // Start is called before the first frame update
    void Start()
    {
        _sceneController.RequestScene("MainMenu");
    }
}
