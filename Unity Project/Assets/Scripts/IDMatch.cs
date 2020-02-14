using System.Collections.Generic;
using UnityEngine;
//comments are about fixing the possible multiple behavior bug by moving it to other scripts
public class IDMatch : MonoBehaviour
{
    public List<IDName> IDNameList;

    private bool idInTrigger;

    private GameObject triggerObj;
    
    //public List<DoWork> doWorks;
    
    private void OnTriggerEnter(Collider other)
    {
        var triggerObj = other.GetComponent<IDBehavior>(); //change this reference to dedicated variable
        if (triggerObj == null) return;
        var otherIDNameList = triggerObj.IDNameList; //change this reference to dedicated variable

        foreach (var otherID in otherIDNameList)
        {
            foreach (var ID in IDNameList)
            {
                if (ID == otherID)
                {
                    //foreach loop that goes through dowork list
                    //Call Work();
                    triggerObj.EnteredTrigger();
                    return;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var triggerObj = other.GetComponent<IDBehavior>();
        if (triggerObj == null) return;
        var otherIDNameList = triggerObj.IDNameList;

        foreach (var otherID in otherIDNameList)
        {
            foreach (var ID in IDNameList)
            {
                if (ID == otherID)
                {
                    triggerObj.StayedTrigger();
                    return;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var triggerObj = other.GetComponent<IDBehavior>();
        if (triggerObj == null) return;
        var otherIDNameList = triggerObj.IDNameList;

        foreach (var otherID in otherIDNameList)
        {
            foreach (var ID in IDNameList)
            {
                if (ID == otherID)
                {
                    triggerObj.ExitedTrigger();
                    return;
                }
            }
        }
    }
    
    //add function that does checking here
}