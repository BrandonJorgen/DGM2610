using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjPileBehavior : MonoBehaviour
{
    public float value;
    public UnityEvent valueZero;
    public List<Mesh> meshList;
    
    private MeshFilter currentMesh;
    private int detractors;
    
    private void Start()
    {
        currentMesh = GetComponent<MeshFilter>();
    }

    public void AddToPile(FloatDataSO dataObj)
    {
        value += dataObj.value;
        //if statements checking value and assigning what mesh to display
    }

    public void Update()
    {
        if (detractors > 0)
        {
            value -= 5 * detractors * Time.deltaTime;
        } 
        
        if (value <= 0)
        {
            valueZero.Invoke();
            Destroy(gameObject);
        }
    }

    public void AddToDetractors(int integer)
    {
        detractors += integer;
    }
}