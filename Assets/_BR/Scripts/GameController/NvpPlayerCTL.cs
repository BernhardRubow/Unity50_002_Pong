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

    public string _controllAxis;
    public float force;

    


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [Inject]
    void Construct(IEventController eventController)
    {
        _eventController = eventController;
    }

    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = Vector3.up * Input.GetAxis(_controllAxis) * force;

        _rb.AddForce(dir, ForceMode.Force);
    }


    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
            _eventController.InvokeEvent(NvpGameEvents.OnHitWall, this, _rb.position);
    }


    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void SetControllAxis(string axisName)
    {
        _controllAxis = axisName;
    }
}
