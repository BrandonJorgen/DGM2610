using System;
using System.Collections.Generic;
using UnityEngine;

public class ParentingBehavior : MonoBehaviour
{
    private GameObject parentObj;
    private bool isParented;
    
    [Serializable]
    public struct possibleWork
    {
        public IDName nameIdObj;
    }

    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;
    public List<possibleWork> workIdList;
    
    private void OnTriggerEnter(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(1);
    }
    
    private void OnTriggerExit(Collider other)
    {
        otherBehaviourObj = other.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(2);
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
                        parentObj = otherBehaviourObj.gameObject;
                        break;
                    
                    case 2:
                        parentObj = null;
                        break;
                }
            }
        }
    }
    
    public void ParentSwitch()
    {
        if (!isParented)
        {
            if (parentObj != null)
            {
                transform.parent = parentObj.transform;
                isParented = true;
            }
        }
        else
        {
            UnParentObj();
        }
    }

    public void UnParentObj()
    {
        transform.parent = null;
        isParented = false;
    }
}