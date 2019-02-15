using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using TMPro;
using UnityEngine;
using Zenject;

public class UI_CTL_Game : MonoBehaviour, IEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private IEventController _eventController;
    public int leftPlayerScore { get; private set;  }
    public int rightPlayerScore { get; private set; }

    [SerializeField] private TextMeshProUGUI _leftPlayerScoreText;
        
    [SerializeField] private TextMeshProUGUI _rightPlayerScoreText;



    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    public void Construct(IEventController eventController)
    {
        _eventController = eventController;
    }

    void Start()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        SubscribeToEvents();
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    private void OnLeftPlayerScores(object arg1, object arg2)
    {
        leftPlayerScore = leftPlayerScore + 1;
        _leftPlayerScoreText.text = leftPlayerScore.ToString("00");

        CheckGameOver();
    }

    private void OnRightPlayerScores(object arg1, object arg2)
    {
        rightPlayerScore = rightPlayerScore + 1;
        _rightPlayerScoreText.text = rightPlayerScore.ToString("00");

        CheckGameOver();
    }




    // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SubscribeToEvents()
    {
        _eventController?.SubscribeToEvent(NvpGameEvents.OnLeftPlayerScores, OnLeftPlayerScores);
        _eventController?.SubscribeToEvent(NvpGameEvents.OnRightPlayerScores, OnRightPlayerScores);
    }

    public void UnsubscribeFromEvents()
    {
        _eventController?.UnsubscribeFromEvent(NvpGameEvents.OnLeftPlayerScores, OnLeftPlayerScores);
        _eventController?.UnsubscribeFromEvent(NvpGameEvents.OnRightPlayerScores, OnRightPlayerScores);
    }

        




    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void CheckGameOver()
    {
        if (leftPlayerScore == 5 || rightPlayerScore == 5)
        {
            _eventController?.InvokeEvent(NvpGameEvents.OnGameOver, this, null);
        }
    }

}
