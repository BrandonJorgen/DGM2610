using UnityEngine;

[CreateAssetMenu]
public class CursorSO : ScriptableObject
{
    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
    }

    public void ToggleCursor()
    {
        if (Cursor.visible)
        {
            HideCursor();
        }
        else
        {
            ShowCursor();
        }
    }
}