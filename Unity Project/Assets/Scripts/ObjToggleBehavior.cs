using UnityEngine;

public class ObjToggleBehavior : MonoBehaviour
{
    public void ObjToggleEnabled()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}