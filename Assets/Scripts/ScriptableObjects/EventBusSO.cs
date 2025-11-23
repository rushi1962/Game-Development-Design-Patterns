using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EventBusSO", menuName = "Scriptable Objects/EventBusSO")]
public class EventBusSO : ScriptableObject, IScriptableObjectInterface
{
    private event Action<object[]> Listeners;

    public void Raise(params object[] Parameters)
    {
        Listeners?.Invoke(Parameters);
    }

    public void Register(Action<object[]> Listener)
    {
        Listeners += Listener;
    }

    public void Unregister(Action<object[]> Listener)
    {
        Listeners -= Listener;
    }
}
