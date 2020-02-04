using UnityEngine;

[CreateAssetMenu]
public class Vector3SO : ScriptableObject
{
    public Vector3 vector3;

    public void UpdateData(Transform transformObj)
    {
        vector3 = transformObj.position;
    }

    public void MoveToData(Transform transformObj)
    {
        transformObj.position = vector3;
    }
}