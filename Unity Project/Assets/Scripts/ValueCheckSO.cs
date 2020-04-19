using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class ValueCheckSO : ScriptableObject
{
    public FloatDataSO dataObj;
    public UnityEvent greaterThanEvent, lessThanEvent, equalEvent, greaterThanOrEqualToEvent;

    public void CheckAgainstFloat(float comparedFloat)
    {
        if (dataObj.value > comparedFloat)
        {
            greaterThanEvent.Invoke();
        }
        
        if (dataObj.value < comparedFloat)
        {
            lessThanEvent.Invoke();
        }

        if (dataObj.value == comparedFloat)
        {
            equalEvent.Invoke();
        }
        
        if (dataObj.value >= comparedFloat)
        {
            greaterThanOrEqualToEvent.Invoke();
        }
    }
}