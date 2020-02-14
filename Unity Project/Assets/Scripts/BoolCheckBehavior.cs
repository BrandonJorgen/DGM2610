using UnityEngine;
using UnityEngine.Events;

public class BoolCheckBehavior : MonoBehaviour
{
    public BoolDataSO boolOne, boolTwo;
    public bool bothTrue, oneTrueTwoFalse, oneFalseTwoTrue, bothFalse;
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
}