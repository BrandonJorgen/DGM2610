using UnityEngine;
using UnityEngine.Events;

public class EButtonEventBehavior : MonoBehaviour
{
    public UnityEvent eButtonDown, eButtonUp;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            eButtonDown.Invoke();
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            eButtonUp.Invoke();
        }
    }
}