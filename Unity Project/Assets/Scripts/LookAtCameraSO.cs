using UnityEngine;

[CreateAssetMenu]
public class LookAtCameraSO : ScriptableObject
{
    public void LookAtCamera(Transform transformObj)
    {
        if (Camera.main != null)
            transformObj.transform.LookAt(transformObj.transform.position + Camera.main.transform.rotation * Vector3.up, Camera.main.transform.rotation * Vector3.up);
    }
}