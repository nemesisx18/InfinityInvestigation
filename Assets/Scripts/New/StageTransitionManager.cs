using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTransitionManager : MonoBehaviour
{
    public void RestartLevel()
    {
        var currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    public void NextSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
