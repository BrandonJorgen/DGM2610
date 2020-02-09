using UnityEngine;

public class InstantiateObjBehavior : MonoBehaviour
{
    public GameObject instObj;

    public void InstantiateObj()
    {
        Instantiate(instObj, transform.position, transform.rotation);
    }
}