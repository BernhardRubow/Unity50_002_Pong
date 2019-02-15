using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class NvpBallCTL : MonoBehaviour, IEventHandler
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private IBallModel _ballModel;

    private IEventController _eventController;

    private bool stopped = false; 


    public float speedFactor;
    public bool paused;
    public Vector3 moveDirection;




    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    public void Contruct(IEventController ec, IBallModel bm)
    {
        _eventController = ec;
        _ballModel = bm;
    }

    void Start()
    {
        SetStartupDir();

        SubscribeToEvents();
    }

    void Update()
    {
        // pause functionality
        if (paused || stopped) return;

        this.transform.Translate(moveDirection * speedFactor * Time.deltaTime, Space.World);
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnDisable()
    {
        UnsubscribeFromEvents();
    }

    async void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            moveDirection = _ballModel.CalculateNewDirAfterPlayerHit(moveDirection);
            speedFactor = _ballModel.CalcNewSpeed(speedFactor);
        }

        if (other.tag == "Wall")
        {
            moveDirection = _ballModel.CalculateNewDirAfterWallHit(moveDirection);
        }

        if (other.tag == "OutOfBounds")
        {
            // score points
            OnPlayerScored();

            // reset position and speed
            OnResetBall();

            // wait some time before starting the ball again
            stopped = true;
            await Task.Delay(3000);
            stopped = false;
        }
    }

    private void OnResetBall()
    {
        speedFactor = _ballModel.CalcNewStartSpeed(speedFactor);
        this.transform.position = new Vector3();
    }

    private void OnPlayerScored()
    {
        if (this.transform.position.x > 0)
        {
            _eventController.InvokeEvent(NvpGameEvents.OnRightPlayerScores, this, null);
        }
        else
        {
            _eventController.InvokeEvent(NvpGameEvents.OnLeftPlayerScores, this, null);
        }
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