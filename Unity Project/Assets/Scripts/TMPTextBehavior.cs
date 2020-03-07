using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPTextBehavior : MonoBehaviour
{
    private TextMeshProUGUI tmpObj;

    private void Awake()
    {
        tmpObj = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(FloatDataSO dataObj)
    {
        tmpObj.text = dataObj.value.ToString();
    }
}