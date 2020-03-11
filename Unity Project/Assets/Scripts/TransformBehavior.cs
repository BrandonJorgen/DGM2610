using System;
using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
    private Transform transformObj;

    public float knockbackFloat;

    private void Start()
    {
        transformObj = GetComponent<Transform>();
    }

    public void Knockback()
    {
        transformObj.position += transformObj.TransformDirection(Vector3.back) * knockbackFloat;
    }
}