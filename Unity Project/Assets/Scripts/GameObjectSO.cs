using UnityEngine;

[CreateAssetMenu]
public class GameObjectSO : ScriptableObject
{
    public GameObject gameObj;

    public void SetObject(GameObject obj)
    {
        gameObj = obj;
    }
}