using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public bool isActive = false;
    public float timer = 0;
    public int score = 0;
    public GameObject nextScene;
    bool uda;
    public Text  rewardTXT; // Referensi ke komponen Text
    public int puzzleDone;

    [SerializeField] private Leaderboard leaderboard;

    private void Start()
    {
        timer = 0;
    }
    void Update()
    {
        // Periksa apakah semua GameObject dalam array aktif
        if (uda == false)
        {
            timer += Time.deltaTime;
            isActive = AreAllGameObjectsActive();


            if(puzzleDone >= 4)
            {
                isActive = true;
            }
        }
       


        // Mengatur timer
        if (isActive)
        {
            if (uda == false)
            {
                nextScene.SetActive(true);
                rewardTXT.text = "Skor Akhir : +" + score;
                int plusJadiCoin = PlayerPrefs.GetInt("coin");
                plusJadiCoin += score;
                PlayerPrefs.SetInt("coin", plusJadiCoin);
                uda = true;
                uda = true;
                isActive = false;
            }
        }

        // Mengecek kondisi timer dan memberikan skor sesuai dengan nilai timer
        if (timer < 15f)
        {
            score = 500;
        }
        else if (timer < 30f)
        {
            score = 350;
        }
        else if (timer < 45f)
        {
            score = 150;
        }
        else if (timer < 60f)
        {
            score = 10;
        }

    }

    private bool AreAllGameObjectsActive()
    {
        foreach (GameObject obj in gameObjects)
        {
            if (!obj.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    public void SaveCurrentScore()
    {
        leaderboard.GenerateLeaderboard(SaveData.SaveInstance.CurrentUsername, score);
    }
}
