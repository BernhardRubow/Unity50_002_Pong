using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class NvpSceneCTL_Main : MonoBehaviour, IEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private IEventController _eventController;
    private ISceneController _sceneController;


    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private GameObject _sceneUI;
    [SerializeField] private PongGameConfig _config;





    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    void Construct(IEventController ec, ISceneController sc)
    {
        _eventController = ec;
        _sceneController = sc;
    }

    void Start()
    {
        SubscribeToEvents();
    }

    void Update()
    {
        
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    private void OnStartOnePlayerGame(object s, object e)
    {
        _sceneController.RequestScene("Game");
        _sceneUI.SetActive(false);
    }

    private void OnStartTwoPlayerGame(object s, object e)
    {
        _sceneController.RequestScene("Game");
        _sceneUI.SetActive(false);
    }




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SubscribeToEvents()
    {
        _eventController.SubscribeToEvent(NvpGameEvents.OnStartOnePlayerGame, OnStartOnePlayerGame);
        _eventController.SubscribeToEvent(NvpGameEvents.OnStartTwoPlayerGame, OnStartTwoPlayerGame);
    }

    public void UnsubscribeFromEvents()
    {
        _eventController.UnsubscribeFromEvent(NvpGameEvents.OnStartOnePlayerGame, OnStartOnePlayerGame);
        _eventController.UnsubscribeFromEvent(NvpGameEvents.OnStartOnePlayerGame, OnStartTwoPlayerGame);
    }
}
