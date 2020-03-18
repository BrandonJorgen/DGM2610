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

    private GameObject otherGameObj;
    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;
    
    public IDName priorityIdOne, priorityIdTwo;
    public List<wantedIDs> workIdList;
    public List<possibleTarget> possibleTargetList;
    
    public void OnTriggerEnter(Collider other)
    {
        otherGameObj = other.gameObject;
        if (otherGameObj == null) return;
        otherBehaviourObj = otherGameObj.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(1);
    }

    private void OnTriggerStay(Collider other)
    {
        otherGameObj = other.gameObject;
        if (otherGameObj == null) return;
        otherBehaviourObj = otherGameObj.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(2);
    }

    private void OnTriggerExit(Collider other)
    {
        otherGameObj = other.gameObject;
        if (otherGameObj == null) return;
        otherBehaviourObj = otherGameObj.GetComponent<IDBehavior>();
        if (otherBehaviourObj == null) return;
        otherIdObj = otherBehaviourObj.nameIdObj;
        CheckId(3);
    }

    public void CheckId(int stateNumber)
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                possibleTarget target = new possibleTarget();
                target.gameObj = otherGameObj;
                target.nameIdObj = otherIdObj;
                
                switch (stateNumber)
                {
                    case 1:
                        if (possibleTargetList.Contains(target))
                        {
                            return;
                        }
                        else
                        {
                            possibleTargetList.Add(target);
                        }
                        
                        PriorityTargetChange();
                        
                        break;
                        
                    case 2:
                        
                        break;
                        
                    case 3:
                        possibleTargetList.Remove(target);
                        
                        if (target.nameIdObj == priorityIdTwo)
                        {
                            
                            foreach (var searchObj in possibleTargetList)
                            {
                                if (searchObj.nameIdObj == priorityIdTwo)
                                {
                                    PriorityTargetChange();
                                    return;
                                }
                            }
                        }
                        
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
                if (possibleTargetList[i].nameIdObj == priorityIdTwo)
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
        possibleTarget target = new possibleTarget();
        target.gameObj = obj;
        target.nameIdObj = obj.GetComponent<IDBehavior>().nameIdObj;
        if (!possibleTargetList.Contains(target))
        {
            possibleTargetList.Add(target);
        }
        PriorityTargetChange();
    }
}