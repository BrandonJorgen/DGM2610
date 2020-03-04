using UnityEngine;

[RequireComponent(typeof(InstantiateSOBehavior))]
public class InstantiatedFloatDataBehavior : MonoBehaviour
{
    public FloatDataSO dataObj;

    private void Start()
    {
        dataObj = GetComponent<InstantiateSOBehavior>().soObjClone;
    }

    public void AddValue(float value)
    {
        dataObj.value += value;
    }
}