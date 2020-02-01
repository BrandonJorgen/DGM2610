using UnityEngine;
using UnityEngine.Events;

public class AnimEventBehavior : MonoBehaviour
{
    public UnityEvent eventOne, eventTwo;

    public void CallEventOne()
    {
        eventOne.Invoke();
    }

    public void CallEventTwo()
    {
        eventTwo.Invoke();
    }
}
