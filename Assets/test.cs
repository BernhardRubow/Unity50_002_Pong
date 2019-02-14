using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;
using Zenject;

public class test : MonoBehaviour
{
    private IEventController _ec;

    [Inject]
    void Construct(IEventController ec)
    {
        _ec = ec;
    }


    void Start()
    {
        _ec.InvokeEvent(NvpGameEvents.OnStartOnePlayerGame, null, null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
