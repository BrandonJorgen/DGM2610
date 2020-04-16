using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
    private Transform transformObj;

    public float knockbackFloat, movementRate = 1f;

    private void Start()
    {
        transformObj = GetComponent<Transform>();
    }

    public void Knockback()
    {
        transformObj.position += transformObj.TransformDirection(Vector3.back) * knockbackFloat;
    }
    
    public void KnockbackFloatArg(float knockbackDistance)
    {
        transformObj.position += transformObj.TransformDirection(Vector3.back) * knockbackDistance;
    }

    public void MoveLeft()
    {
        transformObj.position += transformObj.TransformDirection(Vector3.left) * movementRate * Time.deltaTime;
    }
}