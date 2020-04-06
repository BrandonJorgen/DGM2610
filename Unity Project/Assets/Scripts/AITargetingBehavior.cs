using System;
using System.Collections.Generic;
using UnityEngine;

public class AITargetingBehavior : MonoBehaviour
{
    [Serializable]
    public struct wantedIDs
    {
        public IDName nameIdObj;
    }
    
    [Serializable]
    public struct possibleTarget
    {
        public GameObject gameObj;
        public IDName nameIdObj;
    }

    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;
    
    private possibleTarget currentTarget;
    public Vector3SO targetV3;
    public IDName priorityIdOne;
    public List<wantedIDs> workIdList;
    public List<possibleTarget> possibleTargetList;

    private void Update()
    {
        if (possibleTargetList.Count != 0)
        {
            targetV3.vector3 = possibleTargetList[0].gameObj.transform.position;
        }
    }

    public void OnTriggerEnter(Collider other)
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

    public void CheckId(int stateNumber)
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                currentTarget.gameObj = otherBehaviourObj.gameObject;
                currentTarget.nameIdObj = otherIdObj;
                
                switch (stateNumber)
                {
                    case 1:
                        if (!possibleTargetList.Contains(currentTarget))
                        {
                            possibleTargetList.Add(currentTarget);
                        }
                        
                        PriorityTargetChange();
                        break;
                        
                    case 2:
                        possibleTargetList.Remove(currentTarget);
                        PriorityTargetChange();
                        break;
                }
            }
        }
    }

    private void PriorityTargetChange()
    {
        if (possibleTargetList.Count != 0)
        {
            for (int i = 0; i <= possibleTargetList.Count - 1; i++)
            {
                if (possibleTargetList[i].nameIdObj == priorityIdOne)
                {
                    possibleTargetList.Insert(0, possibleTargetList[i]);
                    possibleTargetList.RemoveAt(i + 1);
                    return;
                }
            }
        }
    }

    public void RemoveTarget()
    {
        if (possibleTargetList.Count != 0)
        {
            possibleTargetList.RemoveAt(0);
            PriorityTargetChange();
        }
    }

    public void AddObjToList(GameObject obj)
    {
        currentTarget.gameObj = obj;
        currentTarget.nameIdObj = obj.GetComponent<IDBehavior>().nameIdObj;
        if (!possibleTargetList.Contains(currentTarget))
        {
            possibleTargetList.Add(currentTarget);
        }
        
        PriorityTargetChange();
    }
}