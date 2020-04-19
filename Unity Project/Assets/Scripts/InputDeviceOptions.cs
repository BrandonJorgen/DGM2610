using UnityEngine;
using UnityEngine.Events;

public class InputDeviceOptions : MonoBehaviour
{
    public UnityEvent keyboardEvent, controllerEvent;
    
    public void ChangeInput(int Index)
    {
        switch (Index)
        {
                case 0:
                    KeyboardInput();
                    break;
                
                case 1:
                    ControllerInput();
                    break;
        }
    }

    private void KeyboardInput()
    {
        keyboardEvent.Invoke();
    }

    private void ControllerInput()
    {
        controllerEvent.Invoke();
    }
}