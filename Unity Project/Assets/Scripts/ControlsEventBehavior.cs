using UnityEngine;
 using UnityEngine.Events;
 
 public class ControlsEventBehavior : MonoBehaviour
 {
     public UnityEvent spaceDown, leftControlDown, leftControlUp, leftShiftDown, leftShiftUp, eDown, eUp;
 
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
 
         if (Input.GetKeyDown(KeyCode.LeftShift))
         {
             leftShiftDown.Invoke();
         }
         
         if (Input.GetKeyUp(KeyCode.LeftShift))
         {
             leftShiftUp.Invoke();
         }

         if (Input.GetKeyDown(KeyCode.E))
         {
             eDown.Invoke();
         }

         if (Input.GetKeyUp(KeyCode.E))
         {
             eUp.Invoke();
         }
     }
 }