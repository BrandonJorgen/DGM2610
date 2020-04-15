using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEventBehavior : MonoBehaviour
{
    public float time = 1f;
    public UnityEvent countdownFinished;

    private WaitForSeconds countdownWaitObj;

    private void Start()
    {
        countdownWaitObj = new WaitForSeconds(time);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return countdownWaitObj;
        countdownFinished.Invoke();
    }

    public void StartTimer()
    {
        StartCoroutine(Countdown());
    }
}