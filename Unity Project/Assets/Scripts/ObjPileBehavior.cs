using System.Collections.Generic;
using UnityEngine;

public class ObjPileBehavior : MonoBehaviour
{
    public float value;
    private MeshFilter currentMesh;
    public List<Mesh> meshList;
    
    private void Start()
    {
        currentMesh = GetComponent<MeshFilter>();
    }

    public void AddToPile(FloatDataSO dataObj)
    {
        value += dataObj.value;
        //if statements checking value and assigning what mesh to display
    }
}