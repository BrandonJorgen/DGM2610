using UnityEngine;

public class QualityOptions : MonoBehaviour
{
    public void ChangeQuality(int index)
    {
        switch (index)
        {
                case 0:
                    UltraQuality();
                    break;
                
                case 1:
                    VeryHighQuality();
                    break;
                
                case 2:
                    HighQuality();
                    break;
                
                case 3:
                    MediumQuality();
                    break;
                
                case 4:
                    LowQuality();
                    break;
                
                case 5:
                    VeryLowQuality();
                    break;
        }
    }

    private void UltraQuality()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    
    private void VeryHighQuality()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
    
    private void HighQuality()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    
    private void MediumQuality()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    
    private void LowQuality()
    {
        QualitySettings.SetQualityLevel(1, true);
    }
    
    private void VeryLowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
}