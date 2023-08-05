using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData SaveInstance;

    public List<Rating> Leaderboard_1 = new List<Rating>();
    public List<Rating> Leaderboard_2 = new List<Rating>();
    public List<Rating> Leaderboard_3 = new List<Rating>();

    public int Coin;

    public string CurrentUsername;

    private const string _prefsKey = "DatabaseUser";

    private void Awake()
    {
        if (SaveInstance == null)
        {
            SaveInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_prefsKey))
        {
            string json = PlayerPrefs.GetString(_prefsKey);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(_prefsKey, json);
    }

    public void UpdateLeaderboard(int level, List<Rating> leaderboard)
    {
        switch(level)
        {
            case 1:
                Leaderboard_1 = leaderboard; 
                break;
            case 2: 
                Leaderboard_2 = leaderboard;
                break;
            case 3:
                Leaderboard_3 = leaderboard;
                break;
            default:
                break;
        }

        Save();
    }

    public void SetUsername(string name)
    {
        CurrentUsername = name;
    }

    public void ChangeCoinValue(int value)
    {
        Coin = value;
    }
}
