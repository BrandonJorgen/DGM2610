using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float data, dataCap;

    public void AddToData(int value)
    {
        data += value;

        if (data > dataCap && dataCap != 0)
        {
            data = dataCap;
        } else if (data <= 0)
        {
            data = 0;
        }
    }
}