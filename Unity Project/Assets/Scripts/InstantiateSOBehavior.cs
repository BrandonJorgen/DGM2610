using UnityEngine;

public class InstantiateSOBehavior : MonoBehaviour
{
    public FloatDataSO soObj;
    public FloatDataSO soObjClone;

    private void Awake()
    {
        InstantiateFloatDataSO();
    }

    public void InstantiateFloatDataSO()
    {
        soObjClone = Instantiate(soObj);
    }
}