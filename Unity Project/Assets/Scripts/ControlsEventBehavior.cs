using UnityEngine;
using UnityEngine.Events;
 
 public class ControlsEventBehavior : MonoBehaviour
 {
     public UnityEvent spaceDown, leftControlDown, leftControlUp, leftShiftDown, leftShiftUp, qDown, qUp, eDown, eUp, fDown, fUp, leftMouseDown, escapeDown;
 
     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
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
 
         if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button1))
         {
             leftShiftDown.Invoke();
         }
         
         if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Joystick1Button1))
         {
             leftShiftUp.Invoke();
         }

         if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))
         {
             qDown.Invoke();
         }

         if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button4))
         {
             qUp.Invoke();
         }
         
         if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
         {
             eDown.Invoke();
         }

         if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Joystick1Button5))
         {
             eUp.Invoke();
         }
         
         if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button3))
         {
             fDown.Invoke();
         }

         if (Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.Joystick1Button3))
         {
             fUp.Invoke();
         }

         if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button2))
         {
             leftMouseDown.Invoke();
         }

         if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
         {
             escapeDown.Invoke();
         }
     }
 }