using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvpSceneCTL_Game : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private PongGameConfig _config;





    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        Debug.LogFormat("Number of Players: {0}", _config.numberOfPlayers);
    }

    void Update()
    {
        
    }
}
