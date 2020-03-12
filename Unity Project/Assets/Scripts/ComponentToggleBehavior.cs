using UnityEngine;

public class ComponentToggleBehavior : MonoBehaviour
{

    public void ComponentToggleSwitch(Collider colliderObj)
    {
        if (colliderObj.enabled)
        {
            colliderObj.enabled = false;
        }
        else
        {
            colliderObj.enabled = true;
        }
    }
}