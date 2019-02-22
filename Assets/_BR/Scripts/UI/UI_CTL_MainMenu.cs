using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class UI_CTL_MainMenu : MonoBehaviour
{
    
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private IEventController _eventController;
    [SerializeField] private TextMeshProUGUI _pongText;

    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    public void Contruct(IEventController eventController)
    {
        _eventController = eventController;
    }

    void Start()
    {
        _pongText.transform
            .DOScale(1.2f,20)
            .SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Debug.Log("Starting One Player Game");
            _eventController.InvokeEvent(NvpGameEvents.OnStartOnePlayerGame, this, null);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Debug.Log("Starting Two Player Game");
            _eventController.InvokeEvent(NvpGameEvents.OnStartTwoPlayerGame, this, null);
        }
    }
}
