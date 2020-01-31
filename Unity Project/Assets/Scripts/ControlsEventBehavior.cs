using UnityEngine;
using UnityEngine.Events;

public class ControlsEventBehavior : MonoBehaviour
{
    public UnityEvent spaceDown, leftControlDown, leftControlUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceDown.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            leftControlDown.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            leftControlUp.Invoke();
        }
    }
}