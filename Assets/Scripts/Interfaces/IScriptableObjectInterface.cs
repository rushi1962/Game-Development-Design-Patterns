using System;

public interface IScriptableObjectInterface
{
    public void Raise(params object[] Parameters);
    public void Register(Action<object[]> Listener);
    public void Unregister(Action<object[]> Listener);
}
