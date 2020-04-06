using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDMatchDelayed : IDBehavior
{
    [Serializable]
    public struct possibleWork
    {
        public IDName nameIdObj;
        public UnityEvent EnterEvent, ExitEvent;
    }

    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;

    public float enterDelay = 1f, exitDelay = 1f;
    private WaitForSeconds waitEnterObj, waitExitObj;
    
    public List<possibleWork> workIdList;

    private void Start()
    {
        waitEnterObj = new WaitForSeconds(enterDelay);
        waitExitObj = new WaitForSeconds(exitDelay);
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) yield break;
        otherIdObj = otherBehaviourObj.nameIdObj;
        yield return waitEnterObj;
        CheckId(1);
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) yield break;
        otherIdObj = otherBehaviourObj.nameIdObj;
        yield return waitExitObj;
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
                        
                    case 3:
                        obj.ExitEvent.Invoke();
                        break;
                }
            }
        }
    }
}