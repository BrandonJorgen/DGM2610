using UnityEngine;
using UnityEngine.Events;

public class AnimEventBehavior : MonoBehaviour
{
    public UnityEvent eventOne, eventTwo, eventThree, eventFour, eventFive;

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
}