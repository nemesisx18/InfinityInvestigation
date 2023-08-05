using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager ManagerInstance;

    public GameObject[] gameObjects;
    public bool isActive = false;
    public float timer = 0;
    public int score = 0;
    public GameObject nextScene;
    bool uda;
    public Text rewardTXT; // Referensi ke komponen Text
    public int puzzleDone;

    [SerializeField] private Leaderboard leaderboard;

    private void Awake()
    {
        if (ManagerInstance == null)
        {
            ManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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


            if (puzzleDone >= 10)
            {
                isActive = true;
            }
        }



        // Mengatur timer
        if (isActive)
        {
            if (uda == false)
            {
                GameEnd();
            }
        }

        // Mengecek kondisi timer dan memberikan skor sesuai dengan nilai timer
        if (timer < 10f)
        {
            score = 100;
        }
        else if (timer < 20f)
        {
            score = 60;
        }
        else if (timer < 30f)
        {
            score = 20;
        }
        else if (timer >= 30f)
        {
            score = 0;
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

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void WrongItem()
    {
        timer += 5;
        Debug.Log("wrong item");
    }

    public void GameEnd()
    {
        nextScene.SetActive(true);
        rewardTXT.text = "Skor Akhir : +" + score;
        //int plusJadiCoin = PlayerPrefs.GetInt("coin");
        int plusJadiCoin = SaveData.SaveInstance.Coin;
        plusJadiCoin += score;
        //PlayerPrefs.SetInt("coin", plusJadiCoin);
        SaveData.SaveInstance.ChangeCoinValue(plusJadiCoin);
        uda = true;
        uda = true;
        isActive = false;
    }
}
