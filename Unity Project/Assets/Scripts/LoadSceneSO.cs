using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class LoadSceneSO : ScriptableObject
{
    public void LoadCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
}