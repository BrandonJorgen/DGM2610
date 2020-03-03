using UnityEngine;
using UnityEngine.Events;

public class TriggerBehavior : MonoBehaviour
{
    private Collider colliderObj;
    
    public UnityEvent onTriggerEnter, onTriggerExit;

    private void Start()
    {
        colliderObj = GetComponent<Collider>();

        if (!colliderObj.isTrigger)
        {
            colliderObj.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}