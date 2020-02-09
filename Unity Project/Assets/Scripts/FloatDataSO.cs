using UnityEngine;

[CreateAssetMenu]
public class FloatDataSO : ScriptableObject
{
    public float value, valueCap, valueOne, valueTwo;

    public void AddToData(float number)
    {
        value += number;

        if (value > valueCap && valueCap != 0)
        {
            value = valueCap;
        } else if (value <= 0)
        {
            value = 0;
        }
    }

    public void DivideData(float number)
    {
        value = value / number;
        
        if (value > valueCap && valueCap != 0)
        {
            value = valueCap;
        } else if (value <= 0)
        {
            value = 0;
        }
    }

    public void MultiplyData(float number)
    {
        value = value * number;
        
        if (value > valueCap && valueCap != 0)
        {
            value = valueCap;
        } else if (value <= 0)
        {
            value = 0;
        }
    }

    public void SetData(float number)
    {
        value = number;
        
        if (value > valueCap && valueCap != 0)
        {
            value = valueCap;
        } else if (value <= 0)
        {
            value = 0;
        }
    }

    public void DataSwap()
    {
        if (valueOne >= 0 && valueTwo >= 0)
        {
            if (value == valueOne)
            {
                value = valueTwo;
            }
            else
            {
                value = valueOne;
            }
        }
        
        if (value > valueCap && valueCap != 0)
        {
            value = valueCap;
        } else if (value <= 0)
        {
            value = 0;
        }
    }

    public void SetToCap()
    {
        value = valueCap;
    }
}