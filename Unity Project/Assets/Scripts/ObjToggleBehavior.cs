using UnityEngine;

public class ObjToggleBehavior : MonoBehaviour
{
    public void ToggleEnabled()
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