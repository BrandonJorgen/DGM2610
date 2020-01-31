using System.Collections.Generic;
using UnityEngine;

public class IDMatch : MonoBehaviour
{
    public List<IDName> IDNameList;
    
    private void OnTriggerEnter(Collider other)
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
                    Debug.Log(otherID + " Matches: " + ID + " and is attached to: " + other);
                    triggerObj.Execute();
                    return;
                }
            }
        }
    }
}