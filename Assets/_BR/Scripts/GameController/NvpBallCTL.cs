using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class NvpBallCTL : MonoBehaviour, IEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    private IBallModel _ballModel;

    [Inject]
    private IEventController _eventController;

    public float speedFactor;
    public bool paused;
    public Vector3 moveDirection;



    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        SetStartupDir();

        SubscribeToEvents();
    }

    void Update()
    {
        // pause functionality
        if (paused) return;

        this.transform.Translate(moveDirection * speedFactor * Time.deltaTime, Space.World);
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            moveDirection = _ballModel.CalculateNewDirAfterPlayerHit(moveDirection);
            speedFactor = _ballModel.CalcNewSpeed(speedFactor);
        }

        if (other.tag == "Wall") moveDirection = _ballModel.CalculateNewDirAfterWallHit(moveDirection);
    }




    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SubscribeToEvents()
    {
        
    }

    public void UnsubscribeFromEvents()
    {
        
    }

    public void SetStartupDir()
    {
        moveDirection = _ballModel.GetStartupDirection();
    }
}