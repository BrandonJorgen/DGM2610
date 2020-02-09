using UnityEngine;

public class InstantiateObjBehavior : MonoBehaviour
{
    public GameObject instObj;
    private Transform instLocation;

    private void Start()
    {
        instLocation = transform;
    }

    public void InstantiateObj()
    {
        Instantiate(instObj, instLocation.position, instLocation.rotation);
    }
}