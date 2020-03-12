using UnityEngine;

public class InstantiateObjBehavior : MonoBehaviour
{
    public GameObject instObj;

    public void InstantiateObjWithRotation()
    {
        Instantiate(instObj, transform.position, transform.rotation);
        Debug.Log("instantiated object");
    }
}