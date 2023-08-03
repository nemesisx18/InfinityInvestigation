using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public int checkpoint;

    // Start is called before the first frame update
    void Awake()
    {
        checkpoint = PlayerPrefs.GetInt("save");
    }

    void Start()
    {
        if (checkpoint == 1)
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "Level1")
            {
                SceneManager.LoadScene("Level1");
            }
        }
        if (checkpoint == 2)
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "Level2")
            {
                SceneManager.LoadScene("Level2");
            }
        }
        if (checkpoint == 3)
        {
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName != "Level3")
            {
                SceneManager.LoadScene("Level3");
            }
        }
    }


    public void save(int savekeberapa)
    {
        PlayerPrefs.SetInt("save", savekeberapa);
    }

}
