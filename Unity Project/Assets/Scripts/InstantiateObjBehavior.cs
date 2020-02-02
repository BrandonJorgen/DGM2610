using UnityEngine;

public class InstantiateObjBehavior : MonoBehaviour
{
    public GameObject instObj;
    public Transform instLocation;

    public void InstantiateObj()
    {
        Instantiate(instObj, instLocation.position, instLocation.rotation);
    }
}