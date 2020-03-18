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
        public UnityEvent EnterEvent, StayEvent, ExitEvent;
    }

    protected IDBehavior otherBehaviourObj;
    protected IDName otherIdObj;
    public List<possibleWork> workIdList;
    
    private void OnTriggerEnter(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(1);
    }

    private void OnTriggerStay(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(2);
    }

    private void OnTriggerExit(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(3);
    }

    private void CheckId(int stateNumber)
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                switch (stateNumber)
                {
                        case 1:
                            obj.EnterEvent.Invoke();
                            break;
                        
                        case 2:
                            obj.StayEvent.Invoke();
                            break;
                        
                        case 3:
                            obj.ExitEvent.Invoke();
                            break;
                }
            }
        }
    }
}