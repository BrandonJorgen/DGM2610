using UnityEngine;

public class ParentingBehavior : MonoBehaviour
{
    private Collider parentObj;
    private bool isParented;
    
    private void OnTriggerEnter(Collider other)
    {
        parentObj = other;
        Debug.Log(other + " " + parentObj);
    }

    public void ParentingLogic()
    {
        if (!isParented)
        {
            transform.parent = parentObj.transform;
            isParented = true;
        }
        else
        {
            transform.parent = null;
            isParented = false;
        }
    }
}