using UnityEngine;

public class ParentingBehavior : MonoBehaviour
{
    private GameObject objToParent;
    private bool isParented;
    
    private void OnTriggerEnter(Collider other)
    {
        objToParent = other.gameObject;
    }

    public void ParentSwitch()
    {
        if (!isParented)
        {
            transform.parent = objToParent.transform;
            isParented = true;
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