using UnityEngine;

[CreateAssetMenu]
public class DestroyObjSO : ScriptableObject
{
    public void DestroyObj(GameObject obj)
    {
        Destroy(obj);
    }
}