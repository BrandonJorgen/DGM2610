using UnityEngine;
using UnityEngine.Events;

public class MonoEventBehavior : MonoBehaviour
{
    public UnityEvent onAwakeEvent, onStartEvent, onUpdateEvent;

    private void Awake()
    {
        onAwakeEvent.Invoke();
    }

    private void Start()
    {
        onStartEvent.Invoke();
    }

    private void Update()
    {
        onUpdateEvent.Invoke();
    }
}