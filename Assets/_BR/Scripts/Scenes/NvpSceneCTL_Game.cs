using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
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

        var leftPlayer = GameObject.Find("PlayerLeft").GetComponent<NvpPlayerCTL>();
        var rightPlayer = GameObject.Find("PlayerRight").GetComponent<NvpPlayerCTL>();

        switch (_config.numberOfPlayers)
        {
            case 0:
                leftPlayer.playerModel = new NvpComputerV4Model();
                rightPlayer.playerModel = new NvpComputerV4Model();
                break;

            case 1:
                leftPlayer.playerModel = new NvpHumanPlayerModel();
                rightPlayer.playerModel = new NvpComputerV4Model();
                break;

            case 2:
                leftPlayer.playerModel = new NvpHumanPlayerModel();
                rightPlayer.playerModel = new NvpHumanPlayerModel();
                break;

            default:
                leftPlayer.playerModel = new NvpComputerV2Model();
                rightPlayer.playerModel = new NvpComputerV2Model();
                break;
        }
    }

    void Update()
    {
        
    }
}
