using UnityEngine;

[CreateAssetMenu]
public class BoolDataSO : ScriptableObject
{
    public bool boolData;

    public void SetBool(bool state)
    {
        if (state)
        {
            boolData = true;
        }

        if (state == false)
        {
            boolData = false;
        }
    }

    public void SwitchBool()
    {
        if (boolData)
        {
            boolData = false;
            Debug.Log(boolData + " just switched to false");
        }
        else
        {
            boolData = true;
            Debug.Log(boolData + " just switched to true");
        }
    }
}