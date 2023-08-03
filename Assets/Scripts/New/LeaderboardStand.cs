using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardStand : MonoBehaviour
{
    [SerializeField] private Text usernameText;
    [SerializeField] private Text scoreText;

    public void RegisterData(string username, int score)
    {
        usernameText.text = username;
        scoreText.text = score.ToString();
    }
}
