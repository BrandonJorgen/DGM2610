using UnityEngine;

public class ParentingBehavior : MonoBehaviour
{
    private GameObject objToParent;
    private bool isParented;
    
    private void OnTriggerEnter(Collider other)
    {
        objToParent = other.gameObject;
        Debug.Log(objToParent);
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
            transform.parent = null;
            isParented = false;
        }
    }
}