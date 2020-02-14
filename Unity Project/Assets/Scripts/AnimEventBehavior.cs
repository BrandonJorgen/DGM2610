using UnityEngine;
using UnityEngine.Events;

public class AnimEventBehavior : MonoBehaviour
{
    public UnityEvent eventOne, eventTwo, eventThree, eventFour, eventFive, eventSix, eventSeven, eventEight, eventNine, eventTen, 
        eventEleven;

    public void CallEventOne()
    {
        eventOne.Invoke();
    }

    public void CallEventTwo()
    {
        eventTwo.Invoke();
    }

    public void CallEventThree()
    {
        eventThree.Invoke();
    }

    public void CallEventFour()
    {
        eventFour.Invoke();
    }

    public void CallEventFive()
    {
        eventFive.Invoke();
    }
    
    public void CallEventSix()
    {
        eventSix.Invoke();
    }
    
    public void CallEventSeven()
    {
        eventSeven.Invoke();
    }
    
    public void CallEventEight()
    {
        eventEight.Invoke();
    }

    public void CallEventNine()
    {
        eventNine.Invoke();
    }

    public void CallEventTen()
    {
        eventTen.Invoke();
    }

    public void CallEventEleven()
    {
        eventEleven.Invoke();
    }
}