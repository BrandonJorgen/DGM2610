using UnityEngine;
using UnityEngine.Events;

public class BoolCheckBehavior : MonoBehaviour
{
    public BoolDataSO boolOne, boolTwo;
    public bool bothTrue, oneTrueTwoFalse, oneFalseTwoTrue, bothFalse, oneTrue, oneFalse;
    public UnityEvent conditionsMet;

    public void TwoBoolCheck()
    {
        if (bothTrue)
        {
            if (boolOne.boolData && boolTwo.boolData)
            {
                conditionsMet.Invoke();
            }
        }
        
        if (oneTrueTwoFalse)
        {
            if (boolOne.boolData && !boolTwo.boolData)
            {
                conditionsMet.Invoke();
            }
        }
        
        if (oneFalseTwoTrue)
        {
            if (!boolOne.boolData && boolTwo.boolData)
            {
                conditionsMet.Invoke();
            }
        }
        
        if (bothFalse)
        {
            if (!boolOne.boolData && !boolTwo.boolData)
            {
                conditionsMet.Invoke();
            }
        }
    }

    public void OneBoolCheck()
    {
        if (oneTrue && boolOne.boolData)
        {
            conditionsMet.Invoke();
        }

        if (oneFalse && !boolOne.boolData)
        {
            conditionsMet.Invoke();
        }
    }
}