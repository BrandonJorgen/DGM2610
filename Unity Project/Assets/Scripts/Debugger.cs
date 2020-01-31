using UnityEngine;

[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void EventDebug(string message)
    {
        Debug.Log(message);
    }
}