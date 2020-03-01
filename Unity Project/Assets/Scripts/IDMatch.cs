using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDMatch : IDBehavior
{
    [Serializable]
    public struct possibleWork
    {
        public IDName nameIdObj;
        public UnityEvent workEvent;
    }

    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;
    public List<possibleWork> workIdList;
    
    private void OnTriggerEnter(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId();
    }

    private void CheckId()
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                obj.workEvent.Invoke();
            }
        }
    }
}