using UnityEngine;
using UnityEngine.Events;

public class InputSelectorBehavior : MonoBehaviour
{
    public BoolDataSO keyboardControls, controllerControls;
    public UnityEvent keyboardInput, controllerInput;

    private void Awake()
    {
        KeyboardInput();
    }

    private void Update()
    {
        if (!keyboardControls.boolData && controllerControls.boolData)
        {
            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetKeyDown(KeyCode.LeftControl) ||
                Input.GetKeyDown(KeyCode.LeftShift) ||
                Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.E) ||
                Input.GetKeyDown(KeyCode.F) ||
                Input.GetMouseButtonDown(0) ||
                Input.GetKeyDown(KeyCode.Escape) ||
                Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D))
            {
                KeyboardInput();
                keyboardInput.Invoke();
            }
        }

        if (!controllerControls.boolData && keyboardControls.boolData)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) ||
                Input.GetKeyDown(KeyCode.Joystick1Button1) ||
                Input.GetKeyDown(KeyCode.Joystick1Button4) ||
                Input.GetKeyDown(KeyCode.Joystick1Button5) ||
                Input.GetKeyDown(KeyCode.Joystick1Button3) ||
                Input.GetKeyDown(KeyCode.Joystick1Button2) ||
                Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                ControllerInput();
                controllerInput.Invoke();
            }
        }
    }

    private void KeyboardInput()
    {
        keyboardControls.boolData = true;
        controllerControls.boolData = false;
    }

    private void ControllerInput()
    {
        controllerControls.boolData = true;
        keyboardControls.boolData = false;
    }
}