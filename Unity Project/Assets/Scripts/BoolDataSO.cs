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

        if (!state)
        {
            boolData = false;
        }
    }

    public void SwitchBool()
    {
        if (boolData)
        {
            boolData = false;
        }
        else
        {
            boolData = true;
        }
    }
}