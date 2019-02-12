using System;
using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using UnityEngine;

namespace nvp.events
{
    

    public class NvpEventController : IEventController
    {

        // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private Dictionary<NvpGameEvents, List<Action<object, object>>> _eventCallbacks;




        // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public NvpEventController()
        {
            _eventCallbacks = new Dictionary<NvpGameEvents, List<Action<object, object>>>();
        }

        ~NvpEventController()
        {
            _eventCallbacks = null;
        }



        // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback)
        {
            if (!_eventCallbacks.ContainsKey(e))
            {
                _eventCallbacks[e] = new List<Action<object, object>>();
            }

            _eventCallbacks[e].Add(callback);
        }


        public void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer)
        {
            if (!_eventCallbacks.ContainsKey(e)) return;

            if (!_eventCallbacks[e].Contains(observer)) return;

            _eventCallbacks[e].Remove(observer);
        }


        public void InvokeEvent(NvpGameEvents e, object sender, object eventArgs)
        {
            if (!_eventCallbacks.ContainsKey(e)) return;

            foreach (var observer in _eventCallbacks[e])
                observer(sender, eventArgs);
        }


        public void Reset()
        {
            _eventCallbacks = new Dictionary<NvpGameEvents, List<Action<object, object>>>();
        }
    }
}
