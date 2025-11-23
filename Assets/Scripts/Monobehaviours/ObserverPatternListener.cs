using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverPatternListener : MonoBehaviour
{
    public EventBusSO EventBusScriptableObject;

    private void OnEnable()
    {
        EventBusScriptableObject.Register(Listen);
    }

    protected virtual void Listen(object[] parameters)
    {
        
    }

    private void OnDisable()
    {
        EventBusScriptableObject.Unregister(Listen);
    }
}
