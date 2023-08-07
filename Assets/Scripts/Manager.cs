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

    [Header("Level 2")]
    public bool isLevel2 = false;
    public GameObject HandImg;
    public GameObject NextLevelBtn;

    [Header("Leaderboard standing")]
    public bool on1 = false;
    public bool on2 = false;
    public bool on3 = false;

    public GameObject ShareFacebook;
    public recharge recharge;

    private SaveData saveData;

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

        saveData = SaveData.SaveInstance;
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
        if(isLevel2 && score < 60)
        {
            HandImg.SetActive(false);
            NextLevelBtn.SetActive(false);
        }
        
        nextScene.SetActive(true);
        rewardTXT.text = "Skor Akhir : +" + score;
        int plusJadiCoin = SaveData.SaveInstance.Coin;
        plusJadiCoin += score;
        SaveData.SaveInstance.ChangeCoinValue(plusJadiCoin);
        uda = true;
        uda = true;
        isActive = false;
    }

    public void CheckUserTopThree()
    {
        string temp = saveData.CurrentUsername;

        for (int i = 0; i < saveData.Leaderboard_1.Count; i++)
        {
            if (saveData.Leaderboard_1[i].Username.Contains(temp))
            {
                on1 = true;
                break;
            }
        }
        for (int i = 0; i < saveData.Leaderboard_2.Count; i++)
        {
            if (saveData.Leaderboard_2[i].Username.Contains(temp))
            {
                on2 = true;
                break;
            }
        }
        for (int i = 0; i < saveData.Leaderboard_3.Count; i++)
        {
            if (saveData.Leaderboard_3[i].Username.Contains(temp))
            {
                on3 = true;
                break;
            }
        }

        if(on1 && on2 && on3)
        {
            ShareFacebook.SetActive(true);
        }
        else
        {
            recharge.relog();
        }
    }
}
