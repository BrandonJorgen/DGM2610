using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GameAction : ScriptableObject
{
    public UnityAction action;
    public UnityAction<object> objAction;

    public void Raise()
    {
        action?.Invoke();
    }

    public void Raise(object obj)
    {
        objAction(obj);
    }
}