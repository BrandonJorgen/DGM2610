using UnityEngine;

[CreateAssetMenu]
public class InstantiateObjSO : ScriptableObject
{
    public GameObject objToInstantiate;

    public void InstantiateObj(Transform location)
    {
        Instantiate(objToInstantiate, location.position, location.rotation);
    }
}