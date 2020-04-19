using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LoadSceneSO : ScriptableObject
{
    public void LoadCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}