using UnityEngine;
using UnityEngine.Events;

public class EscapeKeyInput : MonoBehaviour
{
    public UnityEvent escapeEvent;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeEvent.Invoke();
        }
    }
}