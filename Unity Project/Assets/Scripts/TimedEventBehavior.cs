using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEventBehavior : MonoBehaviour
{
    public float time = 1f;
    public UnityEvent countdownFinished;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(time);
        countdownFinished.Invoke();
    }

    public void StartTimer()
    {
        StartCoroutine(Countdown());
    }
}