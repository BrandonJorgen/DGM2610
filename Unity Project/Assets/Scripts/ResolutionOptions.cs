using UnityEngine;

public class ResolutionOptions : MonoBehaviour
{

    public void ChangeResolution(int index)
    {
        switch (index)
        {
                case 0:
                    TenEightyFullScreen();
                    break;
                
                case 1:
                    TenEighty();
                    break;
                
                case 2:
                    SevenTwentyFullScreen();
                    break;
                
                case 3:
                    SevenTwenty();
                    break;
                
                case 4:
                    FiveFortyFullScreen();
                    break;
                
                case 5:
                    FiveForty();
                    break;
                
                case 6:
                    FourEightyFullScreen();
                    break;
                
                case 7:
                    FourEighty();
                    break;
        }
    }
    
    public void TenEightyFullScreen()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void SevenTwentyFullScreen()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void FiveFortyFullScreen()
    {
        Screen.SetResolution(960, 540, true);
    }

    public void FourEightyFullScreen()
    {
        Screen.SetResolution(720, 480, true);
    }
    
    public void TenEighty()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void SevenTwenty()
    {
        Screen.SetResolution(1280, 720, false);
    }

    public void FiveForty()
    {
        Screen.SetResolution(960, 540, false);
    }

    public void FourEighty()
    {
        Screen.SetResolution(720, 480, false);
    }
}