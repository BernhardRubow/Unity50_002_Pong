using System;
using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;

public class NvpEventControllerMock : IEventController
{
    public void InvokeEvent(NvpGameEvents e, object sender, object eventArgs)
    {
        Debug.LogFormat("Invoke called for event: {0}", e.ToString());
    }

    public void Reset()
    {
        Debug.Log("Reset called");
    }

    public void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback)
    {
        Debug.LogFormat("Subscribed to {0}",e.ToString());
    }

    public void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer)
    {
        Debug.LogFormat("Unsubscribed to {0}",e.ToString());
    }
}
