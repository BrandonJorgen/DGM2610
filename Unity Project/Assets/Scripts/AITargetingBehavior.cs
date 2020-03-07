using System;
using System.Collections.Generic;
using UnityEngine;

public class AITargetingBehavior : IDBehavior
{
    [Serializable]
    public struct wantedIDs
    {
        public IDName nameIdObj;
    }

    private GameObject otherGameObj;
    private IDBehavior otherBehaviourObj;
    private IDName otherIdObj;
    public List<wantedIDs> workIdList;
    public List<GameObject> possibleTargetList;
    
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
    
    //FUNCTION that checks if first ID in list matches priority ID
    //If not, keep going down list until there is a match then set that to first ID

    private void CheckId(int stateNumber)
    {
        foreach (var obj in workIdList)
        {
            if (otherIdObj == obj.nameIdObj)
            {
                switch (stateNumber)
                {
                    case 1:
                        Debug.Log(possibleTargetList.Count + 1);
                        if (possibleTargetList.Count != 0)
                        {
                            foreach (var targetObj in possibleTargetList)
                            {
                                if (otherGameObj == targetObj)
                                {
                                    return;
                                }

                                possibleTargetList.Add(otherGameObj);
                            }
                        }
                        else
                        {
                            possibleTargetList.Add(otherGameObj);
                        }
                        break;
                        
                    case 2:
                        
                        break;
                        
                    case 3:
                        foreach (var gameObj in possibleTargetList)
                        {
                            if (otherGameObj == gameObj)
                            {
                                possibleTargetList.Remove(gameObj);
                            }
                        }
                        break;
                }
            }
        }
    }
}