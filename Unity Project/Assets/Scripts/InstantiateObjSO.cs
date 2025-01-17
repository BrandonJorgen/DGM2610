﻿using UnityEngine;

[CreateAssetMenu]
public class InstantiateObjSO : ScriptableObject
{
    public GameObject objToInstantiate;

    public void InstantiateObj(Transform location)
    {
        if (objToInstantiate != null && location != null)
        {
            Instantiate(objToInstantiate, location.position, location.rotation);
        }
    }
}