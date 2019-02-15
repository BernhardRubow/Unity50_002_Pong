using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class NvpPlayerCTL : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Rigidbody _rb;
    private IEventController _eventController;
    private GameObject _ball;

    public string _controllAxis;
    public float force;
    public IPlayerModel playerModel;

    


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    public void Construct(IEventController eventController)
    {
        _eventController = eventController;
    }

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        _ball = GameObject.Find("Ball");
    }

    
    void FixedUpdate()
    {
        var dir = playerModel.CalcNewForceVector(Input.GetAxis(_controllAxis), force, this.gameObject, _ball);

        _rb.AddForce(dir, ForceMode.Force);
    }


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            _eventController?.InvokeEvent(NvpGameEvents.OnHitWall, this, _rb.position);
        }
    }


    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SetControlAxis(string axisName)
    {
        _controllAxis = axisName;
    }
}
