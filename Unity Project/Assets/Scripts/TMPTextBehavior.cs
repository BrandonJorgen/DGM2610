using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class TMPTextBehavior : MonoBehaviour
{
    private TextMeshPro tmpObj;
    private int i;

    [Multiline]
    public List<string> stringList;

    private void Awake()
    {
        tmpObj = GetComponent<TextMeshPro>();
        NextString();
    }

    public void UpdateText(string stringText)
    {
        tmpObj.text = stringText;
    }

    public void UpdateText(FloatDataSO dataObj)
    {
        tmpObj.text = dataObj.value.ToString();
    }

    public void NextString()
    {
        if (stringList.Count != 0)
        {
            tmpObj.text = stringList[i];
            i = (i + 1) % stringList.Count;
        }
    }
}