using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InstantiateSOBehavior))]
public class InstantiatedValueCheckBehavior : MonoBehaviour
{
    public FloatDataSO dataObj;
    public bool greaterThan, lessThan, equal;
    public UnityEvent greaterThanEvent, lessThanEvent, equalEvent;

    public void Start()
    {
        dataObj = GetComponent<InstantiateSOBehavior>().soObjClone;
    }

    public void CheckValue(float comparedFloat)
    {
        if (dataObj.value > comparedFloat && greaterThan)
        {
            greaterThanEvent.Invoke();
        }
        
        if (dataObj.value < comparedFloat && lessThan)
        {
            lessThanEvent.Invoke();
        }

        if (dataObj.value == comparedFloat && equal)
        {
            equalEvent.Invoke();
        }
    }
}