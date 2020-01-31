using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDBehavior : MonoBehaviour
{
    public List<IDName> IDNameList;
    public UnityEvent ExecuteEvent;

    public void Execute()
    {
        ExecuteEvent.Invoke();
    }
}