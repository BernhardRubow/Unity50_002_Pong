using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class UI_CTL_MainMenu : MonoBehaviour
{
    
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private IEventController _eventController;

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    public void Contruct(IEventController eventController)
    {
        _eventController = eventController;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            _eventController.InvokeEvent(NvpGameEvents.OnStartOnePlayerGame, this, null);
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            _eventController.InvokeEvent(NvpGameEvents.OnStartTwoPlayerGame, this, null);
        }
    }
}
