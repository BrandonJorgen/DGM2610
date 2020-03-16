using UnityEngine;

[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void EventDebug(string message)
    {
        Debug.Log(message);
    }

    public void EventDebug(GameObject obj)
    {
        Debug.Log(obj);
    }
}