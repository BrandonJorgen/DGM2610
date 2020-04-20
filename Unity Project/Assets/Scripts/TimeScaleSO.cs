using UnityEngine;

[CreateAssetMenu]
public class TimeScaleSO : ScriptableObject
{
    public float timeScale;

    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
        timeScale = Time.timeScale;
    }

    public void PauseUnpause()
    {
        if (timeScale == 0)
        {
            SetTimeScale(1f);
        }
        else
        {
            SetTimeScale(0f);
        }
    }
}