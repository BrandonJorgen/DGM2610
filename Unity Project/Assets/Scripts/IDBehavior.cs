using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDBehavior : MonoBehaviour
{
    public List<IDName> IDNameList;
    public UnityEvent EnteredEvent, ExitedEvent;

    public void EnteredTrigger()
    {
        EnteredEvent.Invoke();
    }

    public void ExitedTrigger()
    {
        ExitedEvent.Invoke();
    }
}