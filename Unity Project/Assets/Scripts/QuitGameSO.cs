using UnityEngine;

[CreateAssetMenu]
public class QuitGameSO : ScriptableObject
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}