using UnityEngine;
using UnityEngine.UI;

public class ImageBehavior : MonoBehaviour
{
    public Image[] images;

    private Image currentImage;

    public void FillAllImages()
    {
        foreach (var image in images)
        {
            image.fillAmount = 1;
        }
    }
    
    public void UpdateFillAmountPercentage(FloatDataSO dataObj)
    {
        var percentageValue = dataObj.value / dataObj.valueCap;

        if (percentageValue == 1)
        {
            FillAllImages();
        }

        if (percentageValue < 1 && percentageValue > .33)
        {
            images[0].fillAmount = 0;
            images[1].fillAmount = 1;
            images[2].fillAmount = 1;
        }
        
        if (percentageValue <.66 && percentageValue > 0)
        {
            images[0].fillAmount = 0;
            images[1].fillAmount = 0;
            images[2].fillAmount = 1;
        }

        if (percentageValue <= 0)
        {
            images[0].fillAmount = 0;
            images[1].fillAmount = 0;
            images[2].fillAmount = 0;
        }
    }
}