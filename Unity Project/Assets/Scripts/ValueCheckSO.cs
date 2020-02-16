using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ValueCheckSO : ScriptableObject
{
    public FloatDataSO dataObj;
    public bool greaterThan, lessThan, equal;
    public UnityEvent greaterThanEvent, lessThanEvent, equalEvent;

    public void CheckAgainstFloat(float comparedFloat)
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