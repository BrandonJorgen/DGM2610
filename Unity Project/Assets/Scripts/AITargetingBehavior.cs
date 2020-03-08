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
    public bool prioritySet;
    
    public bool priorityIdOneInRange, priorityIdTwoInRange;
    public IDName priorityIdOne, priorityIdTwo;
    public List<wantedIDs> workIdList;
    public List<possibleTarget> possibleTargetList;
    
    private void OnTriggerEnter(Collider other)
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

    private void CheckId(int stateNumber)
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
                        possibleTargetList.Add(target);
                        prioritySet = false;
                        PriorityTargetChange();

                        if (target.nameIdObj == priorityIdOne)
                        {
                            priorityIdOneInRange = true;
                        }

                        if (target.nameIdObj == priorityIdTwo)
                        {
                            priorityIdTwoInRange = true;
                        }
                        
                        break;
                        
                    case 2:
                        
                        break;
                        
                    case 3:
                        possibleTargetList.Remove(target);
                        
                        if (target.nameIdObj == priorityIdOne)
                        {
                            priorityIdOneInRange = false;
                        }
                        
                        if (target.nameIdObj == priorityIdTwo)
                        {
                            priorityIdTwoInRange = false;
                            
                            foreach (var searchObj in possibleTargetList)
                            {
                                if (searchObj.nameIdObj == priorityIdTwo)
                                {
                                    prioritySet = false;
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
                if (!prioritySet)
                {
                    if (possibleTargetList[i].nameIdObj == priorityIdTwo)
                    {
                        possibleTargetList.Insert(0, possibleTargetList[i]);
                        possibleTargetList.RemoveAt(i + 1);
                        priorityIdTwoInRange = true;
                        return;
                    }
                }
            }
        }
    }
}