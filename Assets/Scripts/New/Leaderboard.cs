using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Leaderboard : MonoBehaviour
{
    public int currentLevel;
    
    public List<Rating> realRatings = new List<Rating>();

    public List<GameObject> spawnedLeaderboards = new List<GameObject>();

    public List<int> score = new List<int>();

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private Transform leaderboardParent;
    [SerializeField] private LeaderboardStand leaderboardPrefab;

    [SerializeField] private int maxLeaderboard = 3;

    [SerializeField] private bool nextStage = true;
    private bool alreadySpawn = false;

    private void Start()
    {
        switch (currentLevel) 
        {
            case 1:
                if(SaveData.SaveInstance.Leaderboard_1.Count != 0)
                {
                    realRatings = SaveData.SaveInstance.Leaderboard_1;
                    SpawnLeaderboard();
                    alreadySpawn = true;
                }

                break;
            case 2:
                if (SaveData.SaveInstance.Leaderboard_2.Count != 0)
                {
                    realRatings = SaveData.SaveInstance.Leaderboard_2;
                    SpawnLeaderboard();
                    alreadySpawn = true;
                }

                break;
            case 3:
                if (SaveData.SaveInstance.Leaderboard_3.Count != 0)
                {
                    realRatings = SaveData.SaveInstance.Leaderboard_3;
                    SpawnLeaderboard();
                    alreadySpawn = true;
                }

                break;
            default:
                break;
        }
    }

    public void SendDummyData()
    {
        List<int> scoreTemp = new List<int>() { 50, 240, 420, 500 };
        List<string> randomUser = new List<string>() { "absan", "mona", "ndia", "moana", "adnsjd", "dausd", "sndaw", "snduaw", "sdnu", "sanud", "sdnua", "aaaa" };

        var score = Random.Range(0, scoreTemp.Count);
        var name = Random.Range(0, randomUser.Count);

        randomUser.RemoveAt(name);
        GenerateLeaderboard(randomUser[name], scoreTemp[score]);
    }

    public void GenerateLeaderboard(string username, int score)
    {
        if (realRatings.Count < maxLeaderboard)
        {
            var test = new Rating() { Username = username, ScoreValue = (Scoring)score };

            realRatings.Add(test);
        }
        else
        {
            //Generate new temporary score list and get the lowest score
            var tempScore = new List<int>();
            for (int i = 0; i < realRatings.Count; i++)
            {
                tempScore.Add((int)realRatings[i].ScoreValue);
            }

            var minScore = tempScore.Min();

            Debug.Log("Current lowest score is: " + minScore);

            //Check if new score higher than lowest score avaiable then change it into new score
            if (score > minScore)
            {
                for (int i = 0; i < realRatings.Count; i++)
                {
                    //Remove the lowest score
                    if ((int)realRatings[i].ScoreValue == minScore)
                    {
                        Debug.Log("Lowest score index: " + i);
                        realRatings.RemoveAt(i);

                        //Add the new score
                        var newScore = new Rating() { Username = username, ScoreValue = (Scoring)score };

                        realRatings.Add(newScore);
                        break;
                    }
                }

                nextButton.SetActive(true);
            }
            else
            {
                nextStage = false;
                restartButton.SetActive(true);
            }
        }

        //Sort score
        realRatings.Sort((p1, p2) => p2.ScoreValue.CompareTo(p1.ScoreValue));

        if(spawnedLeaderboards.Count == 0 && !alreadySpawn)
        {
            SpawnLeaderboard();
            alreadySpawn = true;
        }
        else
        {
            OverwriteLeaderboard();
        }
    }

    private void SpawnLeaderboard()
    {
        if (spawnedLeaderboards.Count < maxLeaderboard)
        {
            for (int i = 0; i < realRatings.Count; i++)
            {
                LeaderboardStand gameObj = Instantiate(leaderboardPrefab, leaderboardParent);
                gameObj.RegisterData(realRatings[i].Username, (int)realRatings[i].ScoreValue);

                spawnedLeaderboards.Add(gameObj.gameObject);
            }
        }
    }

    private void OverwriteLeaderboard()
    {
        for (int i = 0; i < spawnedLeaderboards.Count; i++)
        {
            Destroy(spawnedLeaderboards[i]);
        }
        spawnedLeaderboards.Clear();

        if (spawnedLeaderboards.Count < maxLeaderboard)
        {
            Debug.Log(spawnedLeaderboards.Count);
            for (int i = 0; i < realRatings.Count; i++)
            {
                LeaderboardStand gameObj = Instantiate(leaderboardPrefab, leaderboardParent);
                gameObj.RegisterData(realRatings[i].Username, (int)realRatings[i].ScoreValue);

                spawnedLeaderboards.Add(gameObj.gameObject);
            }
        }
    }

    [ContextMenu("Save current leaderboard")]
    public void SaveCurrentLeaderboard()
    {
        SaveData.SaveInstance.UpdateLeaderboard(currentLevel, realRatings);
    }
}