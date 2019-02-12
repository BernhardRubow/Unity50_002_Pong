using System;

namespace nvp.interfaces
{
    public interface IEventController
    {
        void InvokeEvent(NvpGameEvents e, object sender, object eventArgs);
        void Reset();
        void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback);
        void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer);
    }
}