using UnityEngine;
using UnityEngine.Events;

public class ObjPileBehavior : MonoBehaviour
{
    public float value;
    public Vector3 scaleValue;
    public Transform transformObj;
    public UnityEvent valueZero;
    
    private int detractors;

    public void Update()
    {
        if (detractors > 0)
        {
            value -= 5 * detractors * Time.deltaTime;
        } 
        
        if (value <= 0)
        {
            valueZero.Invoke();
            Destroy(gameObject);
        }

        if (value != 50)
        {
            scaleValue.Set(value / 50, value / 50, value / 50);
            transformObj.localScale = scaleValue;
        }
    }

    public void AddToDetractors(int integer)
    {
        detractors += integer;
    }
}